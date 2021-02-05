using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarManager : MonoBehaviour
{
    public GameObject[] slots;
    public float inactiveAlpha = 0.1f;
    public float activeAlpha = 0.6f;
    public GameObject activeObj;

    private KeyCode[] keyCodes = new[]
    {
        KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4,
        KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Alpha0
    };

    public void Update()
    {
        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKey(keyCodes[i]))
            {
                setAlpha(slots[i], activeAlpha);
                activeObj = slots[i].GetComponent<HotbarSlot>().asset;
                for (int j = 0; j < i; j++)
                {
                    setAlpha(slots[j], inactiveAlpha);
                }

                for (int j = i + 1; j < slots.Length; j++)
                {
                    setAlpha(slots[j], inactiveAlpha);
                }
            }
        }
    }

    private void setAlpha(GameObject slot, float alphaValue)
    {
        Image image = slot.gameObject.GetComponent<Image>();
        Color c = image.color;
        c.a = alphaValue;
        image.color = c;
    }
}
