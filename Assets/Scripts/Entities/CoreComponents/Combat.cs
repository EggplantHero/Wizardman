using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Combat : CoreComponent, IDamageable
{
    [SerializeField] private int health = 5;
    [SerializeField] DamageType[] vulnerabilities;
    private bool hitstun = false;

    public bool Hitstun
    {
        get => hitstun;
    }

    public int Health
    {
        get => health;
    }

    public void Damage(int amount, DamageType damageType)
    {
        if (vulnerabilities.Contains(damageType))
        {
            health -= amount;
            SetHitstun(true);
            if (health <= 0)
            {
                Die();
            }
        }
    }

    public void Knockback(Vector2 direction, float strength)
    {
        entity.movement.AddKnockback(direction, strength);
    }

    public void SetHitstun(bool value)
    {
        hitstun = value;
    }

    public void SetHealth(int value)
    {
        health = value;
    }

    public void Die()
    {
        Debug.Log("die");
        Destroy(entity.gameObject);
    }
}
