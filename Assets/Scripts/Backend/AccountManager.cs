using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UIElements;

public class AccountManager : MonoBehaviour
{
    public GameObject createAccountPanel;
    public TMP_InputField usernameInputField;
    public TMP_InputField passwordInputField;
    public TMP_InputField confirmPasswordInputField;
    public TMP_InputField firstNameInputField;
    public TMP_InputField lastNameInputField;
    public TMP_InputField emailInputField;
    public TMP_Text createAccountPanelErrorMessage;

    public GameObject loginPanel;
    public TMP_InputField loginUsernameInputField;
    public TMP_InputField loginPasswordInputField;
    public TMP_Text loginPanelErrorMessage;
    public PlayerInformation playerInformation;

    public GameObject entryScreen;
    public GameObject homeScreen;

    public void createAccount()
    {
        string username = usernameInputField.text;
        string password = passwordInputField.text;
        string confirmPassword = confirmPasswordInputField.text;
        string firstName = firstNameInputField.text;
        string lastName = lastNameInputField.text;
        string email = emailInputField.text;

        if (!validateData(username, password, confirmPassword, firstName, lastName, email))
            return;
        
        Account account = new Account(firstName, lastName, username, password, email, "");
        string accountJson = JsonUtility.ToJson(account);
        UnityWebRequest request = PreparePostRequest("http://127.0.0.1:8000/accounts/create_user/", accountJson);
        StartCoroutine(sendCreateAccountRequest(request));
    }

    IEnumerator sendCreateAccountRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            createAccountPanelErrorMessage.SetText("Error: " + request.error);
        }
        else
        {
            createAccountPanel.SetActive(false);
        }
    }

    public void login()
    {
        string username = loginUsernameInputField.text;
        string password = loginPasswordInputField.text;
        LoginInformation information = new LoginInformation(username, password);
        string infoJson = JsonUtility.ToJson(information);
        UnityWebRequest request = PreparePostRequest("http://127.0.0.1:8000/accounts/login/", infoJson);
        StartCoroutine(sendLoginRequest(request));
    }

    IEnumerator sendLoginRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            loginPanelErrorMessage.SetText("Error: " + request.error);
        }
        else
        {
            loginPanel.SetActive(false);
            string jsonData = request.downloadHandler.text;
            PlayerInfoJson playerInfoJson = JsonUtility.FromJson<PlayerInfoJson>(Regex.Unescape(jsonData).Trim('"').Replace(" ", ""));
            playerInformation.playerID = playerInfoJson.playerID;
            playerInformation.username = playerInfoJson.username;
            playerInformation.firstName = playerInfoJson.firstName;
            playerInformation.lastName = playerInfoJson.lastName;
            entryScreen.SetActive(false);
            homeScreen.SetActive(true);
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

    private bool validateData(string username, string password, string confirmPassword, string firstName, string lastName, string email)
    {
        char[] forbiddenCharacters = new char[] {'/', '?', '[', '}', '{', '}', ',', ' ', '$', '#', '!'};
        foreach (char c in forbiddenCharacters)
        {
            if (username.Contains(c.ToString()))
            {
                createAccountPanelErrorMessage.SetText("Error: Username must contain letters, digits and @/./+/-/_ only.");
                return false;
            }
        }

        if (password.Length < 8)
        {
            createAccountPanelErrorMessage.SetText("Error: Password must be at least 8 characters long.");
            return false;
        }

        if (!password.Equals(confirmPassword))
        {
            createAccountPanelErrorMessage.SetText("Error: Passwords don't match.");
            return false;
        }

        if (!isValidEmail(email))
        {
            createAccountPanelErrorMessage.SetText("Error: Invalid email address.");
            return false;
        }

        if (firstName.Length == 0 || lastName.Length == 0)
        {
            createAccountPanelErrorMessage.SetText("Error: Must provide a first and last name.");
            return false;
        }

        return true;
    }
    
    private bool isValidEmail(string email)
    {
        try {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch {
            return false;
        }
    }

    private class Account
    {
        public string first_name;
        public string last_name;
        public string username;
        public string password;
        public string email;
        public string groups;

        public Account(string firstName, string lastName, string username, string password, string email, string groups)
        {
            first_name = firstName;
            last_name = lastName;
            this.username = username;
            this.password = password;
            this.email = email;
            this.groups = groups;
        }
    }

    private class LoginInformation
    {
        public string username;
        public string password;

        public LoginInformation(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
