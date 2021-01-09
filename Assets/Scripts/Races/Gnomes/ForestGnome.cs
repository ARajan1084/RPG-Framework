using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestGnome : Gnome
{
    public ForestGnome(Character character): base(character)
    {
        dexterityScoreIncrease += 1;
    }
}
