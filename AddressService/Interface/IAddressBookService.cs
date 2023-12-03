namespace AddressService.Interface;

public interface IAddressBookService
{
    void AddContact();
    void RemoveContact(string name);
    void DisplayContacts();
}
