using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxMoveSpeed = 5f;
    public float lowerMoveSpeedCap = 0.4f;
    public float shootingStaminaCost = 1;
    public DialogueRange interactable = null;
    public float timeBetweenShots = 0.2f;

    private float moveSpeed;
    private float timeSinceLastShot = 0.0f;
    private bool usingGamepad = false;

    private Vector2 movement;
    private Vector2 lookVector;

    private Camera cam;
    private Gun gun;
    private Damageable damageableComponent;
    private Rigidbody2D rb;
    private StaminaGauge staminaComponent;

    void Start()
    {
        timeSinceLastShot = timeBetweenShots;
        moveSpeed = maxMoveSpeed;
        RegisterComponents();
        RegisterEvents();
    }

    private void RegisterComponents()
    {
        rb = GetComponent<Rigidbody2D>();
        damageableComponent = GetComponent<Damageable>();
        gun = GetComponent<Gun>();
        staminaComponent = GetComponent<StaminaGauge>();
        cam = Camera.main;
    }

    private void RegisterEvents()
    {
        damageableComponent.OnDamageTaken += OnDamageTaken;
        damageableComponent.OnDeath       += OnDeath;
        staminaComponent.OnGainStamina += UpdateMovementSpeed;
        staminaComponent.OnLoseStamina += UpdateMovementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.instance.IsFrozen()) // Can't move or fire during dialogue
        {
            Vector2 movementVector = GetMovementVector();
            movementVector *= moveSpeed;
            movement = movementVector;
            lookVector = GetFacingVector();
            // rb.velocity = movementVector;
            
            // TODO update player facing

            timeSinceLastShot += Time.deltaTime;
            if (IsFiring() &&  timeSinceLastShot >= timeBetweenShots)
            {
                timeSinceLastShot = 0.0f;
                gun?.Fire();
                staminaComponent?.DrainStamina(shootingStaminaCost);
                
                // Shooty mechanics here.
                // TODO Fire in the direction the player is facing using a raycast probably
                // If the player hit something, try to get the damageable component and damage it
            }

            if (Input.GetButtonDown("Interact"))
                Interact();
        }
        else
            movement = Vector2.zero; // Stops the player if something freezes the game.
    }

    private void UpdateMovementSpeed()
    {
        float staminaPerc = staminaComponent.Stamina / staminaComponent.maxStamina;
        staminaPerc = Mathf.Max(0.4f, staminaPerc);
        moveSpeed = maxMoveSpeed * staminaPerc;
        // Debug.Log(moveSpeed);
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        // rb.velocity = movement;
        rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        if(lookVector != Vector2.zero)
        {
            float angle = GetFacingRotation(lookVector);
            rb.rotation = angle;
        }
    }

    public void Interact()
    {
        if (interactable == null)
            return;
        interactable.Interact();
    }

    private Vector2 GetMovementVector()
    {
        Vector2 move = Vector2.zero;
        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        
        return Vector2.ClampMagnitude(move, 1);
    }

    private Vector2 GetFacingVector()
    {
        if(usingGamepad)
        {
            // TODO Make an input axis for this when using a controller
            Vector2 rotation = Vector2.zero;
            rotation.x = Input.GetAxis("AimHorizontal");
            rotation.y = Input.GetAxis("AimVertical");
            return rotation;
        }
        else
        {
            return cam.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    private float GetFacingRotation(Vector2 direction)
    {
        if(usingGamepad)
        {
            float angle = Mathf.Atan2(lookVector.x, lookVector.y) * Mathf.Rad2Deg;
            return angle;
        }
        else
        {
            Vector2 lookDirection = lookVector - rb.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg + 90f;
            return angle;
        }
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
