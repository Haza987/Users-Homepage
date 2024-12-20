using Domain.Models;
using MainApp.Interfaces;

namespace MainApp.Dialogues;

public class EditContactDialogue(IContactService contactService)
{
    private IContactService _contactService = contactService;

    public void EditContact(Contact contact)
    {
        Console.Clear();
        Console.WriteLine("---------- EDIT CONTACT ----------");
        Console.WriteLine($"Current first name: {contact.FirstName}");
        Console.WriteLine("Enter new first name or leave the field blank to keep the current first name: ");
        var firstName = Console.ReadLine();
        if (!string.IsNullOrEmpty(firstName))
        {
            contact.FirstName = firstName;
        }
        Console.ReadKey();

        Console.Clear();
        Console.WriteLine("---------- EDIT CONTACT ----------");
        Console.WriteLine($"Current last name: {contact.LastName}");
        Console.WriteLine("Enter new first name or leave the field blank to keep the current first name: ");
        var lastName = Console.ReadLine();
        if (!string.IsNullOrEmpty(lastName))
        {
            contact.LastName = lastName;
        }
        Console.ReadKey();

        Console.Clear();
        Console.WriteLine("---------- EDIT CONTACT ----------");
        Console.WriteLine($"Current Email: {contact.Email}");
        Console.WriteLine("Enter new first name or leave the field blank to keep the current first name: ");
        var email = Console.ReadLine();
        if (!string.IsNullOrEmpty(email))
        {
            contact.Email = email;
        }
        Console.ReadKey();

        Console.Clear();
        Console.WriteLine("---------- EDIT CONTACT ----------");
        Console.WriteLine($"Current Phone number: {contact.Phone}");
        Console.WriteLine("Enter new first name or leave the field blank to keep the current first name: ");
        var phone = Console.ReadLine();
        if (!string.IsNullOrEmpty(phone))
        {
            contact.Phone = phone;
        }
        Console.ReadKey();

        Console.Clear();
        Console.WriteLine("---------- EDIT CONTACT ----------");
        Console.WriteLine($"Current Address: {contact.Address}");
        Console.WriteLine("Enter new first name or leave the field blank to keep the current first name: ");
        var address = Console.ReadLine();
        if (!string.IsNullOrEmpty(address))
        {
            contact.Address = address;
        }
        Console.ReadKey();

        Console.Clear();
        Console.WriteLine("---------- EDIT CONTACT ----------");
        Console.WriteLine($"Current Postcode: {contact.Postcode}");
        Console.WriteLine("Enter new first name or leave the field blank to keep the current first name: ");
        var postcode = Console.ReadLine();
        if (!string.IsNullOrEmpty(postcode))
        {
            contact.Postcode = postcode;
        }
        Console.ReadKey();

        Console.Clear();
        Console.WriteLine("---------- EDIT CONTACT ----------");
        Console.WriteLine($"Current City: {contact.City}");
        Console.WriteLine("Enter new first name or leave the field blank to keep the current first name: ");
        var city = Console.ReadLine();
        if (!string.IsNullOrEmpty(city))
        {
            contact.City = city;
        }
        Console.ReadKey();

        _contactService.EditContact(contact);

        Console.Clear();
        Console.WriteLine("---------- UPDATED CONTACT ----------");
        Console.WriteLine("Contact updated successfully! Here is the updated contact:");
        Console.WriteLine($"ID: {contact.Id}");
        Console.WriteLine($"First Name: {contact.FirstName}");
        Console.WriteLine($"Last Name: {contact.LastName}");
        Console.WriteLine($"Email: {contact.Email}");
        Console.WriteLine($"Phone: {contact.Phone}");
        Console.WriteLine($"Address: {contact.Address}");
        Console.WriteLine($"Postcode: {contact.Postcode}");
        Console.WriteLine($"City: {contact.City}");
        Console.WriteLine("");
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }
}
