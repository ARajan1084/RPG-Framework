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
using UnityEngine.PlayerLoop;

public abstract class SceneManager : MonoBehaviour
{
    public string activeSceneID;
    public string campaignID;
    public CanvasManager canvasManager;
    public ArrayList scenes = new ArrayList();

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
        UnityWebRequest request = PreparePostRequest("http://127.0.0.1:8000/campaigns/scenes/assets/save/" + activeSceneID, jsonData);
        StartCoroutine(sendSaveSceneRequest(request));
    }

    IEnumerator sendSaveSceneRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();
    }
    
    public void fetchSceneAssetData()
    {
        SceneRequestData requestData = new SceneRequestData(activeSceneID, campaignID);
        string requestDataJson = JsonUtility.ToJson(requestData);
        UnityWebRequest request = PreparePostRequest("http://127.0.0.1:8000/campaigns/scenes/assets/fetch/", requestDataJson);
        StartCoroutine(sendFetchSceneAssetDataRequest(request));
    }

    public abstract IEnumerator sendFetchSceneAssetDataRequest(UnityWebRequest request);
    
    public void instantiateAsset(Asset asset)
    {
        GameObject instantiated = Instantiate(Resources.Load<GameObject>(asset.asset_id), new Vector3(asset.x_pos, asset.y_pos, asset.z_pos), 
            Quaternion.Euler(asset.x_rot, asset.y_rot, asset.z_rot));
        instantiated.transform.localScale = new Vector3(asset.x_scale, asset.y_scale, asset.z_scale);
    }

    public void fetchActiveScene(string campaignID)
    {
        ActiveSceneRequestData requestData = new ActiveSceneRequestData(campaignID);
        string requestDataJson = JsonUtility.ToJson(requestData);
        UnityWebRequest request = PreparePostRequest("http://127.0.0.1:8000/campaigns/scenes/fetch/active/", requestDataJson);
        StartCoroutine(sendFetchActiveSceneRequest(request));
    }

    public abstract IEnumerator sendFetchActiveSceneRequest(UnityWebRequest request);

    public void fetchScenes()
    {
        string requestDataJson = JsonUtility.ToJson(new ActiveSceneRequestData(campaignID));
        UnityWebRequest request = PreparePostRequest("http://127.0.0.1:8000/campaigns/scenes/fetch/", requestDataJson);
        StartCoroutine(sendFetchScenesRequest(request));
    }

    IEnumerator sendFetchScenesRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();
        if (request.error == null)
        {
            string jsonData = request.downloadHandler.text;
            SceneInformation[] scenes =
                JsonHelper.FromJson<SceneInformation>(Regex.Unescape(jsonData).Trim('"').Replace(" ", ""));
            foreach (SceneInformation scene in scenes)
            {
                this.scenes.Add(scene);
            }
            updateScenes();
        }
    }

    public abstract void updateScenes();

    public UnityWebRequest PreparePostRequest(string url, string sceneDataJson)
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
    public class ActiveSceneRequestData
    {
        public string campaignID;

        public ActiveSceneRequestData(string campaignID)
        {
            this.campaignID = campaignID;
        }
    }
    
    [Serializable]
    public class SceneInformation
    {
        public string scene_id;
        public string scene_name;

        public SceneInformation(string sceneID, string sceneName)
        {
            scene_id = sceneID;
            scene_name = sceneName;
        }
    }
}
