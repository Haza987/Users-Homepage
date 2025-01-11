using Business.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Domain.Models;
using System.Diagnostics;

namespace Presentation_ContactsApp.MVVM.ViewModels;

public partial class EditViewModel : ObservableObject, IQueryAttributable
{
    private readonly IContactService _contactService;

    public EditViewModel(IContactService contactService)
    {
        _contactService = contactService;
    }

    [ObservableProperty]
    private ContactItem item = new();

    [RelayCommand]
    private async Task Btn_Update()
    {
       if(Item != null &&
            !string.IsNullOrWhiteSpace(Item.FullName) &&
            !string.IsNullOrWhiteSpace(Item.Email) &&
            !string.IsNullOrWhiteSpace(Item.Phone) &&
            !string.IsNullOrWhiteSpace(Item.Address) &&
            !string.IsNullOrWhiteSpace(Item.Postcode) &&
            !string.IsNullOrWhiteSpace(Item.City))
        {

            var result = _contactService.EditContact(Item);
            Item = new();

            if (result)
            {
                Debug.WriteLine("Contact updated successfully");
                await Shell.Current.DisplayAlert("Success", "Contact updated successfully, returning to homepage", "OK");


                await Shell.Current.GoToAsync("///MainPage");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Please fill out all forms", "OK");
            }
        }
        else
        {
            Debug.WriteLine("One or more required update fields are empty");
            await Shell.Current.DisplayAlert("Error", "Please fill in all required fields", "OK");
        }
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Item = (query["Contact"] as ContactItem)!;
    }
}