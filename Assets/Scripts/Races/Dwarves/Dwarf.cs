using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dwarf : Race
{
    public Dwarf(Character character): base(character)
    {
        maxHeight = 5;
        lifespan = 350;
        adulthoodAge = 50;
        size = "Medium";
        baseSpeed = 25;
        baseWeight = 150;
        constitutionScoreIncrease = 2;
        weaponProficiencies = new[]
        {
            "Battleaxe", "Handaxe", "LightHammer", "Warhammer"
        };
        languages = new[]
        {
            "Common", "Dwarvish"
        };
        maleNames =  new []
        {
            "Adrik", "Alberich", "Baern", "Barendd", "Brottor", "Bruenor", "Dain", "Darrak", "Delg", "Eberk", "Einkil", 
            "Fargrim", "Flint", "Gardain", "Harbek", "Kildrak", "Morgran", "Orsik", "Oskar", "Rangrim", "Rurik", 
            "Taklinn", "Thoradin", "Thorin", "Tordek", "Traubon", "Travok", "Ulfgar", "Veit", "Vondal"
        };
        femaleNames = new[]
        {
            "Amber", " Artin", " Audhild", " Bardryn", " Dagnal", " Diesa", " Eldeth", " Falkrunn", " Finellen",
            " Gunnloda", " Gurdis", " Helja", " Hlin", " Kathra", " Kristryd", " Ilde", " Liftrasa", " Mardred",
            " Riswynn", " Sann!", " Torbera", " Torgga", " Vistra"
        };
    }

    public void processSavingThrow(SavingThrow savingThrow)
    {
        if (savingThrow.against == "Poison")
        {
            savingThrow.advantage = true;
        }
    }

    public void processDamage(Damage damage)
    {
        if (damage.type == "Poison")
        {
            damage.damage /= 2;
        }
    }
}
