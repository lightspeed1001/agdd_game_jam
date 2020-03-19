﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{
    private Damageable damageableComponent;
    private Rigidbody2D rb;
    private List<IEnemyComponent> enemyComponents;

    // Start is called before the first frame update
    void Start()
    {
        RegisterComponents();
        RegisterEvents();
        foreach (var comp in enemyComponents)
        {
            comp.OnWakeup();
        }
        //player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void Awake()
    {
    }

    private void RegisterComponents()
    {
        rb = GetComponent<Rigidbody2D>();
        damageableComponent = GetComponent<Damageable>();
        enemyComponents = new List<IEnemyComponent>();
        enemyComponents.AddRange(GetComponents<IEnemyComponent>());
    }

    private void RegisterEvents()
    {
        damageableComponent.OnDamageTaken += OnDamageTaken;
        damageableComponent.OnDeath       += OnDeath;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDeath()
    {
        // Enemy died, do something?
        foreach (var comp in enemyComponents)
        {
            comp.OnDeath();
        }
        Destroy(gameObject);
    }

    private void OnDamageTaken()
    {
        // Enemy took damage, do something?
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        // For the love of god remember to unsubscribe from events
        if(damageableComponent)
        {
            damageableComponent.OnDeath -= OnDeath;
            damageableComponent.OnDamageTaken -= OnDamageTaken;
        }
    }
}