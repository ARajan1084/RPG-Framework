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
    public SceneStudioCanvasManager sceneStudioCanvasManager;

    public void Start()
    {
        campaignID = FindObjectOfType<CampaignManager>().activeCampaign;
        fetchActiveScene(campaignID);
    }

    public void saveScene()
    {
        GameObject[] staticGameObjects = GameObject.FindGameObjectsWithTag("Static");
        Asset[] assets = new Asset[staticGameObjects.Length];
        
        for (int i = 0; i < assets.Length; i++)
        {
            Transform t = staticGameObjects[i].transform;
            Vector3 pos = t.position;
            Vector3 rot = t.rotation.eulerAngles;
            Vector3 scale = t.localScale;
            assets[i] = new Asset(staticGameObjects[i].name.Replace("(Clone)", ""), pos.x, pos.y, pos.z, rot.x, rot.y, rot.z, scale.x, scale.y, scale.z);
        }
        Debug.Log(assets.Length);

        string jsonData = JsonHelper.ToJson(assets);
        UnityWebRequest request = PreparePostRequest("http://127.0.0.1:8000/campaigns/scenes/assets/save/" + sceneID, jsonData);
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
        Debug.Log(requestDataJson);
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
                Debug.Log(asset.asset_id);
                GameObject instantiated = Instantiate(Resources.Load<GameObject>(asset.asset_id), new Vector3(asset.x_pos, asset.y_pos, asset.z_pos), 
                    Quaternion.Euler(asset.x_rot, asset.y_rot, asset.z_rot));
                instantiated.transform.localScale = new Vector3(asset.x_scale, asset.y_scale, asset.z_scale);
            }
            sceneStudioCanvasManager.ground = GameObject.FindGameObjectWithTag("Board");
        }
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
            SceneRequestData activeScene = JsonUtility.FromJson<SceneRequestData>(Regex.Unescape(jsonData).Trim('"').Replace(" ", ""));
            sceneID = activeScene.scene_id;
            fetchSceneAssetData();
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

        public Asset(string assetID, float xPos, float yPos, float zPos, float xRot, float yRot, float zRot, float xScale, float yScale, float zScale)
        {
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
