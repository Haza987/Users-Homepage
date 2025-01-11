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
            _contactList = new ObservableCollection<ContactItem>();
        }
    }

    [ObservableProperty]
    private ContactItem _registrationForm = new();

    [ObservableProperty]
    public ObservableCollection<ContactItem> _contactList = new();

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
        Debug.WriteLine("BtnCreateContact called");
        IsContactCreated = false;

        

        Debug.WriteLine("Creating contact...");
        if (_registrationForm != null)
        {
            Debug.WriteLine("Registration form is not null");
            if (!string.IsNullOrWhiteSpace(_registrationForm.FullName) &&
            !string.IsNullOrWhiteSpace(_registrationForm.Email) &&
            !string.IsNullOrWhiteSpace(_registrationForm.Phone) &&
            !string.IsNullOrWhiteSpace(_registrationForm.Address) &&
            !string.IsNullOrWhiteSpace(_registrationForm.Postcode) &&
            !string.IsNullOrWhiteSpace(_registrationForm.City))
            {
                Debug.WriteLine("All required fields are filled");
                var result = _contactService.CreateContact(_registrationForm);
                if (result)
                {
                    Debug.WriteLine("Contact created successfully");
                    AddContactToList(_registrationForm);

                    Debug.WriteLine("Saving contact list to file...");
                    _fileService.SaveListToFile(_contactList.ToList());

                    IsContactCreated = true;
                    Debug.WriteLine("Contact list saved successfully");
                    await Shell.Current.DisplayAlert("Success", "Contact created successfully", "OK");

                    await Shell.Current.GoToAsync("///MainPage");
                }
                else
                {
                    Debug.WriteLine("Failed to create contact");
                    await Shell.Current.DisplayAlert("Error", "Contact not created", "OK");
                }
            }
            else
            {
                Debug.WriteLine("One or more required create fields are empty");
                await Shell.Current.DisplayAlert("Error", "Please fill in all required fields", "OK");
            }
        }
        else
        {
            Debug.WriteLine("Registration form is null");
            await Shell.Current.DisplayAlert("Error", "Invalid contact information", "OK");
        }
    }

    private void AddContactToList(ContactItem contact)
    {
        Debug.WriteLine("AddContactToList called");
        _contactList.Add(contact);
    }
}
