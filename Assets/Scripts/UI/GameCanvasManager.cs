using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvasManager : CanvasManager
{
    public GameObject rollWheel;
    public GameObject savingThrowWheel;
    private bool active = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
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
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!rollWheel.activeSelf && !savingThrowWheel.activeSelf)
            {
                rollWheel.SetActive(true);
            }
            else
            {
                rollWheel.SetActive(false);
                savingThrowWheel.SetActive(false);
            }
        }
    }
}
