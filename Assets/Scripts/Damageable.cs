using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    public int maxHealth;
    public int maxArmor;
    public int maxShield;
    
    public event Action OnDeath;
    public event Action OnDamageTaken;
    public static Action LiterallyAnythingDied;

    private int health, armor, shield;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        health = maxHealth;
        armor  = maxArmor;
        shield = maxShield;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Make this  unit take damage.
    /// </summary>
    /// <param name="damage">The damage value to apply. As it is right now, all damage is applied directly to health.</param>
    /// <param name="healthModifier">NOT IMPLEMENTED! Damage modifier if the damage is done directly to health.</param>
    /// <param name="shieldModifier">NOT IMPLEMENTED! Damage modifier if the damage is done to shields instead of health.</param>
    /// <param name="armorModifier">NOT IMPLEMENTED! Damage modifier if the damage is done to armor instead of health.</param>
    public void TakeDamage(int damage, float healthModifier = 1.0f, float shieldModifier = 1.0f, float armorModifier = 1.0f)
    {
        health -= damage;
        OnDamageTaken.Invoke();
        Debug.Log("I took damage!");
        if(health <= 0)
        {
            Debug.Log("I died!");
            OnDeath.Invoke();
            // if(LiterallyAnythingDied != null)
                LiterallyAnythingDied?.Invoke();
        }
    }
}
