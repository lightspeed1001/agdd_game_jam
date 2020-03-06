using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (!GameManager.instance.talking)
            return;
    }
}
