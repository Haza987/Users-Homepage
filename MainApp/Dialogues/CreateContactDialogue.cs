using Domain.Factories;
using Domain.Models;
using Business.Interfaces;

namespace MainApp.Dialogues;

public class CreateContactDialogue(IContactService contactService)
{
    private readonly IContactService _contactService = contactService;

    public void CreateContact()
    {
        ContactRegistrationForm contactForm = ContactFactory.Create();

        Console.Clear();
        Console.WriteLine("---------- CREATE A NEW CONTACT ----------");

        Console.Write("Enter the contact's full name: ");
        contactForm.FullName = Console.ReadLine()!;

        Console.Write("Enter the contact's email address: ");
        contactForm.Email = Console.ReadLine()!;

        Console.Write("Enter the contact's phone number: ");
        contactForm.Phone = Console.ReadLine()!;

        Console.Write("Enter the contact's street address: ");
        contactForm.Address = Console.ReadLine()!;

        Console.Write("Enter the contact's postcode: ");
        contactForm.Postcode = Console.ReadLine()!;

        Console.Write("Enter the city the contact lives in: ");
        contactForm.City = Console.ReadLine()!;

        ContactItem contact = ContactFactory.Create(contactForm);

        _contactService.CreateContact(contact);
    }
}
