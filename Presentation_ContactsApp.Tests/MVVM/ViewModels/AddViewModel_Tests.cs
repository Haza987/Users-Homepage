using Business.Interfaces;
using Data.Interfaces;
using Domain.Models;
using Moq;
using Presentation_ContactsApp.MVVM.ViewModels;

namespace Presentation_ContactsApp.Tests.MVVM.ViewModels;

public class AddViewModel_Tests
{
    private readonly Mock<IContactService> _contactServiceMock;
    private readonly Mock<IFileService> _fileServiceMock;

    public AddViewModel_Tests()
    {
        _contactServiceMock = new Mock<IContactService>();
        _fileServiceMock = new Mock<IFileService>();
    }

    [Fact]
    public void ResetForm_ShouldClearRegistrationForm_WhenCalled()
    {
        // Arrange
        _contactServiceMock
            .Setup(cs => cs.CreateContact(It.IsAny<ContactItem>()))
            .Returns(true);

        _fileServiceMock
            .Setup(fs => fs.LoadListFromFile())
            .Returns(new List<ContactItem>());

        var viewModel = new AddViewModel(_contactServiceMock.Object, _fileServiceMock.Object);

        // Act
        viewModel.RegistrationForm.FullName = "John Doe";
        viewModel.RegistrationForm.Email = "john.doe@example.com";
        viewModel.RegistrationForm.Phone = "+46712345678";
        viewModel.RegistrationForm.Address = "Street 1";
        viewModel.RegistrationForm.Postcode = "123 45";
        viewModel.RegistrationForm.City = "Stockholm";
        viewModel.ResetForm();

        // Assert
        Assert.Null(viewModel.RegistrationForm.FullName);
        Assert.Null(viewModel.RegistrationForm.Email);
        Assert.Null(viewModel.RegistrationForm.Phone);
        Assert.Null(viewModel.RegistrationForm.Address);
        Assert.Null(viewModel.RegistrationForm.Postcode);
        Assert.Null(viewModel.RegistrationForm.City);
    }

    // This test might not be working correctly.
    [Fact]
    public void BtnCreateContact_ShouldReturnTrue_WhenCreatingContactSuccessfully()
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
            .Setup(cs => cs.CreateContact(It.IsAny<ContactItem>()))
            .Returns(true);

        _fileServiceMock
            .Setup(fs => fs.SaveListToFile(It.IsAny<List<ContactItem>>()))
            .Returns(true);

        var viewModel = new AddViewModel(_contactServiceMock.Object, _fileServiceMock.Object)
        {
            RegistrationForm = contact
        };

        // Act
        viewModel.BtnCreateContact();

        // Assert
        Assert.True(viewModel.IsContactCreated);
    }

    [Fact]
    public void AddContactToList_ShouldAddContactToList_WhenCalled()
    {
        //Arrange
        var contact = new ContactItem
        {
            FullName = "John Doe",
            Email = "JohnDoe@Domain.com",
            Phone = "+46712345678",
            Address = "Väg 1",
            Postcode = "123 45",
            City = "Stockholm"
        };

        var viewModel = new AddViewModel(_contactServiceMock.Object, _fileServiceMock.Object);

        //Act
        viewModel.AddContactToList(contact);

        //Assert
        Assert.Contains(contact, viewModel._contactList);
    }
}
