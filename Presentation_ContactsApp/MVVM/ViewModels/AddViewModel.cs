using Business.Interfaces;
using Business.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Data.Interfaces;
using Data.Services;
using Domain.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Presentation_ContactsApp.MVVM.ViewModels;

public partial class AddViewModel : ObservableObject
{
    private readonly IContactService _contactService;
    private readonly IFileService _fileService;

    public AddViewModel(IContactService contactService, IFileService fileService)
    {
        _contactService = contactService;
        _fileService = fileService;
        
        // GitHub Copilot suggested this code to prevent the issue of the contact list not saving and updating correctly.
        var loadedContacts = _fileService.LoadListFromFile();
        if (loadedContacts != null)
        {
            _contactList = new ObservableCollection<ContactItem>(loadedContacts);
        }
        else
        {
            _contactList = [];
        }
    }

    [ObservableProperty]
    private ContactItem _registrationForm = new();

    [ObservableProperty]
    public ObservableCollection<ContactItem> _contactList = [];

    [ObservableProperty]
    public bool _isContactCreated;

    public void ResetForm()
    {
        RegistrationForm = new ContactItem();
    }

    //GitHub Copilot helped me with this Relay Command so that I could display a message without calling the create method twice.
    [RelayCommand]
    public async Task BtnCreateContact()
    {
        IsContactCreated = false;

                if (RegistrationForm != null)
        {
            if (!string.IsNullOrWhiteSpace(RegistrationForm.FullName) &&
            !string.IsNullOrWhiteSpace(RegistrationForm.Email) &&
            !string.IsNullOrWhiteSpace(RegistrationForm.Phone) &&
            !string.IsNullOrWhiteSpace(RegistrationForm.Address) &&
            !string.IsNullOrWhiteSpace(RegistrationForm.Postcode) &&
            !string.IsNullOrWhiteSpace(RegistrationForm.City))
            {
                var result = _contactService.CreateContact(RegistrationForm);
                if (result)
                {
                    AddContactToList(RegistrationForm);

                    _fileService.SaveListToFile(_contactList.ToList());

                    IsContactCreated = true;
                    await Shell.Current.DisplayAlert("Success", "Contact created successfully", "OK");

                    await Shell.Current.GoToAsync("///MainPage");
                }
                else
                {
                    IsContactCreated = false;
                    await Shell.Current.DisplayAlert("Error", "Contact not created", "OK");
                }
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Please fill in all required fields", "OK");
            }
        }
        else
        {
            await Shell.Current.DisplayAlert("Error", "Invalid contact information", "OK");
        }
    }

    public void AddContactToList(ContactItem contact)
    {
        ContactList.Add(contact);
    }
}
