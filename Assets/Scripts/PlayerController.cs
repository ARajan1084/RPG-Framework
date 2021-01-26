using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] rollWheels;
    private bool wheelActive = false;

    public Vector2Int boardPos;

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.R))
        // {
        //     if (wheelActive)
        //     {
        //         foreach (GameObject wheel in rollWheels) {
        //             wheel.SetActive(false);
        //         }
        //         wheelActive = false;
        //     }
        //     else
        //     {
        //         rollWheels[0].SetActive(true);
        //         wheelActive = true;
        //     }
        // }
    }

    public void moveToBoardPos(BoardTile bt)
    {
        boardPos = bt.pos;

        moveTo(bt.transform.position.x, bt.transform.position.z);
    }

    public void moveTo(float x, float z)
    {
        transform.position = new Vector3(x, transform.position.y, z);
    }
}
