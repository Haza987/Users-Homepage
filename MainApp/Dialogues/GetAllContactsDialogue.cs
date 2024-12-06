using MainApp.Interfaces;

namespace MainApp.Dialogues;

public class GetAllContactsDialogue(IContactService contactService)
{
    private readonly IContactService _contactService = contactService;

    public void GetAllContacts()
    {
        Console.Clear();
        Console.WriteLine("---------- ALL CONTACTS ----------");
        var contacts = _contactService.GetAllContacts();
        if (contacts.Any())
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"ID: {contact.Id}");
                Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine($"Phone: {contact.Phone}");
                Console.WriteLine($"Address: {contact.Address}");
                Console.WriteLine($"Postcode: {contact.Postcode}");
                Console.WriteLine($"City: {contact.City}");
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No contacts found.");
        }
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }
}