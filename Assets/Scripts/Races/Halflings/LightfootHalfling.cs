using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightfootHalfling : Halfling
{
    public LightfootHalfling(Character character): base(character)
    {
        charismaScoreIncrease += 1;
    }
}
