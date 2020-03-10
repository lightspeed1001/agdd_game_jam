using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public GameObject box;
    private Dialogue dial;
    public TMPro.TextMeshProUGUI text;
    public TMPro.TextMeshProUGUI person;
    public GameObject[] choices;
    private ChoiceBox[] options;
    private int choiceIndex = 0;
    private bool buttonStillDown = false;

    void Start()
    {
        options = new ChoiceBox[choices.Length];
        for (int i = 0; i < choices.Length; i++)
            options[i] = choices[i].GetComponent<ChoiceBox>();
        options[0].Choose();

        Dialogue talk = new Dialogue(
            "You",
            "\"Something\"",
            new string[] {"Continue", "Cancel"},
            new Dialogue[] {
                new Dialogue("Still You",
                    "\"More something\"",
                    new string[] {"Exit"},
                    new Dialogue[] {null}),
                null,
            }
        );
        InsertDialogue(talk);
    }

    void Update()
    {
        if (dial == null)
        {
            HideBox();
            GameManager.instance.talking = false;
            return;
        }
        else
        {
            GameManager.instance.talking = true;
            ShowBox();
        }

        int move = GetMovement();
        if (move != 0)
        {
            if (move < 0)
                PrevChoice();
            if (move > 0)
                NextChoice();
        }

        if (Input.GetButtonDown("Interact"))
            Choose();
    }

    private int GetMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        if (x != 0 && buttonStillDown)
            return 0;
        buttonStillDown = false;
        int toRet = 0;
        if (x != 0)
        {
            toRet = x < 0 ? -1 : 1; // Just need to know whether left or right.
            buttonStillDown = true;
        }
        return toRet;
    }

    public void InsertDialogue(Dialogue newDialogue)
    {
        dial = newDialogue;
        UpdateDialogue();
    }

    private void Choose()
    {
        dial = dial.MakeChoice(choiceIndex);
        if (dial != null)
            UpdateDialogue();
        NewChoice(0);
    }

    private void HideBox()
    {
        box.SetActive(false);
    }

    private void ShowBox()
    {
        box.SetActive(true);
    }

    private void UpdateDialogue()
    {
        text.text = dial.GetText();
        person.text = dial.GetPerson();
        UpdateChoices();
    }

    private void UpdateChoices()
    {
        for (int i = 0; i < dial.GetChoices().Length; i++)
            options[i].SetText(dial.GetChoices()[i]); // Put available choices into place.
        for (int i = dial.GetChoices().Length; i < options.Length; i++)
            options[i].SetText(""); // Hide unavailable choices.
    }

    private void NextChoice()
    {
        int newIndex = choiceIndex;
        if (newIndex + 1 == dial.GetChoices().Length)
            newIndex = -1;
        newIndex++;
        NewChoice(newIndex);
    }

    private void PrevChoice()
    {
        int newIndex = choiceIndex;
        if (newIndex == 0)
            newIndex = dial.GetChoices().Length;
        newIndex--;
        NewChoice(newIndex);
    }

    private void NewChoice(int index)
    {
        options[choiceIndex].Unchoose();
        choiceIndex = index;
        options[choiceIndex].Choose();
    }
}
