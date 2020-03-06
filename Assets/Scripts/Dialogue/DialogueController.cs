using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public GameObject box;
    public Dialogue dial;
    public TMPro.TextMeshProUGUI dialogueText;

    void Start()
    {
        string person = "Me";
        string text = "Something";
        string[] choices = {"Continue", "Cancel"};
        dial = new Dialogue(person, text, choices, new Dialogue[] {
            new Dialogue(person, "More something", new string[] {"Exit"}, new Dialogue[] {null}),
            null});
    }

    void Update()
    {
        if (!GameManager.instance.talking)
        {
            HideBox();
            return;
        }
        if (dial != null)
            UpdateText(dial.GetText());
        else
            GameManager.instance.talking = false;
        if (Input.GetButtonDown("Interact"))
            dial = dial.MakeChoice(0);
    }

    public void HideBox()
    {
        box.SetActive(false);
    }

    public void ShowBox()
    {
        box.SetActive(true);
    }

    public void UpdateText(string text)
    {
        dialogueText.text = text;
    }
}
