using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Campaign : MonoBehaviour
{
    public string campaignID;

    public void launchCampaign()
    {
        CampaignManager campaignManager = FindObjectOfType<CampaignManager>();
        campaignManager.activeCampaign = campaignID;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/SceneStudio");
    }
}
