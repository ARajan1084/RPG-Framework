using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class Barbarian : Class
{
    public static readonly Dictionary<int, String> primalPath = new Dictionary<int, string>()
    {
        {0, "Berserker"},
        {1, "TotemWarrior"}
    };
    public static readonly Dictionary<int, String> totems = new Dictionary<int, string>()
    {
        {0, "Bear"},
        {1, "Eagle"},
        {2, "Wolf"}
    };
    public Barbarian(Character character): base(character)
    {
        description = "A fierce warrior of primitive background who can enter a battle rage";
        hitDie = "1d12";
        primaryAbilities = new[] {"strength"};
        savingThrowProficiencies = new[] {"strength", "constitution"};
        armorProficiencies = new[] {"LightArmor, MediumArmor, Shield, SimpleWeapon", "MartialWeapon"};
        character.classResources.Add("maxRages", 0);
        character.classResources.Add("currentRages", 0);
        character.classResources.Add("rageDamage", 0);
    }

    public void processLevelUp(Character character, string primalPath = "", string totemSpirit = "", 
        string aspectOfTheBeast = "", string abilityScoreOne = "", string abilityScoreTwo = "")
    {
        if (character.Level == 1)
        {
            character.features.Append("Rage");
            character.features.Append("UnarmoredDefense");
            character.classResources["maxRages"] = 2;
            character.classResources["currentRages"] = 2;
            character.classResources["rageDamage"] = 2;
            character.ProficiencyBonus = 2;
        }
        
        if (character.Level == 2)
        {
            character.features.Append("RecklessAttack");
            character.features.Append("DangerSense");
        }

        if (character.Level == 3)
        {
            character.classResources["maxRages"] = 3;
            character.classResources["currentRages"] += 1;
            character.features.Append("PrimalPath");
            if (primalPath == "Berserker")
            {
                character.classResources.Add("primalPath", Barbarian.primalPath.First(x => x.Value == primalPath).Key);
                character.features.Append("Frenzy");
            } 
            else if (primalPath == "TotemWarrior")
            {
                character.classResources.Add("primalPath", Barbarian.primalPath.First(x => x.Value == primalPath).Key);
                character.classResources.Add("totemSpirit", totems.First(x => x.Value == totemSpirit).Key);
                character.features.Append("SpiritSeeker");
                character.features.Append("TotemSpirit");
            }
        }

        if (character.Level == 4)
        {
            Type type = typeof(Character);
            if (abilityScoreTwo == "")
            {
                FieldInfo ability = type.GetField(abilityScoreOne);
                ability.SetValue(character, (int)ability.GetValue(character) + 2);
            }
            else
            {
                FieldInfo abilityOne = type.GetField(abilityScoreTwo);
                abilityOne.SetValue(character, (int)abilityOne.GetValue(character) + 1);
                FieldInfo abilityTwo = type.GetField(abilityScoreTwo);
                abilityOne.SetValue(character, (int)abilityTwo.GetValue(character) + 1);
            }
        }

        if (character.Level == 5)
        {
            character.ProficiencyBonus = 3;
            character.features.Append("ExtraAttack");
            character.features.Append("FastMovement");
        }

        if (character.Level == 6)
        {
            character.classResources["maxRages"] = 4;
            character.classResources["currentRages"] += 1;
            if (character.classResources["primalPath"] == 0)
            {
                character.features.Append("MindlessRage");
            } 
            else if (character.classResources["primalPath"] == 1)
            {
                character.features.Append("AspectOfTheBeast");
                character.classResources.Add("aspectOfTheBeast", totems.First(x => x.Value == aspectOfTheBeast).Key);
            }
        }
    }
}
