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
    public TMP_InputField strengthModInput;
    public TMP_InputField dexModInput;
    public TMP_InputField conModInput;
    public TMP_InputField intelligenceModInput;
    public TMP_InputField wisdomModInput;
    public TMP_InputField charismaModInput;
    public TMP_InputField strengthInput;
    public TMP_InputField dexInput;
    public TMP_InputField conInput;
    public TMP_InputField intelligenceInput;
    public TMP_InputField wisdomInput;
    public TMP_InputField charismaInput;
    public TMP_InputField strengthSaveInput;
    public TMP_InputField dexSaveInput;
    public TMP_InputField conSaveInput;
    public TMP_InputField intelligenceSaveInput;
    public TMP_InputField wisdomSaveInput;
    public TMP_InputField charismaSaveInput;
    public TMP_InputField acrobaticsInput;
    public TMP_InputField animalHandlingInput;
    public TMP_InputField arcanaInput;
    public TMP_InputField athleticsInput;
    public TMP_InputField deceptionInput;
    public TMP_InputField historyInput;
    public TMP_InputField insightInput;
    public TMP_InputField intimidationInput;
    public TMP_InputField investigationInput;
    public TMP_InputField medicineInput;
    public TMP_InputField natureInput;
    public TMP_InputField perceptionInput;
    public TMP_InputField performanceInput;
    public TMP_InputField persuasionInput;
    public TMP_InputField religionInput;
    public TMP_InputField sleightOfHandInput;
    public TMP_InputField stealthInput;
    public TMP_InputField survivalInput;
    public TMP_InputField maxHPInput;
    public TMP_InputField currentHPInput;
    public TMP_InputField totalHitDiceInput;
    public TMP_InputField currentHitDiceInput;

    public void updateCharacter()
    {
        string classInputText = classInput.text;
        character.Klass = classInputText;

        string levelInputText = levelInput.text;
        character.Level = int.Parse(levelInputText);

        string backgroundInputText = backgroudInput.text;
        character.Backgroud = backgroundInputText;

        string playerNameInputText = playerNameInput.text;
        character.PlayerName = playerNameInputText;

        string raceInputText = raceInput.text;
        character.Race = raceInputText;
        
        string alignmentInputText = alignmentInput.text;
        character.Alignment = alignmentInputText;
        
        int XPInputValue = int.Parse(XPInput.text);
        character.Xp = XPInputValue;
        
        int armorClassInputVal = int.Parse(armorClassInput.text);
        character.ArmorClass = armorClassInputVal;
        
        int initiativeInputVal = int.Parse(initiativeInput.text);
        character.Initiative = initiativeInputVal;
        
        int speedInputVal = int.Parse(speedInput.text);
        character.Speed = speedInputVal;

        int inspiration = int.Parse(inspirationInput.text);
        character.Inspiration = inspiration;
        
        int proficiencyBonus = int.Parse(proficiencyBonusInput.text);
        character.ProficiencyBonus = proficiencyBonus;
        
        int strengthMod = int.Parse(strengthModInput.text);
        character.StrengthMod = strengthMod;
        
        int dexMod = int.Parse(dexModInput.text);
        character.DexMod = dexMod;
        
        int conMod = int.Parse(conModInput.text);
        character.ConMod = conMod;
        
        int intelligenceMod = int.Parse(intelligenceModInput.text);
        character.IntelligenceMod = intelligenceMod;
        
        int wisdomMod = int.Parse(wisdomModInput.text);
        character.WisdomMod = wisdomMod;
        
        int charismaMod = int.Parse(charismaModInput.text);
        character.CharismaMod = charismaMod;
        
        int strength = int.Parse(strengthInput.text);
        character.Strength = strength;

        int dex = int.Parse(dexInput.text);
        character.Dex = dex;

        int con = int.Parse(conInput.text);
        character.Con = con;

        int intelligence = int.Parse(intelligenceInput.text);
        character.Intelligence = intelligence;

        int wisdom = int.Parse(wisdomInput.text);
        character.Wisdom = wisdom;

        int charisma = int.Parse(charismaInput.text);
        character.Charisma = charisma;
        
        int strengthSave = int.Parse(strengthSaveInput.text);
        character.StrengthSave = strengthSave;
        
        int dexSave = int.Parse(dexSaveInput.text);
        character.DexSave = dexSave;
        
        int conSave = int.Parse(conSaveInput.text);
        character.ConSave = conSave;
        
        int intSave = int.Parse(intelligenceSaveInput.text);
        character.IntelligenceSave = intSave;
        
        int wisdomSave = int.Parse(wisdomSaveInput.text);
        character.WisdomSave = wisdomSave;
        
        int charismaSave = int.Parse(charismaSaveInput.text);
        character.CharismaSave = charismaSave;
        
        int acrobatics = int.Parse(acrobaticsInput.text);
        character.Acrobatics = acrobatics;
        
        int animalHandling = int.Parse(animalHandlingInput.text);
        character.AnimalHandling = animalHandling;
        
        int arcana = int.Parse(arcanaInput.text);
        character.Arcana = arcana;
        
        int athletics = int.Parse(athleticsInput.text);
        character.Athletics = athletics;
        
        int deception = int.Parse(deceptionInput.text);
        character.Deception = deception;
        
        int history = int.Parse(historyInput.text);
        character.History = history;
        
        int insight = int.Parse(insightInput.text);
        character.Insight = insight;
        
        int intimidation = int.Parse(intimidationInput.text);
        character.Intimidation = intimidation;
        
        int investigation = int.Parse(investigationInput.text);
        character.Investigation = investigation;
        
        int medicine = int.Parse(medicineInput.text);
        character.Medicine = medicine;
        
        int nature = int.Parse(natureInput.text);
        character.Nature = nature;
        
        int perception = int.Parse(perceptionInput.text);
        character.Perception = perception;
        
        int performance = int.Parse(performanceInput.text);
        character.Performance = performance;
        
        int persuasion = int.Parse(persuasionInput.text);
        character.Persuasion = persuasion;
        
        int religion = int.Parse(religionInput.text);
        character.Religion = religion;

        int sleightOfHand = int.Parse(sleightOfHandInput.text);
        character.SleightOfHand = sleightOfHand;
        
        int stealth = int.Parse(stealthInput.text);
        character.Stealth = stealth;
        
        int survival = int.Parse(survivalInput.text);
        character.Survival = survival;

        int maxHP = int.Parse(maxHPInput.text);
        character.MaxHp = maxHP;
        
        int currentHP = int.Parse(currentHPInput.text);
        character.CurrentHp = currentHP;

        int totalHitDice = int.Parse(totalHitDiceInput.text);
        character.TotalHitDice = totalHitDice;
        
        int currentHitDice = int.Parse(currentHitDiceInput.text);
        character.CurrentHitDice = currentHitDice;
    }

    private void updateField(InputField input)
    {
        string inputText = input.text;
    }
}
