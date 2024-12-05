using Business.Factories;
using Business.Helpers;
using Business.Models;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace Business.Services;

public class ContactService
{
    public readonly List<ContactEntity> _contacts = [];
    private readonly FileService _fileService;

    public ContactService()
    {
        _fileService = new FileService();
        _contacts = _fileService.LoadListFromFile<ContactEntity>() ?? new List<ContactEntity>();
    }

    public ContactService(FileService fileService)
    {
        _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        _contacts = _fileService.LoadListFromFile<ContactEntity>() ?? new List<ContactEntity>();
    }

    public bool Create(ContactRegistrationForm form)
    {
        try
        {
            ContactEntity contactEntity = ContactFactory.Create(form);
            contactEntity.Id = UniqueIdentifierGenerator.GenerateUniqueId();

            _contacts.Add(contactEntity);
            _fileService.SaveListToFile(_contacts);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error: {ex.Message}");
            return false;
        }
    }

    //Code generated with help from chatGPT.
    public IEnumerable<Contact> GetAll()
    {
        try
        {
            // Ladda kontakter från fil
            var entities = _fileService.LoadListFromFile<ContactEntity>();

            // Omvandla ContactEntity till Contact
            var contacts = new List<Contact>();
            foreach (var entity in entities)
            {
                contacts.Add(new Contact
                {
                    Id = UniqueIdentifierGenerator.GenerateUniqueId(),
                    FirstName = entity.FirstName,
                    LastName = entity.LastName,
                    Email = entity.Email,
                    PhoneNumber = entity.PhoneNumber,
                    Address = entity.Address,
                    PostalCode = entity.PostalCode,
                    City = entity.City,
                });
            }

            return contacts;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error: {ex.Message}");
            return new List<Contact>();
        }
    }
}