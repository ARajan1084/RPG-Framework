using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class SceneManager : MonoBehaviour
{
    public TMP_InputField sceneName;
    public string sceneID;
    public string campaignID;

    public void Start()
    {
        campaignID = FindObjectOfType<CampaignManager>().activeCampaign;
        fetchActiveScene(campaignID);
        fetchSceneAssetData();
    }

    public void saveScene()
    {
        Asset[] assets = {};
        
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Static"))
        {
            Transform t = gameObject.transform;
            Vector3 pos = t.position;
            Vector3 rot = t.rotation.eulerAngles;
            Vector3 scale = t.localScale;
            Asset asset = new Asset(sceneID, gameObject.name, pos.x, pos.y, pos.z, rot.x, rot.y, rot.z, scale.x, scale.y, scale.z);
            assets.Append(asset);
        }

        string jsonData = JsonHelper.ToJson(assets);
        UnityWebRequest request = PreparePostRequest("http://127.0.0.1:8000/campaigns/scenes/assets/save", jsonData);
        StartCoroutine(sendSaveSceneRequest(request));
    }

    IEnumerator sendSaveSceneRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();
    }
    
    public void fetchSceneAssetData()
    {
        SceneRequestData requestData = new SceneRequestData(sceneID, campaignID);
        string requestDataJson = JsonUtility.ToJson(requestData);
        UnityWebRequest request = PreparePostRequest("http://127.0.0.1:8000/campaigns/scenes/assets/fetch", requestDataJson);
        StartCoroutine(sendFetchSceneAssetDataRequest(request));
    }

    IEnumerator sendFetchSceneAssetDataRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/MainMenu");
        }
        else
        {
            string jsonData = request.downloadHandler.text;
            // creates asset objects from downloaded JSON
            Asset[] assets = JsonHelper.FromJson<Asset>(Regex.Unescape(jsonData).Trim('"').Replace(" ", ""));
            // instantiates each asset into scene
            foreach (Asset asset in assets)
            {
                GameObject instantiated = Instantiate(fetchAsset(asset.asset_id), new Vector3(asset.x_pos, asset.y_pos, asset.z_pos), 
                    Quaternion.Euler(asset.x_rot, asset.y_rot, asset.z_rot));
                instantiated.transform.localScale = new Vector3(asset.x_scale, asset.y_scale, asset.z_scale);
            }
        }
    }

    GameObject fetchAsset(string assetID)
    {
        
        return null;
    }

    public void fetchActiveScene(string campaignID)
    {
        ActiveSceneRequestData requestData = new ActiveSceneRequestData(campaignID);
        string requestDataJson = JsonUtility.ToJson(requestData);
        UnityWebRequest request = PreparePostRequest("http://127.0.0.1:8000/campaigns/scenes/fetch", requestDataJson);
        StartCoroutine(sendFetchActiveSceneRequest(request));
    }

    IEnumerator sendFetchActiveSceneRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();
        if (request.error == null)
        {
            string jsonData = request.downloadHandler.text;
            Debug.Log(Regex.Unescape(jsonData).Trim('"').Replace(" ", ""));
            SceneRequestData activeScene = JsonUtility.FromJson<SceneRequestData>(Regex.Unescape(jsonData).Trim('"').Replace(" ", ""));
            Debug.Log(activeScene.scene_id);
            sceneID = activeScene.scene_id;
        }
        else
        {
            Debug.Log("Cannot fetch active scene");
        }
    }
    
    UnityWebRequest PreparePostRequest(string url, string sceneDataJson)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(sceneDataJson);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        return request;
    }
    
    [Serializable]
    public class Asset
    {
        public string scene_id;
        public string asset_id;
        public float x_pos;
        public float y_pos;
        public float z_pos;
        public float x_rot;
        public float y_rot;
        public float z_rot;
        public float x_scale;
        public float y_scale;
        public float z_scale;

        public Asset(string sceneID, string assetID, float xPos, float yPos, float zPos, float xRot, float yRot, float zRot, float xScale, float yScale, float zScale)
        {
            scene_id = sceneID;
            asset_id = assetID;
            x_pos = xPos;
            y_pos = yPos;
            z_pos = zPos;
            x_rot = xRot;
            y_rot = yRot;
            z_rot = zRot;
            x_scale = xScale;
            y_scale = yScale;
            z_scale = zScale;
        }
    }

    public class SceneRequestData
    {
        public string scene_id;
        public string campaign_id;

        public SceneRequestData(string sceneID, string campaignID)
        {
            scene_id = sceneID;
            campaign_id = campaignID;
        }
    }

    [Serializable]
    private class ActiveSceneRequestData
    {
        public string campaignID;

        public ActiveSceneRequestData(string campaignID)
        {
            this.campaignID = campaignID;
        }
    }
}
