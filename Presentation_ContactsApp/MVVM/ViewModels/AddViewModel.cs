using Business.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Models;
using System.Collections.ObjectModel;

namespace Presentation_ContactsApp.MVVM.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private readonly ContactService _contactService;

    public HomeViewModel(ContactService contactService)
    {
        _contactService = contactService;
        UpdateContactList();
    }

    [ObservableProperty]
    private ContactItem _registrationForm = new();

    [ObservableProperty]
    public ObservableCollection<ContactItem> _contactList = [];

    [RelayCommand]
    public void CreateContact()
    {
        if (_registrationForm != null && !string.IsNullOrWhiteSpace(_registrationForm.FullName))
        {
            var result = _contactService.CreateContact(_registrationForm);
            if (result)
            {
                UpdateContactList();
            }
        }
    }

    public void UpdateContactList()
    {
        _contactList = new ObservableCollection<ContactItem>(_contactService.Contacts.Select(customer => customer).ToList());
    }
}
