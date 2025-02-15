﻿using Business.Interfaces;
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
    public ContactItem item = new();

    [RelayCommand]
    public async Task<bool> Btn_Update()
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
                await Shell.Current.DisplayAlert("Success", "Contact updated successfully, returning to homepage", "OK");


                await Shell.Current.GoToAsync("///MainPage");
                return true;
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "Please fill out all forms", "OK");
                return false;
            }
        }
        else
        {
            await Shell.Current.DisplayAlert("Error", "Please fill in all required fields", "OK");
            return false;
        }
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Item = (query["Contact"] as ContactItem)!;
    }
}