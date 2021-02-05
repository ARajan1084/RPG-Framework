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

    private readonly KeyCode[] keyCodes = 
    {
        KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4,
        KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Alpha0
    };

    private void Start()
    {
        setActive(0);
    }

    public void Update()
    {
        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKey(keyCodes[i]))
            {
                setActive(i);
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
    
    private void setActive(int slotIndex)
    {
        setAlpha(slots[slotIndex], activeAlpha);
        activeObj = slots[slotIndex].GetComponent<HotbarSlot>().asset;
        for (int j = 0; j < slotIndex; j++)
        {
            setAlpha(slots[j], inactiveAlpha);
        }

        for (int j = slotIndex + 1; j < slots.Length; j++)
        {
            setAlpha(slots[j], inactiveAlpha);
        }
    }
}
