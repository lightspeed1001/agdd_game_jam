using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField]
    public List<ITriggerable> targets;
    public GameObject interactIndicator;

    public virtual void Interact()
    {
        foreach (var target in targets)
        {
            target.Trigger();
        }
    }

    protected bool IsOtherPlayer(Collider2D other)
    {
        return other.gameObject.CompareTag("Player");
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(IsOtherPlayer(other))
        {
            PlayerController PC = other.GetComponentInParent<PlayerController>();
            PC.interactable = this;
            interactIndicator.SetActive(true);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (IsOtherPlayer(other))
        {
            PlayerController PC = other.GetComponentInParent<PlayerController>();
            PC.interactable = null;
            interactIndicator.SetActive(false);
        }
    }
}
