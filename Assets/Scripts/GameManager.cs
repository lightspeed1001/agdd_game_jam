using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool talking = false;
    public bool paused = false;
    public DialogueController dialogueController;
    private GameObject player;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void InsertConversation(int conversationIndex)
    {
        dialogueController.InsertDialogue(conversationIndex);
    }

    public bool IsFrozen()
    {
        return paused || talking;
    }

    public GameObject Player
    {
        get { return player; }
    }
}
