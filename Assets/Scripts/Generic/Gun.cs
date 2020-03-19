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
        FixBullet(bullet);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(firePoint.up * initialForce, ForceMode2D.Impulse);

        // TODO instead of having the prefab include a bullet component, add the component here.
        // That way, we can have different bullet types.
        // Also, each gun subclass should override this function if they want to do something fancy
    }

    public virtual void Fire(Vector3 direction)
    {
        Vector3 dir = -direction;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.AngleAxis(angle, Vector3.forward));
        FixBullet(bullet);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(direction * initialForce, ForceMode2D.Impulse);

    }

    protected virtual void FixBullet(GameObject bullet)
    {
        Bullet b = bullet.GetComponent<Bullet>();
        b.healthDamage = healthDamage;
        b.shieldDamage = shieldDamage;
        b.armorDamage = armorDamage;
        bullet.layer = gameObject.layer + 1;
    }
}
