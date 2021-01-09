using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject panel;
    public GameObject openPanelButton;
    public GameObject closePanelButton;

    public void openPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true);
        }

        if (openPanelButton != null)
        {
            openPanelButton.SetActive(false);
        }

        if (closePanelButton != null)
        {
            closePanelButton.SetActive(true);
        }
    }

    public void closePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }

        if (openPanelButton != null)
        {
            openPanelButton.SetActive(true);
        }

        if (closePanelButton != null)
        {
            closePanelButton.SetActive(false);
        }
    }
}
