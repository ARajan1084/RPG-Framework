using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiefling : Race
{
    public Tiefling(Character character): base(character)
    {
        intelligenceScoreIncrease += 1;
        charismaScoreIncrease += 2;
        adulthoodAge = 18;
        lifespan = 85;
        maxHeight = 7;
        size = "Medium";
        baseSpeed = 30;
        baseWeight = 150;
        maleNames = new[]
        {
            "Akmenos", "Amnon", "Barakas", "Damakos", "Ekemon", "Iados", "Kairon", "Leucis", "Melech", "Mordai",
            "Morthos", "Pelaios", "Skamos", "Therai",
        };
        femaleNames = new[]
        {
            "Akta", "Anakis", "Bryseis", "Criella", "Damaia", "Ea", "Kallista", "Lerissa", "Makaria", "Nemeia",
            "Orianna", "Phelaia", "Rieta",
        };
    }

    public void processDamage(Damage damage)
    {
        if (damage.type == "fire")
        {
            damage.damage /= 2;
        }
    }
}
