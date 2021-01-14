using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public abstract class Character: MonoBehaviour
{
    private string klass;
    private int level;
    private string backgroud;
    private string playerName;
    private string race;
    private string alignment;
    private int XP;
    private int armorClass;
    private int initiative;
    private int speed;
    private int inspiration;
    private int proficiencyBonus;
    private int strengthMod;
    private int dexMod;
    private int conMod;
    private int intelligenceMod;
    private int wisdomMod;
    private int charismaMod;
    private int strength;
    private int dex;
    private int con;
    private int intelligence;
    private int wisdom;
    private int charisma;
    private int strengthSave;
    private int dexSave;
    private int conSave;
    private int intelligenceSave;
    private int wisdomSave;
    private int charismaSave;
    private int acrobatics;
    private int animalHandling;
    private int arcana;
    private int athletics;
    private int deception;
    private int history;
    private int insight;
    private int intimidation;
    private int investigation;
    private int medicine;
    private int nature;
    private int perception;
    private int performance;
    private int persuasion;
    private int religion;
    private int sleightOfHand;
    private int stealth;
    private int survival;
    private int maxHP;
    private int currentHP;
    private int totalHitDice;
    private int currentHitDice;
    public CharacterSheetBackend characterSheet;
    public Dictionary<string, int> classResources = new Dictionary<string, int>();

    private int[,] spellSlots = new int[9, 2];
    public string[][] spells = new string[10][];

    public string[] features;

    public void updateCharacterSheet()
    {
        characterSheet.classInput.placeholder.GetComponent<Text>().text = klass;
        characterSheet.levelInput.placeholder.GetComponent<Text>().text = level.ToString();
        characterSheet.backgroudInput.placeholder.GetComponent<Text>().text = backgroud;
        characterSheet.playerNameInput.placeholder.GetComponent<Text>().text = playerName;
        characterSheet.raceInput.placeholder.GetComponent<Text>().text = race;
        characterSheet.alignmentInput.placeholder.GetComponent<Text>().text = alignment;
        characterSheet.XPInput.placeholder.GetComponent<Text>().text = XP.ToString();
        
        characterSheet.armorClassInput.placeholder.GetComponent<Text>().text = armorClass.ToString();
        characterSheet.initiativeInput.placeholder.GetComponent<Text>().text = initiative.ToString();
        characterSheet.speedInput.placeholder.GetComponent<Text>().text = speed.ToString();
        characterSheet.inspirationInput.placeholder.GetComponent<Text>().text = inspiration.ToString();
        characterSheet.proficiencyBonusInput.placeholder.GetComponent<Text>().text = proficiencyBonus.ToString();
        
        characterSheet.strengthModInput.placeholder.GetComponent<Text>().text = strengthMod.ToString();
        characterSheet.conModInput.placeholder.GetComponent<Text>().text = conMod.ToString();
        characterSheet.intelligenceModInput.placeholder.GetComponent<Text>().text = intelligenceMod.ToString();
        characterSheet.wisdomModInput.placeholder.GetComponent<Text>().text = wisdomMod.ToString();
        characterSheet.charismaModInput.placeholder.GetComponent<Text>().text = charismaMod.ToString();
        
        characterSheet.strengthInput.placeholder.GetComponent<Text>().text = strength.ToString();
        characterSheet.dexInput.placeholder.GetComponent<Text>().text = dex.ToString();
        characterSheet.conInput.placeholder.GetComponent<Text>().text = con.ToString();
        characterSheet.intelligenceInput.placeholder.GetComponent<Text>().text = intelligence.ToString();
        characterSheet.wisdomInput.placeholder.GetComponent<Text>().text = wisdom.ToString();
        characterSheet.charismaInput.placeholder.GetComponent<Text>().text = charisma.ToString();
        
        characterSheet.dexSaveInput.placeholder.GetComponent<Text>().text = dexSave.ToString();
        characterSheet.conSaveInput.placeholder.GetComponent<Text>().text = conSave.ToString();
        characterSheet.intelligenceSaveInput.placeholder.GetComponent<Text>().text = intelligenceSave.ToString();
        characterSheet.wisdomSaveInput.placeholder.GetComponent<Text>().text = wisdomSave.ToString();
        characterSheet.charismaSaveInput.placeholder.GetComponent<Text>().text = charismaSave.ToString();

        characterSheet.acrobaticsInput.placeholder.GetComponent<Text>().text = acrobatics.ToString();
        characterSheet.animalHandlingInput.placeholder.GetComponent<Text>().text = animalHandling.ToString();
        characterSheet.arcanaInput.placeholder.GetComponent<Text>().text = arcana.ToString();
        characterSheet.athleticsInput.placeholder.GetComponent<Text>().text = athletics.ToString();
        characterSheet.deceptionInput.placeholder.GetComponent<Text>().text = deception.ToString();
        characterSheet.historyInput.placeholder.GetComponent<Text>().text = history.ToString();
        characterSheet.insightInput.placeholder.GetComponent<Text>().text = insight.ToString();
        characterSheet.intimidationInput.placeholder.GetComponent<Text>().text = intimidation.ToString();
        characterSheet.investigationInput.placeholder.GetComponent<Text>().text = investigation.ToString();
        characterSheet.medicineInput.placeholder.GetComponent<Text>().text = nature.ToString();
        characterSheet.natureInput.placeholder.GetComponent<Text>().text = medicine.ToString();
        characterSheet.perceptionInput.placeholder.GetComponent<Text>().text = perception.ToString();
        characterSheet.performanceInput.placeholder.GetComponent<Text>().text = performance.ToString();
        characterSheet.persuasionInput.placeholder.GetComponent<Text>().text = persuasion.ToString();
        characterSheet.religionInput.placeholder.GetComponent<Text>().text = religion.ToString();
        characterSheet.sleightOfHandInput.placeholder.GetComponent<Text>().text = sleightOfHand.ToString();
        characterSheet.stealthInput.placeholder.GetComponent<Text>().text = stealth.ToString();
        characterSheet.survivalInput.placeholder.GetComponent<Text>().text = survival.ToString();
        
        characterSheet.maxHPInput.placeholder.GetComponent<Text>().text = maxHP.ToString();
        characterSheet.currentHPInput.placeholder.GetComponent<Text>().text = currentHP.ToString();
        characterSheet.totalHitDiceInput.placeholder.GetComponent<Text>().text = totalHitDice.ToString();
        characterSheet.currentHitDiceInput.placeholder.GetComponent<Text>().text = currentHitDice.ToString();
    }

    public void useHitDice()
    {
        
    }

    public string Klass
    {
        get => klass;
        set => klass = value;
    }

    public int Level
    {
        get => level;
        set => level = value;
    }

    public string Backgroud
    {
        get => backgroud;
        set => backgroud = value;
    }

    public string PlayerName
    {
        get => playerName;
        set => playerName = value;
    }

    public string Race
    {
        get => race;
        set => race = value;
    }

    public string Alignment
    {
        get => alignment;
        set => alignment = value;
    }

    public int Xp
    {
        get => XP;
        set => XP = value;
    }

    public int ArmorClass
    {
        get => armorClass;
        set => armorClass = value;
    }

    public int Initiative
    {
        get => initiative;
        set => initiative = value;
    }

    public int Speed
    {
        get => speed;
        set => speed = value;
    }

    public int Inspiration
    {
        get => inspiration;
        set => inspiration = value;
    }

    public int ProficiencyBonus
    {
        get => proficiencyBonus;
        set => proficiencyBonus = value;
    }

    public int StrengthMod
    {
        get => strengthMod;
        set => strengthMod = value;
    }

    public int DexMod
    {
        get => dexMod;
        set => dexMod = value;
    }

    public int ConMod
    {
        get => conMod;
        set => conMod = value;
    }

    public int IntelligenceMod
    {
        get => intelligenceMod;
        set => intelligenceMod = value;
    }

    public int WisdomMod
    {
        get => wisdomMod;
        set => wisdomMod = value;
    }

    public int CharismaMod
    {
        get => charismaMod;
        set => charismaMod = value;
    }

    public int Strength
    {
        get => strength;
        set => strength = value;
    }

    public int Dex
    {
        get => dex;
        set => dex = value;
    }

    public int Con
    {
        get => con;
        set => con = value;
    }

    public int Intelligence
    {
        get => intelligence;
        set => intelligence = value;
    }

    public int Wisdom
    {
        get => wisdom;
        set => wisdom = value;
    }

    public int Charisma
    {
        get => charisma;
        set => charisma = value;
    }

    public int StrengthSave
    {
        get => strengthSave;
        set => strengthSave = value;
    }

    public int DexSave
    {
        get => dexSave;
        set => dexSave = value;
    }

    public int ConSave
    {
        get => conSave;
        set => conSave = value;
    }

    public int IntelligenceSave
    {
        get => intelligenceSave;
        set => intelligenceSave = value;
    }

    public int WisdomSave
    {
        get => wisdomSave;
        set => wisdomSave = value;
    }

    public int CharismaSave
    {
        get => charismaSave;
        set => charismaSave = value;
    }

    public int Acrobatics
    {
        get => acrobatics;
        set => acrobatics = value;
    }

    public int AnimalHandling
    {
        get => animalHandling;
        set => animalHandling = value;
    }

    public int Arcana
    {
        get => arcana;
        set => arcana = value;
    }

    public int Athletics
    {
        get => athletics;
        set => athletics = value;
    }

    public int Deception
    {
        get => deception;
        set => deception = value;
    }

    public int History
    {
        get => history;
        set => history = value;
    }

    public int Insight
    {
        get => insight;
        set => insight = value;
    }

    public int Intimidation
    {
        get => intimidation;
        set => intimidation = value;
    }

    public int Investigation
    {
        get => investigation;
        set => investigation = value;
    }

    public int Medicine
    {
        get => medicine;
        set => medicine = value;
    }

    public int Nature
    {
        get => nature;
        set => nature = value;
    }

    public int Perception
    {
        get => perception;
        set => perception = value;
    }

    public int Performance
    {
        get => performance;
        set => performance = value;
    }

    public int Persuasion
    {
        get => persuasion;
        set => persuasion = value;
    }

    public int Religion
    {
        get => religion;
        set => religion = value;
    }

    public int SleightOfHand
    {
        get => sleightOfHand;
        set => sleightOfHand = value;
    }

    public int Stealth
    {
        get => stealth;
        set => stealth = value;
    }

    public int Survival
    {
        get => survival;
        set => survival = value;
    }

    public int MaxHp
    {
        get => maxHP;
        set => maxHP = value;
    }

    public int CurrentHp
    {
        get => currentHP;
        set => currentHP = value;
    }

    public int TotalHitDice
    {
        get => totalHitDice;
        set => totalHitDice = value;
    }

    public int CurrentHitDice
    {
        get => currentHitDice;
        set => currentHitDice = value;
    }
}
