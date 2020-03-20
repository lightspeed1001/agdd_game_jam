using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueRange : Interactable
{
    public int conversationIndex = -1;

    void Start()
    {
        interactIndicator.SetActive(false);
    }

    public override void Interact()
    {
        GameManager.instance.InsertConversation(conversationIndex);
    }
}
