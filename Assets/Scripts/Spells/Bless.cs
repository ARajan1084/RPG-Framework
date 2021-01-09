using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bless : SpellCard
{
    private void Start()
    {
        Title = "Bless";
        Body =
            "You bless up to three creatures of your choice within range. Whenever a target makes an attack roll" +
            " or a saving throw before the spell ends, the target can roll a d4 and add the number rolled to the" +
            " attack roll or saving throw.";
        Image = null;
        CastingTime = 0;
        Range = 30;
        Duration = 1;
        Concentration = true;
        HigherLevels = "At Higher Levels. When you cast this spell using a spell slot of 2nd level or higher, you can" +
                       " target one additional creature for each slot level above 1st.";
        
        titleField.text = Title;
        bodyField.text = Body;
        castingTimeField.text = CastingTime.ToString();
        rangeField.text = Range.ToString();
        higherLevelsField.text = HigherLevels;
        if (Concentration)
        {
            durationField.text = "Concentration up to " + Duration + " minutes";
        }
        else
        {
            durationField.text = Duration + " minutes";
        }
    }
}
