using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void Heal(int amount);
    void Damage(int amount, DamageType damageType);
    void Knockback(Vector2 direction, float strength);
    void Die();
}
