﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Gun parent;

    // TODO add a constructor that sets all the correct variables for this bullet

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        Damageable target = other.gameObject.GetComponent<Damageable>();
        if(target)
        {
            target.TakeDamage(parent.healthDamage);
        }
        else
        {

        }
        Destroy(gameObject);
    }
}