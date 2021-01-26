using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class CampaignManager : MonoBehaviour
{
    public GameObject homeScreen;
    public GameObject createCampaignPanel;
    public GameObject campaignsPanel;
    public GameObject campaignPanelPrefab;
    public PlayerInformation playerInformation;
    public TMP_InputField campaignNameInputField;
    public TMP_Text createCampaignPanelErrorMessage;
    public TMP_Text homeScreenErrorMessage;

    public void Start()
    {
        refreshCampaigns();
    }

    public void createCampaign()
    {
        CampaignCreationInfo campaignCreationInfo = new CampaignCreationInfo(playerInformation.playerID, campaignNameInputField.text);
        string campaignInfoJson = JsonUtility.ToJson(campaignCreationInfo);
        UnityWebRequest request = PreparePostRequest("http://127.0.0.1:8000/campaigns/new/", campaignInfoJson);
        StartCoroutine(sendCreateCampaignRequest(request));
    }

    IEnumerator sendCreateCampaignRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            createCampaignPanelErrorMessage.SetText(request.error);
        }
        else
        {
            createCampaignPanel.SetActive(false);
            homeScreen.SetActive(true);
            refreshCampaigns();
        }
    }

    public void refreshCampaigns()
    {
        string playerInfoJson = JsonUtility.ToJson(playerInformation);
        UnityWebRequest request = PreparePostRequest("http://127.0.0.1:8000/campaigns/fetch/", playerInfoJson);
        StartCoroutine(sendRefreshCampaignsRequest(request));
    }

    IEnumerator sendRefreshCampaignsRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            homeScreenErrorMessage.SetText(request.error);
        }
        else
        {
            foreach (Transform campaignPanel in campaignsPanel.transform)
            {
                Destroy(campaignPanel.gameObject);
            }
            string jsonData = request.downloadHandler.text;
            Debug.Log(Regex.Unescape(jsonData).Trim('"').Replace(" ", ""));
            CampaignInfo[] campaigns = JsonHelper.FromJson<CampaignInfo>(Regex.Unescape(jsonData).Trim('"').Replace(" ", ""));
            foreach (CampaignInfo campaign in campaigns)
            {
                GameObject campaignPanel = Instantiate(campaignPanelPrefab, campaignsPanel.transform);
                TMP_Text[] campaignInfo = campaignPanel.GetComponentsInChildren<TMP_Text>();
                campaignInfo[0].SetText(campaign.campaign_name);
                campaignInfo[1].SetText(campaign.dm_name);
            }
        }
    }

    private class CampaignCreationInfo
    {
        public string playerID;
        public string campaignName;

        public CampaignCreationInfo(string playerID, string campaignName)
        {
            this.playerID = playerID;
            this.campaignName = campaignName;
        }
    }

    [System.Serializable]
    private class CampaignInfo
    {
        public string campaign_name;
        public string campaign_description;
        public string dm_name;

        public CampaignInfo(string campaignName, string campaignDescription, string dmName)
        {
            campaign_name = campaignName;
            campaign_description = campaignDescription;
            dm_name = dmName;
        }
    }
    
    UnityWebRequest PreparePostRequest(string url, string campaignInfoJson)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(campaignInfoJson);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        return request;
    }
}
