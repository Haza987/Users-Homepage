﻿using Domain.Models;
using Business.Interfaces;

namespace MainApp.Dialogues;

public class EditContactDialogue(IContactService contactService)
{
    private IContactService _contactService = contactService;

    public void EditContact(Contact contact)
    {
        Console.Clear();
        Console.WriteLine("---------- EDIT CONTACT ----------");
        Console.WriteLine($"Current first name: {contact.FirstName}");
        Console.WriteLine("Enter a new first name or leave the field blank to keep the current first name: ");
        var firstName = Console.ReadLine();
        if (!string.IsNullOrEmpty(firstName))
        {
            contact.FirstName = firstName;
        }
        

        Console.Clear();
        Console.WriteLine("---------- EDIT CONTACT ----------");
        Console.WriteLine($"Current last name: {contact.LastName}");
        Console.WriteLine("Enter a new last name or leave the field blank to keep the current last name: ");
        var lastName = Console.ReadLine();
        if (!string.IsNullOrEmpty(lastName))
        {
            contact.LastName = lastName;
        }
        

        Console.Clear();
        Console.WriteLine("---------- EDIT CONTACT ----------");
        Console.WriteLine($"Current email address: {contact.Email}");
        Console.WriteLine("Enter a new email address or leave the field blank to keep the current email address: ");
        var email = Console.ReadLine();
        if (!string.IsNullOrEmpty(email))
        {
            contact.Email = email;
        }
        

        Console.Clear();
        Console.WriteLine("---------- EDIT CONTACT ----------");
        Console.WriteLine($"Current phone number: {contact.Phone}");
        Console.WriteLine("Enter a new phone number or leave the field blank to keep the current phone number: ");
        var phone = Console.ReadLine();
        if (!string.IsNullOrEmpty(phone))
        {
            contact.Phone = phone;
        }
        

        Console.Clear();
        Console.WriteLine("---------- EDIT CONTACT ----------");
        Console.WriteLine($"Current street address: {contact.Address}");
        Console.WriteLine("Enter a new street address or leave the field blank to keep the current street address: ");
        var address = Console.ReadLine();
        if (!string.IsNullOrEmpty(address))
        {
            contact.Address = address;
        }
        

        Console.Clear();
        Console.WriteLine("---------- EDIT CONTACT ----------");
        Console.WriteLine($"Current postcode: {contact.Postcode}");
        Console.WriteLine("Enter a new postcode or leave the field blank to keep the current postcode: ");
        var postcode = Console.ReadLine();
        if (!string.IsNullOrEmpty(postcode))
        {
            contact.Postcode = postcode;
        }
        

        Console.Clear();
        Console.WriteLine("---------- EDIT CONTACT ----------");
        Console.WriteLine($"Current city: {contact.City}");
        Console.WriteLine("Enter a new city or leave the field blank to keep the current city: ");
        var city = Console.ReadLine();
        if (!string.IsNullOrEmpty(city))
        {
            contact.City = city;
        }
        

        _contactService.EditContact(contact);

        Console.Clear();
        Console.WriteLine("---------- UPDATED CONTACT ----------");
        Console.WriteLine("Contact updated successfully! Here is the updated contact:");
        Console.WriteLine($"ID: {contact.Id}");
        Console.WriteLine($"First Name: {contact.FirstName}");
        Console.WriteLine($"Last Name: {contact.LastName}");
        Console.WriteLine($"Email address: {contact.Email}");
        Console.WriteLine($"Phone number: {contact.Phone}");
        Console.WriteLine($"Street address: {contact.Address}");
        Console.WriteLine($"Postcode: {contact.Postcode}");
        Console.WriteLine($"City: {contact.City}");
        Console.WriteLine("");
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }
}
