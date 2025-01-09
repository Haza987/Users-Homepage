using Data.Interfaces;
using Domain.Models;
using Business.Interfaces;

namespace Business.Services;

public class ContactService : IContactService
{
    public List<ContactItem> Contacts { get; private set; } = [];
    private int _nextID;
    private readonly IFileService _fileService;

    // GitHub Copilot suggested this change to adhere to S in SOLID
    public ContactService(IFileService fileService)
    {
        _fileService = fileService;
        Contacts = _fileService.LoadListFromFile();
        _nextID = Contacts.Any() ? Contacts.Max(c => c.Id) : 0;
    }

    // How to create a new contact
    public bool CreateContact(ContactItem contact)
    {
        try
        {
            contact.Id = ++_nextID;
            Contacts.Add(contact);
            _fileService.SaveListToFile(Contacts);
            return true;
        }
        catch
        {
            return false;
        }   
    }

    // How to list all contacts
    public IEnumerable<ContactItem> GetAllContacts()
    {
        return Contacts;
    }

    // How to get the contact to edit
    public ContactItem? GetContactById(int id)
    {
        return Contacts.FirstOrDefault(contact => contact.Id == id);
    }

    // How to edit a contact
    // GitHub Copilot helped with the logic to edit the contact.
    public bool EditContact(ContactItem contact)
    {
        try
        {
            var existingContact = Contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (existingContact != null)
            {
                existingContact.FullName = contact.FullName;
                existingContact.Email = contact.Email;
                existingContact.Phone = contact.Phone;
                existingContact.Address = contact.Address;
                existingContact.Postcode = contact.Postcode;
                existingContact.City = contact.City;
                _fileService.SaveListToFile(Contacts);
            }
            return true;
        }
        catch
        {
            return false;
        }

    }

    // How to delete a contact
    public bool DeleteContact(ContactItem contact)
    {
        try
        {
            Contacts.Remove(contact);
            _fileService.SaveListToFile(Contacts);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
