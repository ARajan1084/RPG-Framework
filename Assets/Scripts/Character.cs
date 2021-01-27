using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = System.Random;

public class Character: MonoBehaviour
{
    public enum Ability
    {
        STR, DEX, CON, INT, WIS, CHA, LENGTH
    }
    public int[] abilityMod = new int[(int)Ability.LENGTH];
    public int[] abilityTotal = new int[(int)Ability.LENGTH];
    public int[] abilitySave = new int[(int)Ability.LENGTH];


    public enum Skill
    {
        ACR, ANH, ARC, ATH, DEC, HIS, INS, ITD, INV, MED, NAT, PRC, PRF, PRS, RLG, SOH, STL, SRV, LENGTH
    }
    public int[] skills = new int[(int)Skill.LENGTH];

    public string klass;
    public int level;
    public string background;
    public string playerName;
    public string race;
    public string alignment;
    public int xp;
    public int armorClass;
    public int initiative;
    public int speed;
    public int inspiration;
    public int proficiencyBonus;

    public int maxHP;
    public int currentHP;
    public int totalHitDice;
    public int currentHitDice;
    public CharacterSheetBackend characterSheet;
    public Dictionary<string, int> classResources = new Dictionary<string, int>();

    public int[,] spellSlots = new int[9, 2];
    public string[][] spells = new string[10][];

    public string[] features;

    public void updateCharacterSheet()
    {
        characterSheet.classInput.placeholder.GetComponent<Text>().text = klass;
        characterSheet.levelInput.placeholder.GetComponent<Text>().text = level.ToString();
        characterSheet.backgroudInput.placeholder.GetComponent<Text>().text = background;
        characterSheet.playerNameInput.placeholder.GetComponent<Text>().text = playerName;
        characterSheet.raceInput.placeholder.GetComponent<Text>().text = race;
        characterSheet.alignmentInput.placeholder.GetComponent<Text>().text = alignment;
        characterSheet.XPInput.placeholder.GetComponent<Text>().text = xp.ToString();
        
        characterSheet.armorClassInput.placeholder.GetComponent<Text>().text = armorClass.ToString();
        characterSheet.initiativeInput.placeholder.GetComponent<Text>().text = initiative.ToString();
        characterSheet.speedInput.placeholder.GetComponent<Text>().text = speed.ToString();
        characterSheet.inspirationInput.placeholder.GetComponent<Text>().text = inspiration.ToString();
        characterSheet.proficiencyBonusInput.placeholder.GetComponent<Text>().text = proficiencyBonus.ToString();

        updateCharSheetArray(abilityMod, characterSheet.abilityModInput);
        updateCharSheetArray(abilityTotal, characterSheet.abilityTotalInput);
        updateCharSheetArray(abilitySave, characterSheet.abilitySaveInput);
        updateCharSheetArray(skills, characterSheet.skillsInput);
        
        characterSheet.maxHPInput.placeholder.GetComponent<Text>().text = maxHP.ToString();
        characterSheet.currentHPInput.placeholder.GetComponent<Text>().text = currentHP.ToString();
        characterSheet.totalHitDiceInput.placeholder.GetComponent<Text>().text = totalHitDice.ToString();
        characterSheet.currentHitDiceInput.placeholder.GetComponent<Text>().text = currentHitDice.ToString();
    }

    public void useHitDice()
    {
        
    }

    private void updateCharSheetArray(int[] data, TMP_InputField[] inputFields)
    {
        for (int i = 0; i < inputFields.Length; i++) {
            inputFields[i].placeholder.GetComponent<Text>().text = data[i].ToString();
        }
    }
}
