using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Dragonborn : Race
{
    public string[] childhoodNames = {"Climber", "Earbender", "Leaper", "Pious", "Shieldbiter", "Zealous"};
    public static IDictionary<string, string> draconicAncestryInfo = new Dictionary<string, string>()
    {
        {"black", "acid"},
        {"blue", "lightning"},
        {"brass", "fire"},
        {"bronze", "lightning"},
        {"copper", "acid"},
        {"gold", "fire"},
        {"green", "poison"},
        {"red", "fire"},
        {"silver", "cold"},
        {"white", "cold"}
    };
    public string ancestry;
    
    public Dragonborn(Character character, string ancestry): base(character)
    {
        this.ancestry = ancestry;
        strengthScoreIncrease += 2;
        charismaScoreIncrease += 1;
        adulthoodAge = 15;
        lifespan = 80;
        maxHeight = 7;
        baseWeight = 250;
        baseSpeed = 30;
        
        maleNames = new[]
        {
            "Arjhan", "Balasar", "Bharash", "Donaar", "Ghesh", "Heskan", "Kriv", "Medrash", "Mehen", "Nadarr",
            "Pandjed", "Patrin", "Rhogar", "Shamash", "Shedinn", "Tarhun", "Torinn"
        };
        femaleNames = new[]
        {
            "Akra", "Biri", "Daar", "Farideh", "Harann", "Havilar", "Jheri", "Kava", "Korinn", "Mishann", "Nala",
            "Perra", "Raiann", "Sora", "Surina", "Thava", "Uadjit"
        };
        languages = new[] {"Common", "Draconic"};
    }

    public void processDamage(Damage damage)
    {
        if (damage.type == draconicAncestryInfo[ancestry])
        {
            damage.damage /= 2;
        }
    }

    public class BreathWeapon : Weapon
    {
        public BreathWeapon(string ancestry)
        {
            switch (ancestry)
            {
                case "black":
                    damageType = "acid";
                    save = "dex";
                    break;
                case "blue":
                    damageType = "lightning";
                    save = "dex";
                    break;
                case "brass":
                    damageType = "fire";
                    save = "dex";
                    break;
                case "bronze":
                    damageType = "lightning";
                    save = "dex";
                    break;
                case "copper":
                    damageType = "acid";
                    save = "dex";
                    break;
                case "gold":
                    damageType = "fire";
                    save = "dex";
                    break;
                case "green":
                    damageType = "poison";
                    save = "con";
                    break;
                case "red":
                    damageType = "fire";
                    save = "dex";
                    break;
                case "silver":
                    damageType = "cold";
                    save = "con";
                    break;
                case "white":
                    damageType = "cold";
                    save = "con";
                    break;
            }
        }
    }
}
