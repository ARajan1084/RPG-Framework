using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = System.Random;

public class RollParser : MonoBehaviour
{
    public static int parseRoll(string roll)
    {
        string[] components = roll.Split('d');
        int coefficient = int.Parse(components[0]);
        int modifier = 0;
        int dice = 0;
        if (components[1].Contains("+"))
        {
            string[] otherComponents = components[1].Split('+');
            modifier = int.Parse(otherComponents[1]);
            dice = int.Parse(otherComponents[0]);
        } else if (components[1].Contains("-"))
        {
            string[] otherComponents = components[1].Split('-');
            modifier = 0 - int.Parse(otherComponents[1]);
            dice = int.Parse(otherComponents[0]);
        }
        else
        {
            dice = int.Parse(components[1]);
        }
        return coefficient * UnityEngine.Random.Range(0, dice) + modifier;
    }
}
