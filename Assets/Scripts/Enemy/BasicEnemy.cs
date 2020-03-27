using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{
    private Damageable damageableComponent;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    protected virtual void Awake()
    {
        RegisterComponents();
        RegisterEvents();
    }

    protected virtual void RegisterComponents()
    {
        damageableComponent = GetComponent<Damageable>();
    }

    protected virtual void RegisterEvents()
    {
        if(damageableComponent)
        {
            damageableComponent.OnDamageTaken += OnDamageTaken;
            damageableComponent.OnDeath       += OnDeath;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected virtual void OnDeath()
    {
        // Enemy died, do something?
        Destroy(gameObject);
    }

    protected virtual void OnDamageTaken()
    {
        // Enemy took damage, do something?
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    protected virtual void OnDestroy()
    {
        // For the love of god remember to unsubscribe from events
        if(damageableComponent)
        {
            damageableComponent.OnDeath -= OnDeath;
            damageableComponent.OnDamageTaken -= OnDamageTaken;
        }
    }
}
