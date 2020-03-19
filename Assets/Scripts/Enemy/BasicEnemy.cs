using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{
    private Damageable damageableComponent;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        RegisterComponents();
        RegisterEvents();
        //player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void Awake()
    {
    }

    private void RegisterComponents()
    {
        rb = GetComponent<Rigidbody2D>();
        damageableComponent = GetComponent<Damageable>();
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
