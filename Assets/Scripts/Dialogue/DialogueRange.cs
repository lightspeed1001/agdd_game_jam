using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueRange : MonoBehaviour
{
    public GameObject interactIndicator;
    public int conversationIndex = -1;

    void Start()
    {
        interactIndicator.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController PC = other.GetComponentInParent<PlayerController>();
        if (PC == null)
            return;
        PC.interactable = this;
        interactIndicator.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        PlayerController PC = other.GetComponentInParent<PlayerController>();
        if (PC == null)
            return;
        PC.interactable = null;
        interactIndicator.SetActive(false);
    }
    public void Interact()
    {
        GameManager.instance.InsertConversation(conversationIndex);
    }
}
