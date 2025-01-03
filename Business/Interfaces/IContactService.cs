using Domain.Models;

namespace Business.Interfaces
{
    public interface IContactService
    {
        bool CreateContact(Contact contact);
        IEnumerable<Contact> GetAllContacts();
        Contact? GetContactById(int id);
        void EditContact(Contact contact);
        void DeleteContact(Contact contact);
    }
}