using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int healthDamage, shieldDamage, armorDamage, initialForce;
    public GameObject bulletPrefab;
    public Transform firePoint;

    public virtual void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(firePoint.up * initialForce, ForceMode2D.Impulse);
        bullet.GetComponent<Bullet>().parent = this;
    }
}
