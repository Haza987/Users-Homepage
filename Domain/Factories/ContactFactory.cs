using Domain.Models;

namespace Domain.Factories;

public class ContactFactory
{
    public static ContactRegistrationForm Create()
    {
        return new ContactRegistrationForm();
    }

    public static ContactItem Create(ContactRegistrationForm form)
    {
        return new ContactItem
        {
            FullName = form.FullName,
            Email = form.Email,
            Phone = form.Phone,
            Address = form.Address,
            Postcode = form.Postcode,
            City = form.City
        };
    }
}
