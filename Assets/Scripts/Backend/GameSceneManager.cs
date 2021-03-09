using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Networking;

public class GameSceneManager : SceneManager
{
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
                    GameObject instantiated = Instantiate(Resources.Load<GameObject>("PlayerBoard"), new Vector3(asset.x_pos, asset.y_pos, asset.z_pos), 
                        Quaternion.Euler(asset.x_rot, asset.y_rot, asset.z_rot));
                    instantiated.transform.localScale = new Vector3(asset.x_scale, asset.y_scale, asset.z_scale);
                }
                else
                {
                    instantiateAsset(asset);
                }
            }
        }
        canvasManager.ground = GameObject.FindGameObjectWithTag("Board");
    }
    
    public override IEnumerator sendFetchActiveSceneRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();
        if (request.error == null)
        {
            string jsonData = request.downloadHandler.text;
            Scene activeScene = JsonUtility.FromJson<Scene>(Regex.Unescape(jsonData).Trim('"').Replace(" ", ""));
            activeSceneID = activeScene.scene_id;
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
        
    }
}
