﻿using Business.Interfaces;

namespace MainApp.Dialogues;

public class InvalidOptionDialogue(IContactService contactService)
{
    private IContactService contactService = contactService;

    public void InvalidOption()
    {
        Console.Clear();
        Console.WriteLine("---------- ERROR ----------");
        Console.Write("Invalid option. Returning to the main menu.");
        Console.ReadKey();
    }
}
