using Data.Interfaces;
using Data.Services;
using Domain.Models;
using MainApp.Interfaces;

namespace MainApp.Services;

public class ContactService : IContactService
{
    private List<Contact> _contacts;
    private int _nextID;
    private readonly IFileService _fileService;

    // GitHub Copilot suggested this change to adhere to S in SOLID
    public ContactService(IFileService fileService)
    {
        _fileService = fileService;
        _contacts = _fileService.LoadListFromFile();
        _nextID = _contacts.Any() ? _contacts.Max(c => c.Id) : 0;
    }

    // How to create a new contact
    public void CreateContact(Contact contact)
    {
        contact.Id = ++_nextID;
        _contacts.Add(contact);
        _fileService.SaveListToFile(_contacts);
    }

    // How to list all contacts
    public IEnumerable<Contact> GetAllContacts()
    {
        return _contacts;
    }

    // How to get the contact to edit
    public Contact? GetContactById(int id)
    {
        return _contacts.FirstOrDefault(contact => contact.Id == id);
    }

    // How to edit a contact
    public void EditContact(Contact contact)
    {
        // No changes made to this method
    }

    // How to delete a contact
    public void DeleteContact(Contact contact)
    {
        _contacts.Remove(contact);
    }
}
