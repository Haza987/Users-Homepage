using Domain.Factories;
using Domain.Models;
using MainApp.Interfaces;

namespace MainApp.Dialogues;

public class CreateContactDialogue(IContactService contactService)
{
    private readonly IContactService _contactService = contactService;

    public void CreateContact()
    {
        ContactRegistrationForm contactForm = ContactFactory.Create();

        Console.Clear();
        Console.WriteLine("---------- CREATE A NEW CONTACT ----------");

        Console.Write("Enter your first name: ");
        contactForm.FirstName = Console.ReadLine()!;

        Console.Write("Enter your last name: ");
        contactForm.LastName = Console.ReadLine()!;

        Console.Write("Enter your email address: ");
        contactForm.Email = Console.ReadLine()!;

        Console.Write("Enter your phone number: ");
        contactForm.Phone = Console.ReadLine()!;

        Console.Write("Enter your street address: ");
        contactForm.Address = Console.ReadLine()!;

        Console.Write("Enter your postcode: ");
        contactForm.Postcode = Console.ReadLine()!;

        Console.Write("Enter the city you live in: ");
        contactForm.City = Console.ReadLine()!;

        Contact contact = ContactFactory.Create(contactForm);

        _contactService.CreateContact(contact);
    }
}
