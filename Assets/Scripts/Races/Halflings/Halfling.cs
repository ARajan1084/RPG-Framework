using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Halfling : Race
{
    public Halfling(Character character): base(character)
    {
        dexterityScoreIncrease += 2;
        adulthoodAge = 20;
        lifespan = 150;
        maxHeight = 3;
        baseWeight = 40;
        size = "Small";
        baseSpeed = 25;
        languages = new[] {"Common", "Halfing"};
    }

    public void processRoll(int type, int result)
    {
        if (type == 20 && result == 1)
        {
            // reroll the dice
        }
    }

    public virtual void processSavingThrow(SavingThrow savingThrow)
    {
        if (savingThrow.against == "Fright")
        {
            savingThrow.advantage = true;
        }
    }
}
