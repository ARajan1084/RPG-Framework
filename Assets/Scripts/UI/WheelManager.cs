using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelManager : MonoBehaviour
{
    public GameObject wheel;
    public CharacterSheetBackend characterSheet;

    public void showWheel()
    {
        wheel.SetActive(true);
    }

    public void hideWheel()
    {
        wheel.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            wheel.SetActive(!wheel.activeSelf);
        }
    }

    public void useHitDice()
    {
        characterSheet.character.useHitDice();
    }
}
