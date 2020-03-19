﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseComponent : NavigationComponent
{
    public Transform chaseTarget;
    // Update is called once per frame
    protected override void Update()
    {
        destination = chaseTarget.position;
        base.Update();
    }
}
