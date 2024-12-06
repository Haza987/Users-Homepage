using Business.Models;

namespace MainApp.Interfaces
{
    public interface IContactService
    {
        void CreateContact(Contact contact);
        void EditContact(Contact contact);
        IEnumerable<Contact> GetAllContacts();
        Contact? GetContactById(int id);
    }
}