namespace AddressService.Interface
{
    public interface IContact
    {
        string Email { get; set; }
        string Name { get; set; }
        string PhoneNumber { get; set; }
    }
}