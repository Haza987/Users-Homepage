using Business.Interfaces;
using Data.Interfaces;
using Domain.Models;
using Moq;
using Presentation_ContactsApp.MVVM.ViewModels;

namespace Presentation_ContactsApp.Tests.MVVM.ViewModels;

public class EditViewModel_Tests
{
    private readonly Mock<IContactService> _contactServiceMock;
    private readonly Mock<IFileService> _fileServiceMock;

    public EditViewModel_Tests()
    {
        _contactServiceMock = new Mock<IContactService>();
        _fileServiceMock = new Mock<IFileService>();
    }

    // This test is not working correctly
    [Fact]
    public async Task Btn_update_ShouldReturnTrue_WhenContactUpdatedSuccessfully()
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
           .Setup(cs => cs.EditContact(It.IsAny<ContactItem>()))
           .Returns(true);

        var viewModel = new EditViewModel(_contactServiceMock.Object)
        {
            Item = contact
        };
        // Act
        var result = await viewModel.Btn_Update();

        // Assert
        Assert.True(result);
    }

    //GitHub Copilot helped me write this test
    [Fact]
    public void ApplyQueryAttributes_ShouldSetItem_WhenCalled()
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

        var viewModel = new EditViewModel(_contactServiceMock.Object);

        var queryAttributes = new Dictionary<string, object>
        {
            { "Contact", contact }
        };

        // Act
        viewModel.ApplyQueryAttributes(queryAttributes);

        // Assert
        Assert.Equal(contact, viewModel.Item);
    }
}
