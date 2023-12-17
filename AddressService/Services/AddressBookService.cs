using AddressService.Interface;
using AddressService.Models;
using System.Text.Json;

namespace AddressService.Services;
/// Implementation of the IAddressBookService interface.
/// Manages the address book functionality and data persistence.
public class AddressBookService : IAddressBookService
{
    private List<AddressBookContact> contacts = [];
    private readonly string _filePath;

    public AddressBookService(string filePath)
    {
       
        _filePath = filePath.Trim();
        _filePath = filePath;
        LoadContacts();
    }
    // Add a contact to the list and persist to file
    public void AddContact(AddressBookContact contact)
    {
        contacts.Add(contact);
        SaveContacts(GetOptions());
    }
    // Remove a contact from the list and persist to file
    public void RemoveContact(string email)
    {
        var contactToRemove = contacts.Find(c => c.Email == email);
        if (contactToRemove != null)
        {
            contacts.Remove(contactToRemove);
            Console.WriteLine("Contact removed successfully.");
            SaveContacts(GetOptions());
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }
    }
    // Display details of a specific contact
    public void DisplayContactDetails(string email)
    {
        var contact = contacts.Find(c => c.Email == email);
        if (contact != null)
        {
            Console.WriteLine($"Contact Details for {contact.FirstName} {contact.LastName}:");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Phone: {contact.PhoneNumber}");
            Console.WriteLine($"Address: {contact.Address}");
        }
        else
        {
            Console.WriteLine("Contact not found.");
        }
    }
    // Display all contacts
    public void DisplayContacts()
    {
        Console.WriteLine("All Contacts:");
        foreach (var contact in contacts)
        {
            Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}, Email: {contact.Email}, Phone: {contact.PhoneNumber}");
        }
    }
    // Load contacts from a JSON file
    private void LoadContacts()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                string json = File.ReadAllText(_filePath);
                contacts = JsonSerializer.Deserialize<List<AddressBookContact>>(json) ?? [];
            }
            else
            {
                contacts = new List<AddressBookContact>();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading contacts: {ex.Message}");
            contacts = [];
        }
    }
    // Get JSON serialization options
    private static JsonSerializerOptions GetOptions()
    {
        return new() { WriteIndented = true };
    }
    // Save contacts to a JSON file
    private void SaveContacts(JsonSerializerOptions options)
    {
        try
        {
            string json = JsonSerializer.Serialize(contacts, options);
            File.WriteAllText(_filePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving contacts: {ex.Message}");
        }
    }
}