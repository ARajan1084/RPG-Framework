using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSheetBackend: MonoBehaviour
{
    public Character character;
    public TMP_InputField classInput;
    public TMP_InputField levelInput;
    public TMP_InputField backgroudInput;
    public TMP_InputField playerNameInput;
    public TMP_InputField raceInput;
    public TMP_InputField alignmentInput;
    public TMP_InputField XPInput;
    public TMP_InputField armorClassInput;
    public TMP_InputField initiativeInput;
    public TMP_InputField speedInput;
    public TMP_InputField inspirationInput;
    public TMP_InputField proficiencyBonusInput;

    //TODO: Establish internal link between inputs and data
    public TMP_InputField[] abilityModInput = new TMP_InputField[(int)Character.Ability.LENGTH];
    public TMP_InputField[] abilityTotalInput = new TMP_InputField[(int)Character.Ability.LENGTH];
    public TMP_InputField[] abilitySaveInput = new TMP_InputField[(int)Character.Ability.LENGTH];

    public TMP_InputField[] skillsInput = new TMP_InputField[(int)Character.Skill.LENGTH];

    public TMP_InputField maxHPInput;
    public TMP_InputField currentHPInput;
    public TMP_InputField totalHitDiceInput;
    public TMP_InputField currentHitDiceInput;

    public void updateCharacter()
    {
        character.klass = classInput.text;
        character.level = int.Parse(levelInput.text);
        character.background = backgroudInput.text;
        character.playerName = playerNameInput.text;
        character.race = raceInput.text;
        character.alignment = alignmentInput.text;
        character.xp = int.Parse(XPInput.text);
        character.armorClass = int.Parse(armorClassInput.text);
        character.initiative = int.Parse(initiativeInput.text);
        character.speed = int.Parse(speedInput.text);
        character.inspiration = int.Parse(inspirationInput.text);
        character.proficiencyBonus = int.Parse(proficiencyBonusInput.text);

        updateArrays(character.abilityMod, abilityModInput);
        updateArrays(character.abilityTotal, abilityTotalInput);
        updateArrays(character.abilitySave, abilitySaveInput);
        updateArrays(character.skills, skillsInput);
        
        character.maxHP = int.Parse(maxHPInput.text);
        character.currentHP = int.Parse(currentHPInput.text);
        character.totalHitDice = int.Parse(totalHitDiceInput.text);
        character.currentHitDice = int.Parse(currentHitDiceInput.text);
    }

    private void updateArrays(int[] data, TMP_InputField[] inputFields)
    {
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = int.Parse(inputFields[i].text);
        }
    }

    private void updateField(InputField input)
    {
        string inputText = input.text;
    }
}
