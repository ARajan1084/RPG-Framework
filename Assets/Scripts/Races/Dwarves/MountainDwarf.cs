using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainDwarf : Dwarf
{
    public MountainDwarf(Character character): base(character)
    {
        strengthScoreIncrease = 2;
    }
}
