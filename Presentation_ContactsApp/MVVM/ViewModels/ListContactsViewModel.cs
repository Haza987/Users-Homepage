using Business.Interfaces;
using Business.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

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
            Debug.WriteLine("ContactItemsUpdated event called");
            UpdateContactList();
        };
    }

    [ObservableProperty]
    private ObservableCollection<ContactItem> contactItems;

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
            UpdateContactList();
            await Shell.Current.DisplayAlert("Successfully Deleted", "Contact was successfully deleted!", "Ok");
        }
        else
        {
            await Shell.Current.DisplayAlert("Delete Cancelled", "Contact was not deleted!", "Ok");
        }
    }

    public void UpdateContactList()
    {
        Debug.WriteLine("UpdateContactList called");
        var updatedContacts = _contactService.GetAllContacts().ToList();
        Debug.WriteLine($"Number of contacts: {updatedContacts.Count}");
        if (ContactItems == null)
        {
            Debug.WriteLine("ContactItems is null, initializing");
            ContactItems = new ObservableCollection<ContactItem>(updatedContacts);
        }
        else
        {
            Debug.WriteLine("Clearing and updating ContactItems");
            ContactItems.Clear();
            foreach (var contact in updatedContacts)
            {
                ContactItems.Add(contact);
            }
        }
        OnPropertyChanged(nameof(ContactItems));
    }
}
