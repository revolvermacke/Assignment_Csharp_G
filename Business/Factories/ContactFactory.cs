using Business.Models;

namespace Business.Factories;

public static class ContactFactory
{
    public static ContactRegistrationForm create()
    {
        return new ContactRegistrationForm();
    }

    public static ContactEntity Create(ContactRegistrationForm form)
    {
        return new ContactEntity()
        {
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            PhoneNumber = form.PhoneNumber,
            Address = form.Address,
            PostalCode = form.PostalCode,
            City = form.City,
        };
    }

    public static Contact Create(ContactEntity entity)
    {
        return new Contact()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            PhoneNumber = entity.PhoneNumber,
            Address = entity.Address,
            PostalCode = entity.PostalCode,
            City = entity.City,
        };
    }
}
