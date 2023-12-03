using AddressService.Interface;
using AddressService.Models;
using System;
using System.Collections.Generic;

namespace AddressService.Services
{
    public class AddressBookService : IAddressBookService
    {
        private readonly List<Contact> contacts;

        public AddressBookService()
        {
            contacts = [];
        }

        public void AddContact()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Enter Email: ");
            string email = Console.ReadLine()!;

            Console.Write("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine()!;

            Contact newContact = new Contact
            {
                Name = name,
                Email = email,
                PhoneNumber = phoneNumber
            };

            contacts.Add(newContact);
            Console.WriteLine("Contact added successfully.");
        }

        public void RemoveContact(string name)
        {
            Contact contactToRemove = contacts.Find(c => c.Name == name)!;
            if (contactToRemove != null)
            {
                contacts.Remove(contactToRemove);
                Console.WriteLine("Contact removed successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        public void DisplayContacts()
        {
            Console.WriteLine("Contacts in the address book:");
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Name: {contact.Name}, Email: {contact.Email}, Phone: {contact.PhoneNumber}");
            }
        }
    }
}