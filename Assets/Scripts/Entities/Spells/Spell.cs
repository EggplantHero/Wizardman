using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : Entity
{
    public SpellType spellType;
}

public enum SpellType
{
    SPELL_None,
    SPELL_Fireball,
    SPELL_Lightning,
    SPELL_Timestop,
    SPELL_Gravity,
    SPELL_Frost,
    SPELL_Haste,
}

public enum DamageType
{
    DMG_Physical,
    DMG_Fire,
    DMG_Lightning,
    DMG_Ice,
}
