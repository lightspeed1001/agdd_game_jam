public class Dialogue
{
    string dialogue;
    string[] choices;
    Dialogue[] consequences;
    
    public Dialogue(string text, string[] options, Dialogue[] links)
    {
        dialogue = text;
        choices = options;
        consequences = links;
    }

    public string GetText()
    {
        return dialogue;
    }

    public string[] GetChoices()
    {
        return choices;
    }
}
