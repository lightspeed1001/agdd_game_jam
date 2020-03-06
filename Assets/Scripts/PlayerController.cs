using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float timeBetweenShots = 0.2f;

    private float timeSinceLastShot = 0.0f;
    private Damageable damageableComponent;
    private Rigidbody2D rb;
    private bool usingGamepad = false;

    void Start()
    {
        timeSinceLastShot = timeBetweenShots;

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
        Damageable.OnDamageTaken += OnDamageTaken;
        Damageable.OnDeath       += OnDeath;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.talking) // Can't move or fire during dialogue
        {
            Vector2 movementVector = GetMovementVector();
            movementVector *= moveSpeed;
            rb.velocity = movementVector;
            
            timeSinceLastShot += Time.deltaTime;
            if (IsFiring() &&  timeSinceLastShot >= timeBetweenShots)
            {
                timeSinceLastShot = 0.0f;
                Debug.Log("Donkey!");
                // Shooty mechanics here.
            }
        }
    }

    private Vector2 GetMovementVector()
    {
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        
        return Vector2.ClampMagnitude(move, 1);
    }

    public bool IsFiring()
    {
        return Input.GetButton("Fire") || 0 < Input.GetAxisRaw("Fire");
    }

    private void OnDeath()
    {
        // Player died, do something?
    }

    private void OnDamageTaken()
    {
        // Player took damage, do something?
    }
}
