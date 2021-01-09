using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpellCard : Card
{
    public TMP_Text castingTimeField;
    public TMP_Text durationField;
    public TMP_Text rangeField;
    public TMP_Text higherLevelsField;
    private int castingTime;
    private int duration;
    private int range;
    private bool concentration;
    private string higherLevels;
    public GameObject[] components = new GameObject[4];

    public int CastingTime
    {
        get => castingTime;
        set => castingTime = value;
    }

    public int Duration
    {
        get => duration;
        set => duration = value;
    }

    public int Range
    {
        get => range;
        set => range = value;
    }

    public bool Concentration
    {
        get => concentration;
        set => concentration = value;
    }

    public string HigherLevels
    {
        get => higherLevels;
        set => higherLevels = value;
    }
}
