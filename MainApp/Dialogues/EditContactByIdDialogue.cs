using Business.Interfaces;

namespace MainApp.Dialogues;

public class EditContactByIdDialogue
{
    private readonly IContactService _contactService;
    private readonly EditOrDeleteContactDialogue _editOrDelete;

    public EditContactByIdDialogue(IContactService contactService)
    {
        _contactService = contactService;
        _editOrDelete = new EditOrDeleteContactDialogue(contactService);
    }
    public void EditContactByID()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("---------- EDIT CONTACT ----------");
            Console.WriteLine("Enter the ID number of the contact you want to edit or type M to return to the main menu: ");
            var selectedId = Console.ReadLine()!;

            if (selectedId.ToUpper() == "M")
            {
                Console.Clear();
                Console.WriteLine("---------- LOADING ----------");
                Console.WriteLine("Returning to main menu...");
                Console.ReadKey();
                return;
            }

            if (int.TryParse(selectedId, out int id))
            {
                var contact = _contactService.GetContactById(id);
                if (contact != null)
                {
                    Console.Clear();
                    Console.WriteLine("---------- CONTACT FOUND SUCCESSFULLY ----------");
                    Console.WriteLine($"Contact found: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine("Is this the contact you are trying to edit? (Y/N)");
                    var option = Console.ReadLine()!;

                    switch (option.ToUpper())
                    {
                        case "Y":
                            _editOrDelete.EditOrDeleteContact(contact);
                            return;

                        case "N":
                            Console.Clear();
                            Console.WriteLine("---------- LOADING ----------");
                            Console.WriteLine("Returning to contact finder...");
                            Console.ReadKey();
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("---------- ERROR ----------");
                            Console.WriteLine("Invalid option. Please try again.");
                            Console.ReadKey();
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("---------- ERROR ----------");
                    Console.WriteLine("Contact not found. Please enter a valid ID.");
                    Console.WriteLine("If you are unsure of the ID of the contact you are trying to edit, please look at the contact list from the main menu.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("---------- ERROR ----------");
                Console.WriteLine("Invalid option, please try again.");
                Console.ReadKey();
            }
        }
    }
}
