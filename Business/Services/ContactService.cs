using Data.Interfaces;
using Domain.Models;
using Business.Interfaces;

namespace Business.Services;

public class ContactService : IContactService
{
    private readonly List<Contact> _contacts;
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
    public bool CreateContact(Contact contact)
    {
        try
        {
            contact.Id = ++_nextID;
            _contacts.Add(contact);
            _fileService.SaveListToFile(_contacts);
            return true;
        }
        catch
        {
            return false;
        }   
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
    // GitHub Copilot helped with the logic to edit the contact.
    public bool EditContact(Contact contact)
    {
        try
        {
            var existingContact = _contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (existingContact != null)
            {
                existingContact.FirstName = contact.FirstName;
                existingContact.LastName = contact.LastName;
                existingContact.Email = contact.Email;
                existingContact.Phone = contact.Phone;
                existingContact.Address = contact.Address;
                existingContact.Postcode = contact.Postcode;
                existingContact.City = contact.City;
                _fileService.SaveListToFile(_contacts);
            }
            return true;
        }
        catch
        {
            return false;
        }

    }

    // How to delete a contact
    public bool DeleteContact(Contact contact)
    {
        try
        {
            _contacts.Remove(contact);
            _fileService.SaveListToFile(_contacts);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
