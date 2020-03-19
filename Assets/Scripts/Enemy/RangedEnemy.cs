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
    void Start()
    {
        
    }

    private bool CanFire()
    {
        timeSinceFiring += Time.deltaTime;
        if (timeSinceFiring < fireRate)
            return false;
        timeSinceFiring = 0.0f;
        return true;
    }

    private bool CanSeeTarget()
    {
        //precompute our ray settings
        Vector3 start = transform.position;
        Vector3 direction = (target.position - transform.position).normalized;

        //draw the ray in the editor
        Debug.DrawRay(start, direction * maxRange, Color.red);

        //do the ray test
        RaycastHit2D[] sightTestResults = Physics2D.RaycastAll(start, direction, maxRange);
        bool canSeePlayer = false;
        //now iterate over all results to work out what has happened
        for (int i = 0; i < sightTestResults.Length; i++)
        {
            RaycastHit2D sightTest = sightTestResults[i];
            // Debug.Log(string.Format("Tag: {0}; i: {1}", sightTest.transform.gameObject.tag, i));
            if (sightTest.transform.gameObject.CompareTag("Enemy"))
                continue;
            if (sightTest.transform.gameObject.CompareTag("Player"))
            {
                canSeePlayer = true;
            }
            break;
            //do stuff with this result? not sure exactly what your function needs though :)
        }
        return canSeePlayer;
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanFire())
            return;

        Vector3 direction = (target.position - transform.position).normalized;
        if (CanSeeTarget())
            gun.Fire(direction);
    }
}
