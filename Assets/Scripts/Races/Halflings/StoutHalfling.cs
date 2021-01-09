using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoutHalfling : Halfling
{
    public StoutHalfling(Character character): base(character)
    {
        constitutionScoreIncrease += 1;
    }

    public override void processSavingThrow(SavingThrow savingThrow)
    {
        if (savingThrow.against == "Poison")
        {
            savingThrow.advantage = true;
        }
        base.processSavingThrow(savingThrow);
    }

    public void processDamage(Damage damage)
    {
        if (damage.type == "Poison")
        {
            damage.damage /= 2;
        }
    }
}
