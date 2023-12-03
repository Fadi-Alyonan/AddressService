using AddressService.Interface;
using AddressService.Services;

class Program
{
    static void Main(string[] args)
    {
        IAddressBookService addressBookService = new AddressBookService();

        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Remove Contact");
            Console.WriteLine("3. Display Contacts");
            Console.WriteLine("4. Exit");

            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        addressBookService.AddContact();
                        break;
                    case 2:
                        Console.Write("Enter the name to remove: ");
                        string nameToRemove = Console.ReadLine()!;
                        addressBookService.RemoveContact(name: nameToRemove);
                        break;
                    case 3:
                        addressBookService.DisplayContacts();
                        break;
                    case 4:
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
}