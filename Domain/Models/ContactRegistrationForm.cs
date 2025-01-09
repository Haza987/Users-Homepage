namespace Domain.Models;

public class ContactRegistrationForm
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Postcode { get; set; } = null!;
    public string City { get; set; } = null!;
}
