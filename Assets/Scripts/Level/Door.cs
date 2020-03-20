using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ITriggerable
{
    public Vector3 delta;
    public float speed;
    public bool startsOpen = false;

    private bool isOpen;
    private bool isActive;
    private Vector3 openLocation;
    private Vector3 closedLocation;

    public override void Trigger()
    {
        isActive = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        isOpen = startsOpen;
        if(isOpen)
        {
            openLocation = transform.position;
            closedLocation = openLocation + delta;
        }
        else
        {
            closedLocation = transform.position;
            openLocation = closedLocation + delta;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            transform.position = Vector3.MoveTowards(transform.position, isOpen ? closedLocation : openLocation, speed);
            if (transform.position == (isOpen ? closedLocation : openLocation))
            {
                isActive = false;
                isOpen = !isOpen;
            }
        }
    }
}
