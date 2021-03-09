using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class SceneStudioSceneManager : SceneManager
{
    public TMP_InputField activeSceneName;
    public GameObject scenesList;
    public GameObject scenePanelPrefab;
    public TMP_InputField newSceneName;
    
    public override IEnumerator sendFetchSceneAssetDataRequest (UnityWebRequest request)
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
                if (asset.asset_id == "Board")
                {
                    GameObject instantiated = Instantiate(Resources.Load<GameObject>("DMBoard"), new Vector3(asset.x_pos, asset.y_pos, asset.z_pos), 
                        Quaternion.Euler(asset.x_rot, asset.y_rot, asset.z_rot));
                    instantiated.transform.localScale = new Vector3(asset.x_scale, asset.y_scale, asset.z_scale);
                }
                else
                {
                    instantiateAsset(asset);
                }
            }
            canvasManager.ground = GameObject.FindGameObjectWithTag("Board");
        }
    }
    
    public override IEnumerator sendFetchActiveSceneRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();
        if (request.error == null)
        {
            string jsonData = request.downloadHandler.text;
            SceneInformation activeScene = JsonUtility.FromJson<SceneInformation>(Regex.Unescape(jsonData).Trim('"').Replace(" ", ""));
            activeSceneID = activeScene.scene_id;
            activeSceneName.text = activeScene.scene_name;
            fetchScenes();
            fetchSceneAssetData();
        }
        else
        {
            Debug.Log("Cannot fetch active scene");
        }
    }

    public override void updateScenes()
    {
        foreach (GameObject scene in scenesList.transform)
        {
            Destroy(scene);
        }
        foreach (SceneInformation scene in scenes)
        {
            GameObject scenePanel = Instantiate(scenePanelPrefab, scenesList.transform);
            scenePanel.GetComponentInChildren<Text>().text = scene.scene_name;
            scenePanel.GetComponent<Scene>().scene_id = scene.scene_id;
            scenePanel.GetComponent<Scene>().scene_name = scene.scene_name;
        }
    }

    public void createScene()
    {
        NewSceneRequestData requestData = new NewSceneRequestData(newSceneName.text, campaignID);
        string requestDataJson = JsonUtility.ToJson(requestData);
        UnityWebRequest request = PreparePostRequest("http://127.0.0.1:8000/campaigns/scenes/new/", requestDataJson);
        StartCoroutine(sendCreateSceneRequest(request));
    }

    IEnumerator sendCreateSceneRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();
        if (request.error == null)
        {
            fetchScenes();
        }
    }

    public void setActiveScene(Scene scene)
    {
        SceneRequestData requestData = new SceneRequestData(scene.scene_id, campaignID);
        string requestDataJson = JsonUtility.ToJson(requestData);
        UnityWebRequest request =
            PreparePostRequest("http://127.0.0.1:8000/campaigns/scenes/set/active/", requestDataJson);
        StartCoroutine(sendSetActiveSceneRequest(request));
    }

    IEnumerator sendSetActiveSceneRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();
        if (request.error == null)
        {
            
        }
        else
        {
            Debug.Log(request.error);
        }
    }

    [Serializable]
    private class NewSceneRequestData
    {
        public string scene_name;
        public string campaign_id;

        public NewSceneRequestData(string sceneName, string campaignID)
        {
            scene_name = sceneName;
            campaign_id = campaignID;
        }
    }
}
