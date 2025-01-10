using Business.Interfaces;
using Business.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Models;
using System.Collections.ObjectModel;

namespace Presentation_ContactsApp.MVVM.ViewModels;

public partial class ListContactsViewModel : ObservableObject
{
    private readonly IContactService _contactService;

    public ListContactsViewModel(IContactService contactService)
    {
        _contactService = contactService;

        ContactItems = new ObservableCollection<ContactItem>(_contactService.GetAllContacts());

        _contactService.ContactItemsUpdated += (sender, e) =>
        {
            ContactItems = new ObservableCollection<ContactItem>(_contactService.GetAllContacts());
        };
    }

    [ObservableProperty]
    private ObservableCollection<ContactItem> contactItems = [];

    [RelayCommand]
    private async Task NavToEdit(ContactItem item)
    {
        var parameters = new ShellNavigationQueryParameters
        {
            {"Contact", item}
        };

        await Shell.Current.GoToAsync("EditView", parameters);
    }

    [RelayCommand]
    private async Task Remove(ContactItem item)
    {
        bool confirm = await Shell.Current.DisplayAlert("Delete", $"Are you sure you want to delete {item.FullName}?", "Yes", "No");
        if (confirm)
        {
            _contactService.DeleteContact(item);
            contactItems = new ObservableCollection<ContactItem>(_contactService.GetAllContacts());
            await Shell.Current.DisplayAlert("Successfully Deleted", "Contact was successfully deleted!", "Ok");
        }
        else
        {
            await Shell.Current.DisplayAlert("Delete Cancelled", "Contact was not deleted!", "Ok");
        };

    }
}