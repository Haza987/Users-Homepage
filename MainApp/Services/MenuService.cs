using MainApp.Dialogues;
using MainApp.Interfaces;

namespace MainApp.Services;

public class MenuService(IContactService contactService) : IMenuService
{

    private readonly InvalidOptionDialogue _invalidOptionDialogue = new(contactService);


    public void ShowMenu()
    {
        while(true)
        {
            Console.Clear();
            Console.WriteLine("---------- MAIN MENU ----------");
            Console.WriteLine("1. Create a new contact");
            Console.WriteLine("2. List all contacts");
            Console.WriteLine("3. Edit contacts");
            Console.WriteLine("E. Exit");
            Console.WriteLine("------------------------------");
            Console.Write("Choose an option: ");
            var option = Console.ReadLine()!;

            switch (option.ToUpper())
            {
                case "1":
                    //CreateContact();
                    break;

                case "2":
                    //GatAllContacts();
                    break;

                case "3":
                    //EditContact();
                    break;

                case "E":
                    ExitApp();
                    break;

                default:
                    _invalidOptionDialogue.InvalidOption();
                    break;
            }
        }
    }

    public void ExitApp()
    {
        Console.Clear();
        Console.WriteLine("-------- QUIT APPLICATION --------\n");
        Console.Write("Are you sure you want to exit? (Y/N): ");
        var option = Console.ReadLine()!;

        if (option.ToUpper() == "Y")
        {
            Environment.Exit(0);
        }
    }
}
