using AddressService.Interface;

namespace AddressService.Models;

public class Contact : IContact
{

    public string Name { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;

}
