using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseComponent : NavigationComponent
{
    public Transform chaseTarget;

    private void Start() {
        chaseTarget = GameObject.FindWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        destination = chaseTarget.position;
        base.DoSomething();
    }
}
