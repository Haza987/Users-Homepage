using Data.Interfaces;
using Domain.Models;
using Business.Interfaces;
using Business.Services;
using Moq;

namespace Business.Tests.Services;

public class ContactService_Tests
{
    private readonly Mock<IContactService> _contactServiceMock;
    private readonly ContactService _contactService;

    public ContactService_Tests()
    {
        var fileServiceMock = new Mock<IFileService>();
        fileServiceMock
            .Setup(fs => fs.LoadListFromFile())
            .Returns(new List<ContactItem>());

        _contactServiceMock = new Mock<IContactService>();
        _contactService = new ContactService(fileServiceMock.Object);
    }


    [Fact]
    public void CreateContact_ShouldReturnTrue_WhenContactIsCreated()
    {
        // Arrange
        var contact = new ContactItem
        {
            FullName = "John Doe",
            Email = "JohnDoe@Domain.com",
            Phone = "+46712345678",
            Address = "Väg 1",
            Postcode = "123 45",
            City = "Stockholm"
        };

        _contactServiceMock
            .Setup(cs => cs.CreateContact(contact))
            .Returns(true);

        // Act
        var result = _contactServiceMock.Object.CreateContact(contact);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void GetAllContacts_ShouldReturnListOfContacts_WhenContactsExist()
    {
        // Arrange - GitHub Copilot helped me with the arrange section of this test.

        // This creates a new list of contacts
        var list = new List<ContactItem>
        {
            new ContactItem
            {
                FullName = "John Doe",
                Email = "JohnDoe@Domain.com",
                Phone = "+46712345678",
                Address = "Väg 1",
                Postcode = "123 45",
                City = "Stockholm"
            }
        };

        // This sets up the GetAllContacts method to return the list of contacts
        _contactServiceMock
            .Setup(cs => cs.GetAllContacts())
            .Returns(list);

        // Act
        var result = _contactServiceMock.Object.GetAllContacts();

        // Assert
        Assert.Equal(list, result);
    }

    [Fact]
    public void GetContactById_ShouldReturnContact_WhenIdIsSelected()
    {
        // Arrange
        var contact = new ContactItem
        {
            Id = 1,
            FullName = "John Doe",
            Email = "JohnDoe@Domain.com",
            Phone = "+46712345678",
            Address = "Väg 1",
            Postcode = "123 45",
            City = "Stockholm"
        };

        _contactServiceMock
            .Setup(cs => cs.GetContactById(contact.Id))
            .Returns(contact);

        // Act
        var result = _contactServiceMock.Object.GetContactById(contact.Id);

        // Assert
        Assert.Equal(contact.Id, result!.Id);
    }

    [Fact]
    // GitHub Copilot helped me with parts of this test.
    public void EditContact_ShouldReturnTrue_WhenContactIsEdited()
    {
        // Arrange

        var originalContact = new ContactItem
        {
            FullName = "John Doe",
            Email = "JohnDoe@Domain.com",
            Phone = "+46712345678",
            Address = "Väg 1",
            Postcode = "123 45",
            City = "Stockholm"
        };

        var updatedContact = new ContactItem
        {
            FullName = "Harry Holmes",
            Email = "HarryHolmes@Domain.com",
            Phone = "+46787654321",
            Address = "Väg 2",
            Postcode = "543 21",
            City = "Karlskoga"
        };

        // This creates a new list of contacts
        var contacts = new List<ContactItem> { originalContact };

        // This sets up the LoadListFromFile method to return the list of contacts
        var fileServiceMock = new Mock<IFileService>();
        fileServiceMock
            .Setup(fs => fs.LoadListFromFile())
            .Returns(contacts);

        // This creates a new instance of the ContactService class
        var contactService = new ContactService(fileServiceMock.Object);

        // Act
        // This calls the EditContact method
        var result = contactService.EditContact(updatedContact);

        // Assert
        Assert.True(result);
        // This checks that the contact has been updated
        Assert.Equal(updatedContact.FullName, contactService.GetContactById(originalContact.Id)!.FullName);
        Assert.Equal(updatedContact.Email, contactService.GetContactById(originalContact.Id)!.Email);
        Assert.Equal(updatedContact.Phone, contactService.GetContactById(originalContact.Id)!.Phone);
        Assert.Equal(updatedContact.Address, contactService.GetContactById(originalContact.Id)!.Address);
        Assert.Equal(updatedContact.Postcode, contactService.GetContactById(originalContact.Id)!.Postcode);
        Assert.Equal(updatedContact.City, contactService.GetContactById(originalContact.Id)!.City);
    }

    [Fact]
    public void DeleteContact_ShouldReturnTrue_WhenContactIsDeleted()
    {
        // Arrange
        var contact = new ContactItem
        {
            FullName = "John Doe",
            Email = "JohnDoe@Domain.com",
            Phone = "+46712345678",
            Address = "Väg 1",
            Postcode = "123 45",
            City = "Stockholm"
        };

        var contacts = new List<ContactItem>{ contact };

        var fileServiceMock = new Mock<IFileService>();
        fileServiceMock
            .Setup(fs => fs.LoadListFromFile())
            .Returns(contacts);
        
        var contactService = new ContactService(fileServiceMock.Object);

        // Act
        var result = contactService.DeleteContact(contact);

        // Assert
        Assert.True(result);
        //GitHub Copilot suggested DoesNotContain.
        Assert.DoesNotContain(contact, contactService.GetAllContacts());
    }
}
