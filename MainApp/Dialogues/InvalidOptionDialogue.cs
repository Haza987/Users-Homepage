using MainApp.Interfaces;

namespace MainApp.Dialogues;

public class InvalidOptionDialogue(IContactService contactService)
{
    private IContactService contactService = contactService;

    public void InvalidOption()
    {
        Console.Clear();
        Console.WriteLine("");
        Console.Write("Invalid option. Returning to the main menu.");
        Console.ReadKey();
    }
}
