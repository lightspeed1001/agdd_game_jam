using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{
    private Damageable damageableComponent;
    public Transform player;
    public Vector3 destination;
    private Rigidbody2D rb;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        RegisterComponents();
        RegisterEvents();
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
        agent.destination = player.position;
    }
    private void OnDeath()
    {
        // Player died, do something?
    }

    private void OnDamageTaken()
    {
        // Player took damage, do something?
    }

    /// <summary>
    /// This function is called when the MonoBehaviour will be destroyed.
    /// </summary>
    void OnDestroy()
    {
        // For the love of god remember to unsubscribe from events
        damageableComponent.OnDeath -= OnDeath;
        damageableComponent.OnDamageTaken -= OnDamageTaken;
    }
}
