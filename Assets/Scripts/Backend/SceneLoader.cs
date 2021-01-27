using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;

public class SceneLoader : MonoBehaviour
{
    public void fetchSceneAssetData(string sceneID, string campaignID)
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
            // return to Main Menu and display appropriate error
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
        //TODO: Fix
        return null;
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
        public int x_pos;
        public int y_pos;
        public int z_pos;
        public int x_rot;
        public int y_rot;
        public int z_rot;
        public int x_scale;
        public int y_scale;
        public int z_scale;
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
}
