using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barbarian : Class
{
    public Barbarian()
    {
        description = "A fierce warrior of primitive background who can enter a battle rage";
        hitDie = "1d12";
        primaryAbilities = new[] {"strength"};
        savingThrowProficiencies = new[] {"strength", "constitution"};
        armorProficiencies = new[] {"LightArmor, MediumArmor, Shield, SimpleWeapon", "MartialWeapon"};
    }
}
