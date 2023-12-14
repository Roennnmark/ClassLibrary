using Contactlist.Shared.Interfaces;
using Contactlist.Shared.Models;
using Contactlist.Shared.Services;

namespace Contactlist.ConsoleApp.Services;

internal class MenuService
{
    private static readonly IContactService _contactService = new ContactService();

    public static void ShowMainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("#####  MENU OPTIONS  #####");
            Console.WriteLine("\n1. Add Contact.");
            Console.WriteLine("2. View Contact List.");
            Console.WriteLine("3. View Specified Contact Details.");
            Console.WriteLine("4. Delete a Contact.");
            Console.WriteLine("5. Exit Application.");
            Console.Write("\nEnter A Menu Option: ");
            var option = Console.ReadLine();

            switch(option)
            {
                case "1":
                    AddContactMenu();
                    break;
                case "2":
                    ShowAllContactsMenu();
                    break;
                case "3":
                    ShowSpecifiedContact();
                    break;
                case "4":
                    DeleteContactFromList();
                    break;
                case "5":
                    ShowExitAppOption();
                    break;
                default: 
                    Console.WriteLine("\nChoose a Menu option! ");
                    break;

            }

            Console.ReadKey();
        }
    }
    public static void AddContactMenu()
    {
        IContact contact = new Contact();

        Console.Clear();
        Console.Write("\n    Enter your first name: ");
        contact.FirstName = Console.ReadLine()!;

        Console.Write("\n    Enter your last name: ");
        contact.LastName = Console.ReadLine()!;

        Console.Write("\n    Enter your phone number: ");
        contact.PhoneNumber = Console.ReadLine()!;

        Console.Write("\n    Enter your e-mail: ");
        contact.Email = Console.ReadLine()!;

        Console.Write("\n    Enter your address: ");
        contact.Address = Console.ReadLine()!;

        _contactService.AddContactToList(contact);
    }

    public static void ShowAllContactsMenu()
    {
        var contactlist = _contactService.GetAllContactsFromList();
        Console.Clear();
        
        if (contactlist != null)
        {
            Console.WriteLine("#####  Contact List  #####");
            foreach (var contact in contactlist)
            {
                Console.WriteLine($"\n-   {contact.FirstName} {contact.LastName}");
            }
        }
        else
        {
            Console.WriteLine("\n-   No Contacts found. ");
        }

    }

    public static void ShowSpecifiedContact()
    {
        var contacts = _contactService.GetAllContactsFromList();
        Console.Clear();
        Console.Write("\n-   Write the e-mail of the Contact you want to display: ");
        var contactmail = Console.ReadLine()!;

        var contact = contacts.FirstOrDefault(x => x.Email == contactmail);

        if (contact != null)
        {
            Console.Clear();
            Console.WriteLine("#####  Contact Information  #####");
            Console.WriteLine($"\n-   Firstname: {contact.FirstName}");
            Console.WriteLine($"-   Lastname: {contact.LastName}");
            Console.WriteLine($"-   Phonenumber: {contact.PhoneNumber}");
            Console.WriteLine($"-   E-mail: {contact.Email}");
            Console.WriteLine($"-   Address: {contact.Address}");
        }
        else
        {
            Console.WriteLine("Contact not found...");
        }
        Console.ReadKey();
    }

    public static void DeleteContactFromList()
    {
        var contacts = _contactService.GetAllContactsFromList();
        Console.Clear();
        Console.Write("\n-   Write the e-mail of the Contact you want to delete: ");
        var contactToRemove = Console.ReadLine()!;

        var contact = contacts.FirstOrDefault(x => x.Email == contactToRemove);
        
        if (contact != null)
        {
            _contactService.DeleteContactFromList(contactToRemove);
            Console.WriteLine("\n-   Contact deleted. ");
        }
        else
        {
            Console.WriteLine("\n-   Contact does not exist. ");
        }
    }

    public static void ShowExitAppOption()
    {
        Console.Clear();
        Console.Write("\n-   Are you sure? (y/n): ");
        var choice = Console.ReadLine() ?? "";

        if (choice.ToLower() == "y")
        {
            Environment.Exit(0);
        }

        Console.ReadKey();
    }

}
