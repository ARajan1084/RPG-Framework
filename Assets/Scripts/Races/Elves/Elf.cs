using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Elf : Race
{
    public Cantrip cantrip;
    public string[] childNames = 
    {
        "Ara", "Bryn", "Del", "Eryn", "Faen", "Innil", "Lael", "Mella", "Naill", "Naeris", "Phann", "Rael", "Rinn",
        "Sai", "Syllin", "Thia", "Vall"
    };
    
    public Elf(Character character, string extraLanguage): base(character)
    {
        dexterityScoreIncrease = 2;
        maxHeight = 6;
        baseWeight = 100;
        lifespan = 750;
        adulthoodAge = 100;
        size = "Medium";
        baseSpeed = 30;
        if (!skillProficiencies.Contains("Perception"))
        {
            skillProficiencies.Append("Perception");
        }

        maleNames = new[]
        {
            "Adran", " Aelar", " Aramil", " Arannis", " Aust", " Beiro", " Berrian", " Carrie", " Enialis", " Erdan",
            " Erevan", " Galinndan", " Hadarai", " Heian", " Himo", " Immeral", " Ivellios", " Laucian", " Mindartis",
            " Paelias", " Peren", " Quarion", " Riardon", " Rolen", " Soveliss", " Thamior", " Tharivol", " Theren",
            " Varis"
        };
        femaleNames = new[]
        {
            "Adrie", "Althaea", "Anastrianna", "Andraste", "Antinua", "Bethrynna", "Birel", "Caelynn", "Drusilia",
            "Enna", "Felosial", "Ielenia", "Jelenneth", "Keyleth", "Leshanna", "Lia", "Meriele", "Mialee", "Naivara",
            "Quelenna", "Quillathe", "Sariel", "Shanairra", "Shava", "Silaqui", "Theirastra", "Thia", "Vadania",
            "Valanthe", "Xanaphia"
        };
        languages.Append(extraLanguage);
    }

    public void processSavingThrow(SavingThrow savingThrow)
    {
        if (savingThrow.against == "Charm")
        {
            savingThrow.advantage = true;
        }
    }
}
