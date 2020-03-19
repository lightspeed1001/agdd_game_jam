using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [HideInInspector]
    public float lifetime = 2.0f;
    public int healthDamage;
    public int shieldDamage;
    public int armorDamage;
    // TODO add a constructor that sets all the correct variables for this bullet


    private void Update()
    {
        if ((lifetime -= Time.deltaTime) <= 0)
        {
            Destroy(gameObject);
        }
    }

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
            target.TakeDamage(healthDamage);
        }
        else
        {

        }
        Destroy(gameObject);
    }
}
