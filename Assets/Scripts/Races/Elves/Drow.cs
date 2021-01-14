using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Drow : Elf
{
    public Cantrip dancingLights;
    
    public Drow(Character character, string extraLanguage) : base(character, extraLanguage)
    {
        charismaScoreIncrease += 1;
        string[] localWeaponProf = {"Rapier", "Shortsword", "HandCrossbow"};
        foreach (string proficiency in localWeaponProf)
        {
            if (!weaponProficiencies.Contains(proficiency))
            {
                weaponProficiencies.Append(proficiency);
            }
        }
    }

    public void processLevelUp(Character character)
    {
        if (character.Level == 3)
        {
            character.spells[1].Append("FaerieFire");
        }

        if (character.Level == 5)
        {
            character.spells[1].Append("Darkness");
        }
    }
}
