using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGnome : Gnome
{
    public RockGnome(Character character): base(character)
    {
        constitutionScoreIncrease += 1;
    }

    public void processAbilityCheck()
    {
        // TODO
    }
}
