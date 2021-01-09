using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfElf : Race
{
    public HalfElf(Character character, string abilityScoreChoiceOne, string abilityScoreChoiceTwo, 
        string skillProficiencyOne, string skillProficiencyTwo, string extraLanguage): base(character)
    {
        charismaScoreIncrease += 2;
        addAbilityScoreChoice(abilityScoreChoiceOne);
        addAbilityScoreChoice(abilityScoreChoiceTwo);
        adulthoodAge = 20;
        lifespan = 200;
        maxHeight = 6;
        size = "Medium";
        baseSpeed = 30;
        languages = new[] {"Common", "Elvish", extraLanguage};
    }

    public void processSavingThrow(SavingThrow savingThrow)
    {
        if (savingThrow.against == "charm")
        {
            savingThrow.advantage = true;
        }
    }

    private void addAbilityScoreChoice(string abilitySsoreChoice)
    {
        switch (abilitySsoreChoice)
        {
            case "intelligence":
                intelligenceScoreIncrease += 1;
                break;
            case "wisdom":
                wisdomScoreIncrease += 1;
                break;
            case "strength":
                strengthScoreIncrease += 1;
                break;
            case "constitution":
                constitutionScoreIncrease += 1;
                break;
            case "dexterity":
                dexterityScoreIncrease += 1;
                break;
        }
    }
}
