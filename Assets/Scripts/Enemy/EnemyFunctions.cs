using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public static class EnemyFunctions
{
    public static bool CanSeeTarget(Transform enemy, Transform target, string targetTag, float maxRange)
    {
        //precompute our ray settings
        Vector3 start = enemy.position;
        Vector3 direction = (target.position - enemy.position).normalized;

        //draw the ray in the editor
        Debug.DrawRay(start, direction * maxRange, Color.red);

        //do the ray test
        RaycastHit2D[] sightTestResults = Physics2D.RaycastAll(start, direction, maxRange);
        bool canSeeTarget = false;
        //now iterate over all results to work out what has happened
        for (int i = 0; i < sightTestResults.Length; i++)
        {
            RaycastHit2D sightTest = sightTestResults[i];
            // Debug.Log(string.Format("Tag: {0}; i: {1}", sightTest.transform.gameObject.tag, i));
            if (sightTest.transform.gameObject.CompareTag("Enemy") || sightTest.transform.gameObject.CompareTag("EnemySightIgnore"))
                continue;
            if (sightTest.transform.gameObject.CompareTag(targetTag))
            {
                canSeeTarget = true;
            }
            break;
            //do stuff with this result? not sure exactly what your function needs though :)
        }
        return canSeeTarget;
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
