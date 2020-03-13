using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaGauge : MonoBehaviour
{
    public float maxStamina;
    public float staminaRegen;
    public float regenDelay;

    private float delayTimer;
    private float stamina;

    public Action OnLoseStamina;
    public Action OnGainStamina;


    public void DrainStamina(float amount)
    {
        stamina = Mathf.Max(0, stamina - amount);
        delayTimer = regenDelay;
        OnLoseStamina?.Invoke();
    }

    public void GiveStamina(float amount)
    {
        stamina = Mathf.Min(maxStamina, stamina + staminaRegen);
        OnGainStamina?.Invoke();
    }

    // Start is called before the first frame update
    void Start()
    {
        stamina = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if(stamina < maxStamina && (delayTimer -= Time.deltaTime) <= 0)
        {
            GiveStamina(staminaRegen);
        }
    }

    public float Stamina
    {
        get { return stamina; }
    }
}
