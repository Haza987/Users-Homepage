using Domain.Models;

// I created this file so that the changes suggested by GitHub Copilot in ContactService would function correctly.
namespace Data.Interfaces
{
    public interface IFileService
    {
        List<Contact> LoadListFromFile();
        void SaveListToFile(List<Contact> list);
    }
}