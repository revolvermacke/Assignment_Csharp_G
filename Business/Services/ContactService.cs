using Business.Factories;
using Business.Helpers;
using Business.Models;
using System.Diagnostics;

namespace Business.Services;

public class ContactService
{
    public readonly List<ContactEntity> _contacts = [];

    public bool Create(ContactRegistrationForm form)
    {
        try
        {
            ContactEntity contactEntity = ContactFactory.Create(form);
            contactEntity.Id = UniqueIdentifierGenerator.GenerateUniqueId();

            _contacts.Add(contactEntity);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public IEnumerable<Contact> GetAll()
    {
        return _contacts.Select(ContactFactory.Create);
    }

}
