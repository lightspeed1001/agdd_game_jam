using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : BasicEnemy
{
    public Gun gun;
    public Transform target;
    public float maxRange = 100f;
    public float fireRate = 0.5f;

    private float timeSinceFiring = 0.0f;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        if (!target)
            target = GameManager.instance.Player.transform;
    }

    private bool CanFire()
    {
        timeSinceFiring += Time.deltaTime;
        if (timeSinceFiring < fireRate)
            return false;
        return true;
    }


    // Update is called once per frame
    void Update()
    {
        if (!CanFire())
            return;

        Vector3 direction = (target.position - transform.position).normalized;
        if (EnemyFunctions.CanSeeTarget(transform, target, "Player", maxRange))//  CanSeeTarget())
        {
            gun.Fire(direction);
            timeSinceFiring = 0.0f;
        }
    }
}
