using Domain.Models;

namespace Business.Interfaces
{
    public interface IContactService
    {
        event EventHandler ContactItemsUpdated;
        bool CreateContact(ContactItem contact);
        IEnumerable<ContactItem> GetAllContacts();
        ContactItem? GetContactById(int id);
        bool EditContact(ContactItem contact);
        bool DeleteContact(ContactItem contact);
    }
}