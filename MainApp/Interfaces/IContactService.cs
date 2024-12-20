using Domain.Models;

namespace MainApp.Interfaces
{
    public interface IContactService
    {
        void CreateContact(Contact contact);
        IEnumerable<Contact> GetAllContacts();
        Contact? GetContactById(int id);
        void EditContact(Contact contact);
        void DeleteContact(Contact contact);
    }
}