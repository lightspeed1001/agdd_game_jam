using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueRange : MonoBehaviour
{
    public GameObject interactIndicator;
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
        GameManager.instance.InsertConversation(conversation);
    }
}
