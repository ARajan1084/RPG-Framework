using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject rollWheel;
    public GameObject savingThrowWheel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
