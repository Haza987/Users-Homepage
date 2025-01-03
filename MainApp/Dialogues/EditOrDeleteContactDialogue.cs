using Domain.Models;
using Business.Interfaces;

namespace MainApp.Dialogues;

// GitHub Copilot helped me to carry the contact chosen by the user through this dialogue to the next dialogue.

public class EditOrDeleteContactDialogue(IContactService contactService)
{
    private readonly IContactService _contactService = contactService;
    private readonly EditContactDialogue _editContactDialogue = new EditContactDialogue(contactService);
    private readonly DeleteContactDialogue _deleteContactDialogue = new DeleteContactDialogue(contactService);

    public void EditOrDeleteContact(Contact contact)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("---------- EDIT OR DELETE CONTACT ----------");
            Console.WriteLine($"Contact: {contact.FirstName} {contact.LastName}");
            Console.WriteLine("1. Edit Contact");
            Console.WriteLine("2. Delete Contact");
            Console.WriteLine("3. Go Back");
            Console.Write("Enter your choice: ");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    _editContactDialogue.EditContact(contact);
                    return;

                case "2":
                    _deleteContactDialogue.DeleteContact(contact);
                    return;

                case "3":
                    Console.Clear();
                    Console.WriteLine("---------- LOADING ----------");
                    Console.WriteLine("Returning to main menu...");
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
}
