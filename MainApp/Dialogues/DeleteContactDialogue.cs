using Domain.Models;
using Business.Interfaces;

namespace MainApp.Dialogues;

public class DeleteContactDialogue(IContactService contactService)
{
    private readonly IContactService _contactService = contactService;
    public void DeleteContact(ContactItem contact)
    {
        Console.Clear();
        Console.WriteLine("---------- DELETE CONTACT ----------");
        Console.WriteLine($"Contact: {contact.FullName}");
        Console.WriteLine("Are you sure you want to delete this contact? (Y/N)");
        var option = Console.ReadLine()!;

        switch (option.ToUpper())
        {
            case "Y":
                Console.Clear();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Contact deleted successfully. Returning to main menu...");
                _contactService.DeleteContact(contact);
                Console.ReadKey();
                return;

            case "N":
                Console.Clear();
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Contact not deleted. Returning to main menu...");
                Console.ReadKey();
                return;
            
            default:
                Console.Clear();
                Console.WriteLine("---------- ERROR ----------");
                Console.WriteLine("Invalid choice. Please try again.");
                Console.ReadKey();
                break;
        }
    }
}
