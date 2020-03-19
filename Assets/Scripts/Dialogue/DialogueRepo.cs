using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueRepo : MonoBehaviour
{
    public TextAsset dialogueFile;
    private Dialogue dialogue;

    // Start is called before the first frame update
    void Awake()
    {
        string s = dialogueFile.ToString();
        print(s);
        dialogue = JsonUtility.FromJson<Dialogue>(s);
        print(dialogue.GetPerson());
        print(JsonUtility.ToJson(dialogue));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Dialogue GetDialogue(int index)
    {
        //if (index == -1 || index >= dialogue.Length)
        //    return null;
        //return dialogue[index];
        return dialogue;
    }
}
