using AddressService.Interface;

namespace AddressService.Models;
/// Class representing an address book contact.
/// Implements the IAddressBookContact interface.
public class AddressBookContact : IAddressBookContact
{

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Address { get; set; } = null!;

}
