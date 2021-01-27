using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Race
{
    public Character character;
    public int constitutionScoreIncrease = 0;
    public int wisdomScoreIncrease = 0;
    public int strengthScoreIncrease = 0;
    public int dexterityScoreIncrease = 0;
    public int charismaScoreIncrease = 0;
    public int intelligenceScoreIncrease = 0;
    
    public int adulthoodAge;
    public int lifespan;
    public int height;
    public int maxHeight;
    public int baseWeight;
    public string[] languages = {};
    public string[] maleNames = {};
    public string[] femaleNames = {};
    public string size;
    public int baseSpeed;
    public string[] weaponProficiencies = {};
    public string[] armorProficiencies = {};
    public string[] skillProficiencies = {};

    public Race(Character character)
    {
        this.character = character;
    }
}
