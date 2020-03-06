public class Dialogue
{
    string talker;
    string dialogue;
    string[] choices;
    Dialogue[] consequences;
    
    public Dialogue(string person, string text, string[] options, Dialogue[] links)
    {
        talker = person;
        dialogue = text;
        choices = options;
        consequences = links;
    }

    public string GetPerson()
    {
        return talker;
    }

    public string GetText()
    {
        return dialogue;
    }

    public string[] GetChoices()
    {
        return choices;
    }

    public Dialogue MakeChoice(int index)
    {
        return consequences[index];
    }
}
