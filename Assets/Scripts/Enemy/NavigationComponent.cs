using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationComponent : MonoBehaviour, IEnemyComponent
{
    public Vector3 destination;
    private NavMeshAgent agent;

    public void DoSomething()
    {
        agent.destination = destination;
    }

    public void OnDeath()
    {

    }

    public void OnWakeup()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DoSomething();
    }
}
