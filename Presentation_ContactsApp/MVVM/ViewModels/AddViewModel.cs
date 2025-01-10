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
        if (_registrationForm != null && !string.IsNullOrWhiteSpace(_registrationForm.FullName))
        {
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
                Debug.WriteLine("Failed to save contact list to file");
                await Shell.Current.DisplayAlert("Error", "Contact not created", "OK");
            }
        }
    }

    private void AddContactToList(ContactItem contact)
    {
        Debug.WriteLine("AddContactToList called");
        _contactList.Add(contact);
    }
}
