using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseComponent : NavigationComponent
{
    public Transform chaseTarget;
    public float maxRoamRange = 10;

    private Vector3 lastSeen;

    protected override void Start()
    {
        base.Start();
        if(!chaseTarget)
            chaseTarget = GameManager.instance.Player.transform;
    }

    // Update is called once per frame
    protected override void Update()
    {
        if(EnemyFunctions.CanSeeTarget(transform, chaseTarget, "Player", 100))
            destination = chaseTarget.position;
        else
        {
            Vector2 moveDirection = agent.velocity.normalized;
            if (moveDirection == Vector2.zero || agent.pathStatus == UnityEngine.AI.NavMeshPathStatus.PathInvalid)
            {
                destination = EnemyFunctions.RandomNavSphere(transform.position, maxRoamRange, -1);
            }
        }
        base.Update();
    }
}
