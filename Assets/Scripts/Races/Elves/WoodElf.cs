using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WoodElf : Elf
{
    public WoodElf(Character character, string extraLanguage): base(character, extraLanguage)
    {
        wisdomScoreIncrease += 1;
        string[] localWeaponProf = {"Longsowrd", "Shortsword", "Shortbow", "Longbow"};
        foreach (string proficiency in localWeaponProf)
        {
            if (!weaponProficiencies.Contains(proficiency))
            {
                weaponProficiencies.Append(proficiency);
            }
        }

        baseSpeed = 35;
    }
}
