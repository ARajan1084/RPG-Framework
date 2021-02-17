using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStudioCanvasManager : MonoBehaviour
{
    public GameObject hotbar;
    public GameObject optionsPanel;
    public GameObject cameraController;
    public GameObject ground;

    private bool active = true;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            optionsPanel.SetActive(active);
            hotbar.GetComponent<HotbarManager>().enabled = !active;
            cameraController.GetComponent<DMCameraController>().enabled = !active;
            ground.GetComponent<Board>().setTileState(!active);
            Cursor.visible = active;
            if (active)
            {
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            active = !active;
        }
    }
}
