using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool talking = false;
    public bool paused = false;
    public DialogueController dialogueController;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InsertConversation(Dialogue conversation)
    {
        dialogueController.InsertDialogue(conversation);
    }

    public bool IsFrozen()
    {
        return paused || talking;
    }
}
