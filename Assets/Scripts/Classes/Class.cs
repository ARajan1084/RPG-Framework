using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Class : MonoBehaviour
{
    public string description;
    public string hitDie;
    public string[] primaryAbilities;
    public string[] savingThrowProficiencies;
    public string[] armorProficiencies;
    public string[] weaponProficiencies;

    public void useHitDice(Character character)
    {
        int hpGain = RollParser.parseRoll(hitDie);
        if (character.CurrentHp + hpGain > character.MaxHp)
        {
            character.CurrentHp = character.MaxHp;
        }
        else
        {
            character.CurrentHp += hpGain;
        }
        character.updateCharacterSheet();
    }
}
