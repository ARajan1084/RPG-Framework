using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnome : Race
{
    public Gnome(Character character): base(character)
    {
        intelligenceScoreIncrease += 2;
        adulthoodAge = 40;
        lifespan = 425;
        maxHeight = 4;
        baseWeight = 40;
        size = "Small";
        baseSpeed = 25;
        
        maleNames = new[]
        {
            "Alston", "Alvyn", "Boddynock", "Broce", "Burgell", "Dimble", "Eldon", "Erky", "Fonkin", "Frug", "Gerbo",
            "Gimble", "Glim", "Jebeddo", "Kellen", "Namfoodle", "Orryn", "Roondar", "Seebo", "Sindri", "Warryn",
            "Wrenn", "Zook",
        };
        femaleNames = new[]
        {
            "Bimpnottin", "Breena", "Caramip", "Carlin", "Donella", "Duvamil", "Ella", "Ellyjobell", "Ellywick",
            "Lilli", "Loopmottin", "Lorilla", "Mardnab", "Nissa", "Nyx", "Oda", "Orla", "Roywyn", "Shami!", "Tana",
            "Waywocket", "Zanna",
        };
        languages = new[] {"Common", "Gnomish"};
    }

    public void processSavingThrow(SavingThrow savingThrow)
    {
        if (savingThrow.against == "magic")
        {
            savingThrow.advantage = true;
        }
    }
}
