using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueRepo : MonoBehaviour
{
    public TextAsset dialogueFile;
    private DialogueList dialogues;

    // Start is called before the first frame update
    void Awake()
    {
        string s = dialogueFile.ToString();
        dialogues = JsonUtility.FromJson<DialogueList>(s);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Dialogue GetDialogue(int index)
    {
        return dialogues.GetDialogue(index);
    }
}
