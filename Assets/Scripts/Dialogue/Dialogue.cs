using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Dialogue
{
    public string talker {get; set;}
    public string dialogue {get; set;}
    public List<string> choices {get; set;}
    public List<int> consequences {get; set;}
    
    public Dialogue(string person, string text, List<string> options, List<int> links)
    {
        talker = person;
        dialogue = text;
        choices = options;
        consequences = links;
    }

    public string GetPerson()
    {
        if (!string.IsNullOrEmpty(talker))
            return talker;
        return "Uknown";
    }

    public string GetText()
    {
        return dialogue;
    }

    public List<string> GetChoices()
    {
        return choices;
    }

    public int MakeChoice(int index)
    {
        return consequences[index];
    }
}
