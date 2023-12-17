using AddressService.Models;
namespace AddressService.Interface;

/// Interface for an address book service.
public interface IAddressBookService
{
    void AddContact(AddressBookContact contact);
    void RemoveContact(string email);
    void DisplayContactDetails(string email);
    void DisplayContacts();
}
