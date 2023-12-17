using AddressService.Interface;
using AddressService.Models;
using AddressService.Services;
using System.Text.Json;

namespace AddressServiceTests;

public class AddressBookService_Tests : IDisposable
{
    private const string TestFilePath = "test_contacts.json";

    public AddressBookService_Tests()
    {
        // Delete the test file before each test
        if (File.Exists(TestFilePath))
        {
            File.Delete(TestFilePath);
        }
    }

    [Fact]
    // Test for adding a contact
    public void AddContact_ShouldAddContactToList()
    {
        // Arrange
        IAddressBookService addressBookService = new AddressBookService(TestFilePath);

        // Act
        var newContact = new AddressBookContact
        {
            FirstName = "John",
            LastName = "Doe",
            PhoneNumber = "123456789",
            Email = "john.doe@example.com",
            Address = "123 Main St"
        };
        addressBookService.AddContact(newContact);

        // Assert
        var loadedContacts = LoadContactsFromJson(TestFilePath);
        Assert.Contains(loadedContacts, c => c.Email == "john.doe@example.com");
    }

    // Helper method to load contacts from a JSON file
    private List<AddressBookContact> LoadContactsFromJson(string filePath)
    {
        // Implement loading contacts from the test file
        try
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<List<AddressBookContact>>(json) ?? new List<AddressBookContact>();
            }
            else
            {
                return new List<AddressBookContact>();
            }
        }
        catch (Exception)
        {
            return new List<AddressBookContact>();
        }
    }
   

    [Fact]
    // Test for removing a contact
    public void RemoveContact_ShouldRemoveContactFromList()
    {
        // Arrange
        IAddressBookService addressBookService = new AddressBookService(TestFilePath);

        // Add a contact 
        var contactToAdd = new AddressBookContact
        {
            FirstName = "test",
            LastName = "test",
            PhoneNumber = "987654321",
            Email = "test@example.com",
            Address = "testVa"
        };
        addressBookService.AddContact(contactToAdd);

        // Act
        addressBookService.RemoveContact("test@example.com");

        // Assert
        var loadedContacts = LoadContactsFromJson(TestFilePath);
        Assert.DoesNotContain(loadedContacts, c => c.Email == "test@example.com");
    }

    [Fact]
    // Test for displaying contact details
    public void DisplayContactDetails_ShouldDisplayCorrectDetails()
    {
        // Arrange
        IAddressBookService addressBookService = new AddressBookService(TestFilePath);

        // Add a contact
        var contactToAdd = new AddressBookContact
        {
            FirstName = "test",
            LastName = "test",
            PhoneNumber = "555555555",
            Email = "test@example.com",
            Address = "testVa"
        };
        addressBookService.AddContact(contactToAdd);

        // Act
        using (StringWriter sw = new())
        {
            Console.SetOut(sw);
            addressBookService.DisplayContactDetails("test@example.com");

            // Assert
            var output = sw.ToString().Trim();
            Assert.Contains("Contact Details for test test:", output);
            Assert.Contains("Email: test@example.com", output);
            Assert.Contains("Phone: 555555555", output);
            Assert.Contains("Address: testVa", output);
        }
    }
    // Dispose method for cleanup after tests
    public void Dispose()
    {
        // Clean up any resources 
        try
        {
            if (File.Exists(TestFilePath))
            {
                File.Delete(TestFilePath);
            }
        }
        catch (Exception)
        {

        }
    }
}
