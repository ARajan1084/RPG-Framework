using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollCompiler: MonoBehaviour
{
    private ArrayList temp = new ArrayList();

    void Start()
    {
        parse("4d10 + 6");
    }
    
    void parse(string input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (Char.IsDigit(input[i]) || input[i] == '+' || input[i] == '-')
            {
                temp.Add(input[i]);
            } 
            else if (input[i] == 'd')
            {
                string dice = "d";
                int j = i + 1;
                while (Char.IsDigit(input[j]))
                {
                    dice += input[j];
                    j++;
                    i++;
                }
                temp.Add(dice);
            }
            else if (input[i] == ' ')
            {
            }
            else
            {
                Debug.Log("ERROR!");
                return;
            }
        }
    }
}
