using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Class
    public string description;
    public string hitDie;
    public string[] primaryAbilities;
    public string[] savingThrowProficiencies;
    public string[] armorProficiencies;
    public string[] weaponProficiencies;
    public Character character;

    public CharacterClass(Character character)
    {
        this.character = character;
    }

    public void useHitDice(Character character)
    {
        int hpGain = RollParser.parseRoll(hitDie);
        if (character.currentHP + hpGain > character.maxHP)
        {
            character.currentHP = character.maxHP;
        }
        else
        {
            character.currentHP += hpGain;
        }
        character.updateCharacterSheet();
    }
}
