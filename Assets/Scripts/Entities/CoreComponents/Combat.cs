using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Combat : CoreComponent, IDamageable
{
    [SerializeField] private int maxHealth = 5;
    [SerializeField] private int currentHealth;
    [SerializeField] DamageType[] vulnerabilities;
    private bool hitstun = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public bool Hitstun
    {
        get => hitstun;
    }

    public int CurrentHealth
    {
        get => currentHealth;
    }
    public int MaxHealth
    {
        get => maxHealth;
    }

    public void Damage(int amount, DamageType damageType)
    {
        if (vulnerabilities.Contains(damageType))
        {
            currentHealth -= amount;
            SetHitstun(true);
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }
    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
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
        currentHealth = value;
    }

    public void Die()
    {
        Debug.Log("die");
        Destroy(entity.gameObject);
    }
}
