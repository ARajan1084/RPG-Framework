using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerInfoJson
{
    public string playerID;
    public string username;
    public string firstName;
    public string lastName;

    public PlayerInfoJson(string playerID, string username, string firstName, string lastName)
    {
        this.playerID = playerID;
        this.username = username;
        this.firstName = firstName;
        this.lastName = lastName;
    }
}
