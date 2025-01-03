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
            .Returns(new List<Contact>());

        _contactServiceMock = new Mock<IContactService>();
        _contactService = new ContactService(fileServiceMock.Object);
    }


    [Fact]
    public void CreateContact_ShouldReturnTrue_WhenContactIsCreated()
    {
        // Arrange
        var contact = new Contact
        {
            FirstName = "John",
            LastName = "Doe",
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
        _contactServiceMock.Verify(cs => cs.CreateContact(It.IsAny<Contact>()), Times.Once);
    }


}
