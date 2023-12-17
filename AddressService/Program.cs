using AddressService.Interface;
using AddressService.Services;

class Program
{
    // Main program to instantiate and run the address book console application
    static void Main(string[] args)
    {
        string filePath = "contacts.json";
        IAddressBookService addressBookService = new AddressBookService(filePath);
        IConsoleApplication app = new AddressBookConsoleApp(addressBookService);
        app.Run();
    }
}