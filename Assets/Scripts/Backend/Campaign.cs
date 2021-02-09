using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Campaign : MonoBehaviour
{
    public string campaignID;

    public void launchCampaign()
    {
        SceneManager.LoadScene("Scenes/SceneStudio");
    }
}
