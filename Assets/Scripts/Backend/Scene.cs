using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene: MonoBehaviour
{
    public string scene_id;
    public string scene_name;

    public Scene(string sceneID, string sceneName)
    {
        scene_id = sceneID;
        scene_name = sceneName;
    }

    public void setActive()
    {
        SceneStudioSceneManager sceneManager = FindObjectOfType<SceneStudioSceneManager>();
        sceneManager.setActiveScene(this);
    }
}
