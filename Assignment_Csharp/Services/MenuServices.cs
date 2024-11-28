using Business.Factories;
using Business.Models;
using Business.Services;
using System.ComponentModel.Design;

namespace Assignment_Csharp.Services;

public class MenuServices
{

    private readonly ContactService _contactService = new ContactService();

    public void Run()
    {
        while (true)
        {
            MainMenu();
        }
    }
    public void MainMenu()
    {
        //Menu with different options
        Console.Clear();

        Console.WriteLine($"---- Choose an option -----\n");
        Console.WriteLine($"{"1.",-3} Create new contact.");
        Console.WriteLine($"{"2.",-3} View all contact.");
        Console.WriteLine($"{"Q.",-3} Exit application.\n");
        Console.WriteLine("---------------------------");

        var option = Console.ReadLine()!;

        //Switch that makes user being able to choose different options
        switch (option.ToLower())
        {
            case "q":
                QuitApp();
                break;

            case "1":
                CreateContacts();
                break;

            case "2":
                ViewContacts();
                break;

            default:
                InvalidOption();
                break;
        }

    }


    public void QuitApp()
    {
        Console.Clear();
        Console.WriteLine("Are you sure you want to quit this application? (Yes/No)");
        var option = Console.ReadLine()!;

        if (option.Equals("yes", StringComparison.CurrentCultureIgnoreCase))
        {
            Environment.Exit(0);

        }
    }

    public void CreateContacts()
    {

        ContactRegistrationForm contactRegistrationForm = ContactFactory.create();

        Console.Clear();

        Console.WriteLine("Enter your name: ");
        contactRegistrationForm.FirstName = Console.ReadLine()!;

        Console.WriteLine("Enter your lastname: ");
        contactRegistrationForm.LastName = Console.ReadLine()!;

        Console.WriteLine("Enter your E-mail: ");
        contactRegistrationForm.Email = Console.ReadLine()!;

        Console.WriteLine("Enter your phone number: ");
        contactRegistrationForm.PhoneNumber = Console.ReadLine()!;

        Console.WriteLine("Enter your address: ");
        contactRegistrationForm.Address = Console.ReadLine()!;

        Console.WriteLine("Enter your postal code: ");
        contactRegistrationForm.PostalCode = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter your city: ");
        contactRegistrationForm.City = Console.ReadLine()!;

        bool result = _contactService.Create(contactRegistrationForm);

        if (result)
            OutputDialog("Contact was created successfully!");
        else
            OutputDialog("Contact was NOT created successfully...");

    }

    public void ViewContacts()
    {
        var contacts = _contactService.GetAll();

        Console.Clear();

        foreach (var contact in contacts)
        {
            Console.WriteLine($"{"Id: ", -3}{contact.Id}");
            Console.WriteLine($"{"Name: ", -3}{contact.FirstName} {contact.LastName}");
            Console.WriteLine($"{"E-mail: ", -3}{contact.Email}");
            Console.WriteLine($"{"Phone number: ", -3}{contact.PhoneNumber}");
            Console.WriteLine($"{"Address: ", -3}{contact.Address}");
            Console.WriteLine($"{"Postal code: ", -3}{contact.PostalCode}");
            Console.WriteLine($"{"City: ", -3}{contact.City}");
            Console.WriteLine("------------------------");
        }

        Console.ReadKey();
    }

    //If the user choose a not existing option, they will get this in return.
    public void InvalidOption()
    {
        Console.Clear();
        Console.WriteLine("You have to choose an option.");
        Console.ReadKey();
    }

    public void OutputDialog(string message)
    {
        Console.Clear();
        Console.WriteLine(message);
        Console.ReadKey();
    }

}
