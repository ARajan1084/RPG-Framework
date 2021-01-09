using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FriendshipManager : MonoBehaviour
{
    public TMP_InputField friendRequestUsernameField;
    public PlayerInformation playerInformation;
    public TMP_Text errorMessage;
    public GameObject requests;
    public GameObject friendsList;
    public GameObject friendRequestPanelPrefab;
    public GameObject friendPanelPrefab;

    void Start()
    {
        refreshFriends();
        refreshFriendRequests();
    }

    public void refreshFriends()
    {
        string playerInfo = getPlayerInfoJson();
        UnityWebRequest request = PreparePostRequest("http://127.0.0.1:8000/accounts/friends/fetch/", playerInfo);
        StartCoroutine(sendRefreshFriendsRequest(request));
    }

    IEnumerator sendRefreshFriendsRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            errorMessage.SetText("Error: " + request.error);
        }
        else
        {
            errorMessage.SetText("");
            foreach (Transform friendPanel in friendsList.transform)
            {
                Destroy(friendPanel.gameObject);
            }
            string jsonData = request.downloadHandler.text;
            PlayerInfoJson[] friends = JsonHelper.FromJson<PlayerInfoJson>(Regex.Unescape(jsonData).Trim('"').Replace(" ", ""));
            if (friends == null)
            {
                StopCoroutine(sendRefreshFriendsRequest(request));
            }
            foreach (PlayerInfoJson friend in friends)
            {
                GameObject friendPanel = Instantiate(friendPanelPrefab, friendsList.transform);
                TMP_Text[] userInfo = friendPanel.GetComponentsInChildren<TMP_Text>();
                userInfo[0].SetText(friend.username);
                userInfo[1].SetText(friend.firstName + " " + friend.lastName);
            }
        }
    }

    public void refreshFriendRequests()
    {
        string playerInfoJson = getPlayerInfoJson();
        UnityWebRequest request = PreparePostRequest("http://127.0.0.1:8000/accounts/friends/requests/fetch/", playerInfoJson);
        StartCoroutine(sendRefreshFriendRequestsRequest(request));
    }

    IEnumerator sendRefreshFriendRequestsRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            errorMessage.SetText("Error: " + request.error);
        }
        else
        {
            errorMessage.SetText("");
            foreach (Transform friendRequest in requests.transform)
            {
                GameObject.Destroy(friendRequest.gameObject);
            }
            string jsonData = request.downloadHandler.text;
            PlayerInfoJson[] friendRequests = JsonHelper.FromJson<PlayerInfoJson>(Regex.Unescape(jsonData).Trim('"').Replace(" ", ""));
            foreach (PlayerInfoJson requester in friendRequests)
            {
                GameObject friendRequestPanel = Instantiate(friendRequestPanelPrefab, requests.transform);
                TMP_Text[] userInfo = friendRequestPanel.GetComponentsInChildren<TMP_Text>();
                userInfo[0].SetText(requester.username);
                userInfo[1].SetText(requester.firstName + " " + requester.lastName);
                Button[] requestControls = friendRequestPanel.GetComponentsInChildren<Button>();
                requestControls[0].onClick.AddListener(delegate { acceptFriendRequest(requester.username);});
                requestControls[1].onClick.AddListener(delegate { declineFriendRequest(requester.username);});
            }
        }
    }

    public void acceptFriendRequest(string username)
    {
        FriendRequest fr = new FriendRequest(playerInformation.playerID, username);
        string frJson = JsonUtility.ToJson(fr);
        UnityWebRequest request = PreparePostRequest("http://127.0.0.1:8000/accounts/friends/requests/accept/", frJson);
        StartCoroutine(sendAcceptFriendRequest(request));
    }

    IEnumerator sendAcceptFriendRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            errorMessage.SetText("There was an error accepting the friend request.");
            Debug.Log(request.error);
        }
        else
        {
            errorMessage.SetText("Request accepted successfully!");
            refreshFriendRequests();
            refreshFriends();
        }
    }

    public void declineFriendRequest(string username)
    {
        FriendRequest fr = new FriendRequest(playerInformation.playerID, username);
        string frJson = JsonUtility.ToJson(fr);
        UnityWebRequest request = PreparePostRequest("http://127.0.0.1:8000/accounts/friends/requests/decline/", frJson);
        StartCoroutine(sendDeclineFriendRequest(request));
    }

    IEnumerator sendDeclineFriendRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            errorMessage.SetText("There was an error declining the friend request.");
            Debug.Log(request.error);
        }
        else
        {
            errorMessage.SetText("Friend request declined successfully.");
            refreshFriendRequests();
        }
    }

    public void addFriend()
    {
        string friendUsername = friendRequestUsernameField.text;
        FriendRequest friendRequest = new FriendRequest(playerInformation.playerID, friendUsername);
        string frJson = JsonUtility.ToJson(friendRequest);
        UnityWebRequest request = PreparePostRequest("http://127.0.0.1:8000/accounts/friends/add/", frJson);
        StartCoroutine(sendFriendRequest(request));
    }

    IEnumerator sendFriendRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            errorMessage.SetText("Error: " + request.error);
        }
        else
        {
            errorMessage.SetText("Friend request sent successfully!");
        }
    }

    UnityWebRequest PreparePostRequest(string url, string userDataJson)
    {
        var request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(userDataJson);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        return request;
    }

    private string getPlayerInfoJson()
    {
        return JsonUtility.ToJson(new PlayerInfoJson(playerInformation.playerID, 
            playerInformation.username, playerInformation.firstName, playerInformation.lastName));
    }

    private class FriendRequest
    {
        public string player_id;
        public string friend_username;
        
        public FriendRequest(string playerID, string friendUsername)
        {
            player_id = playerID;
            this.friend_username = friendUsername;
        }
    }

    [System.Serializable]
    private class FriendList
    {
        public List<PlayerInfoJson> friends;
    }
}
