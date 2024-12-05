namespace MainApp.Dialogues;

public class InvalidOptionDialogue
{
    public void InvalidOption()
    {
        Console.Clear();
        Console.WriteLine("");
        Console.Write("Invalid option. Returning to the main menu.");
        Console.ReadKey();
    }
}
