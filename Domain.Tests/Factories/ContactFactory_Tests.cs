using Domain.Factories;
using Domain.Models;

namespace Domain.Tests.Factories;

public class ContactFactory_Tests
{
    [Fact]
    public void Create_ShouldReturnContactRegistrationForm()
    {
        // Arrange
        // Act
        ContactRegistrationForm result = ContactFactory.Create();

        // Assert
        Assert.IsType<ContactRegistrationForm>(result);
    }

    [Theory]
    [InlineData("John", "Doe", "JohnDoe@domain.com", "+46712345678", "Väg 1", "123 45", "Stockholm")]

    public void Create_ShouldReturnContact_WhenContactRegistrationFormIsSupplied(string FirstName, string LastName, string Email, string Phone, string Address, string Postcode, string City)
    {
        // Arrange
        ContactRegistrationForm contactRegistrationForm = new ()
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            Phone = Phone,
            Address = Address,
            Postcode = Postcode,
            City = City
        };

        // Act
        Contact result = ContactFactory.Create(contactRegistrationForm);

        // Assert
        Assert.Equal(FirstName, result.FirstName);
        Assert.Equal(LastName, result.LastName);
        Assert.Equal(Email, result.Email);
        Assert.Equal(Phone, result.Phone);
        Assert.Equal(Address, result.Address);
        Assert.Equal(Postcode, result.Postcode);
        Assert.Equal(City, result.City);
    }
}
