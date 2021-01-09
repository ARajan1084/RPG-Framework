using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] rollWheels;
    private bool wheelActive = false;

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
}
