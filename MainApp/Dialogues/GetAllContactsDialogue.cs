using Business.Interfaces;
using Domain.Models;

namespace MainApp.Dialogues;

public class GetAllContactsDialogue(IContactService contactService)
{
    private readonly IContactService _contactService = contactService;

    public void GetAllContacts()
    {       
        var contacts = _contactService.GetAllContacts();
        DisplayAllContacts(contacts);
    }

    private void DisplayAllContacts(IEnumerable<Contact> contacts)
    {
        Console.Clear();
        Console.WriteLine("---------- ALL CONTACTS ----------");
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
                Console.WriteLine("");
                Console.WriteLine($"-----------------------------");
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