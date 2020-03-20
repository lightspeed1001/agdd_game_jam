using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class DialogueList
{
    public List<Dialogue> list;

    public DialogueList(List<Dialogue> dialogueList)
    {
        list = dialogueList;
    }

    public Dialogue GetDialogue(int index)
    {
        if (index == -1)
            return null;
        return list[index];
    }
}
