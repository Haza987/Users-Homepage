using Domain.Models;

namespace Business.Interfaces
{
    public interface IContactService
    {
        bool CreateContact(Contact contact);
        IEnumerable<Contact> GetAllContacts();
        Contact? GetContactById(int id);
        bool EditContact(Contact contact);
        bool DeleteContact(Contact contact);
    }
}