using Business.Interfaces;
using Data.Interfaces;
using Domain.Models;
using Microsoft.Maui.ApplicationModel.Communication;
using Moq;
using Presentation_ContactsApp.MVVM.ViewModels;
using System.Collections.ObjectModel;

namespace Presentation_ContactsApp.Tests.MVVM.ViewModels;

public class ListViewModel_tests
{
    private readonly Mock<IContactService> _contactServiceMock;
    private readonly Mock<IFileService> _fileServiceMock;

    public ListViewModel_tests()
    {
        _contactServiceMock = new Mock<IContactService>();
        _fileServiceMock = new Mock<IFileService>();
    }

    // This test is not working correctly
    [Fact]
    public void Remove_ShouldDeleteContact_WhenCalled()
    {
        //Arrange
        var contacts = new List<ContactItem>
        {
            new ContactItem
            {
                FullName = "John Doe",
                Email = "JohnDoe@Domain.com",
                Phone = "+46712345678",
                Address = "Väg 1",
                Postcode = "123 45",
                City = "Stockholm"
            },

            new ContactItem
            {
                FullName = "Updated Contact",
                Email = "UpdatedContact@Domain.com",
                Phone = "+46787654321",
                Address = "Väg 2",
                Postcode = "54 321",
                City = "Göteborg"
            }
        };

        _contactServiceMock
            .Setup(cs => cs.GetAllContacts())
            .Returns(contacts);

        _contactServiceMock
            .Setup(cs => cs.DeleteContact(It.IsAny<ContactItem>()))
            .Returns(true);

        var viewModel = new ListContactsViewModel(_contactServiceMock.Object)
        {
            ContactItems = new ObservableCollection<ContactItem>(contacts)
        };

        //Act
        viewModel.Remove(contacts[0]);

        //Assert
        Assert.Single(viewModel.ContactItems);
    }

    [Fact]
    public void UpdateContactList_ShouldUpdateList_WhenCalled()
    {
        //Arrange
        var contacts = new List<ContactItem>
        {
            new ContactItem
            {
                FullName = "John Doe",
                Email = "JohnDoe@Domain.com",
                Phone = "+46712345678",
                Address = "Väg 1",
                Postcode = "123 45",
                City = "Stockholm"
            },

            new ContactItem
            {
                FullName = "Updated Contact",
                Email = "UpdatedContact@Domain.com",
                Phone = "+46787654321",
                Address = "Väg 2",
                Postcode = "54 321",
                City = "Göteborg"
            }
        };

        _contactServiceMock
            .Setup(cs => cs.GetAllContacts())
            .Returns(contacts);

        var viewModel = new ListContactsViewModel(_contactServiceMock.Object);

        // Act
        viewModel.UpdateContactList();

        // Assert
        Assert.Contains(contacts[0], viewModel.ContactItems);
        Assert.Contains(contacts[1], viewModel.ContactItems);
    }
}
