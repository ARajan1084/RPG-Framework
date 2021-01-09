using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillDwarf : Dwarf
{
    public HillDwarf(Character character): base(character)
    {
        wisdomScoreIncrease = 1;
        armorProficiencies = new[] {"LightArmor", "MediumArmor"};
    }
    
    public void processLevelUp(Character character)
    {
        character.MaxHp += 1;
    }
}
