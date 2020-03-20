using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueRange : Interactable
{
    public Dialogue conversation = null;

    void Start()
    {
        interactIndicator.SetActive(false);
        conversation = new Dialogue(
            "You",
            "The experiment was a success!",
            new List<string> {"Alright", "Good News!", "Sucks"},
            new List<int> {-1, -1, -1}
        );
    }

    public override void Interact()
    {
        GameManager.instance.InsertConversation(conversation);
    }
}
