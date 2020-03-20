using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTrigger : Interactable
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (IsOtherPlayer(other))
        {
            Interact();
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        return;
    }
}
