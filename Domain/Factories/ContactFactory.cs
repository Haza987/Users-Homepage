using Domain.Models;

namespace Domain.Factories;

public class ContactFactory
{
    public static ContactRegistrationForm Create()
    {
        return new ContactRegistrationForm();
    }

    public static Contact Create(ContactRegistrationForm form)
    {
        return new Contact
        {
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            Phone = form.Phone,
            Address = form.Address,
            Postcode = form.Postcode,
            City = form.City
        };
    }
}
