using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfOrc : Race
{
    public HalfOrc(Character character): base(character)
    {
        strengthScoreIncrease += 2;
        constitutionScoreIncrease += 1;
        adulthoodAge = 14;
        lifespan = 75;
        maxHeight = 7;
        size = "Medium";
        baseSpeed = 30;
        maleNames = new[]
            {"Dench", "Feng", "Gell", "Henk", "Holg", "Imsh", "Keth", "Krusk", "Mhurren", "Ront", "Shump", "Thokk"};
        femaleNames = new[]
        {
            "Baggi", "Emen", "Engong", "Kansif", "Myev", "Neega", "Ovak", "Ownka", "Shautha", "Sutha", "Vola", "Volen",
            "Yevelda"
        };
        languages = new[] {"Common", "Orc"};
    }
}
