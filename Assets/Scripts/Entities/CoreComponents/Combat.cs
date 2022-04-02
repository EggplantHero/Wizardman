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
    private int originalLayer;

    void Start()
    {
        currentHealth = maxHealth;
        originalLayer = entity.gameObject.layer;
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

    public DamageType[] Vulnerabilities
    {
        get => vulnerabilities;
    }

    public void Damage(int amount, DamageType damageType)
    {
        currentHealth -= amount;
        SetHitstun(true);
        if (currentHealth <= 0)
        {
            Die();
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

    public void SetImmuneTimed(int seconds)
    {
        StartCoroutine(IFrames(seconds));
    }

    public void SetImmune(bool value)
    {
        if (value)
        {
            SetLayerForAll(LayerMask.NameToLayer("Iframes"));
        }
        else
        {
            SetLayerForAll(originalLayer);
        }
    }

    IEnumerator IFrames(int seconds)
    {
        SetImmune(true);
        entity.GetComponent<SpriteRenderer>().color = new Color(100, 100, 100, 0.6f);
        yield return new WaitForSeconds(seconds);
        SetImmune(false);
        entity.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 1);
    }

    void SetLayerForAll(int layer)
    {
        foreach (Transform child in entity.transform.GetComponentsInChildren<Transform>())
        {
            child.gameObject.layer = layer;
        }
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
