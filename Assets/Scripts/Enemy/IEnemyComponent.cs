using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyComponent
{
    void DoSomething();
    void OnDeath();
    void OnWakeup();
}
