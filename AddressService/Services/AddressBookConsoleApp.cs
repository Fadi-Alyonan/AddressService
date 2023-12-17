using AddressService.Interface;
using AddressService.Models;

namespace AddressService.Services;
/// Console application for the address book.
/// Implements the IConsoleApplication interface.
public class AddressBookConsoleApp : IConsoleApplication
{
    private readonly IAddressBookService _addressBookService;

    public AddressBookConsoleApp(IAddressBookService addressBookService)
    {
        _addressBookService = addressBookService;
    }
    // Console application logic for interacting with the address book service
    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n Choose an option:");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Remove Contact");
            Console.WriteLine("3. Display Contacts");
            Console.WriteLine("4. Display Contact Details");
            Console.WriteLine("5. Exit");

            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter contact details:");
                        AddressBookContact newContact = new()
                        {
                            FirstName = GetUserInput("Enter First Name: "),
                            LastName = GetUserInput("Enter Last Name: "),
                            PhoneNumber = GetUserInput("Enter Phone Number: "),
                            Email = GetUserInput("Enter Email: "),
                            Address = GetUserInput("Enter Address: ")
                        };
                        _addressBookService.AddContact(newContact);
                        break;
                    case 2:
                        Console.Write("Enter the email to remove: ");
                        string emailToRemove = Console.ReadLine()!;
                        _addressBookService.RemoveContact(emailToRemove);
                        break;
                    case 3:
                        _addressBookService.DisplayContacts();
                        break;
                    case 4:
                        Console.Write("Enter the email to display details: ");
                        string emailToDisplay = Console.ReadLine()!;
                        _addressBookService.DisplayContactDetails(emailToDisplay);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
    // Helper method to get user input from the console
    private string GetUserInput(string input)
    {
        Console.Write(input);
        return Console.ReadLine()!;
    }
}
