using Domain.Models;
using MainApp.Interfaces;

namespace MainApp.Services;

public class ContactService : IContactService
{
    private List<Contact> _contacts = new List<Contact>();
    private int _nextID = 0;

    //How to create a new contact
    public void CreateContact(Contact contact)
    {
        contact.Id = ++_nextID;
        _contacts.Add(contact);
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

    public void EditContact(Contact contact)
    {

    }

    public void DeleteContact(Contact contact)
    {
        _contacts.Remove(contact);
    }
}
