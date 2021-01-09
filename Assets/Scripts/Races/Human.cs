using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Human : Race
{
    public Human(Character character, string extraLanguage, string skillProficiency, string featProficiency): base(character)
    {
        maxHeight = 6;
        baseWeight = 150;
        adulthoodAge = 18;
        lifespan = 80;
        wisdomScoreIncrease += 1;
        intelligenceScoreIncrease += 1;
        constitutionScoreIncrease += 1;
        charismaScoreIncrease += 1;
        strengthScoreIncrease += 1;
        languages = new[] {"Common"};
        languages.Append(extraLanguage);
        skillProficiencies.Append(skillProficiency);
    }
}
