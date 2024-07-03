using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Maui.Models
{
    public static class ContactRepository
    {
        public static List<Contact> _contacts = new() 
        {
            new Contact { ContactId = 0, Name = "John Doe", Email = "JohnDoe@Gmail.com", Phone = "078557388209", Address = "123, Glasgow Street" },
            new Contact { ContactId = 1, Name = "Jane Doe", Email = "JaneDoe@Gmail.com", Phone = "078557388209", Address = "123, Glasgow Street" },
            new Contact { ContactId = 2, Name = "Tom Hanks", Email = "TomHanks@Gmail.com", Phone = "078557388209", Address = "123, Glasgow Street" },
            new Contact { ContactId = 3, Name = "Frank Liu", Email = "FrankLiu@Gmail.com", Phone = "078557388209", Address = "123, Glasgow Street" }
        };

        public static List<Contact> GetContacts() => _contacts;

        public static Contact? GetContactById(int contactId)
        {
            var contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contact != null)
            {
                return new Contact
                {
                    ContactId = contact.ContactId,
                    Address = contact.Address,
                    Email = contact.Email,
                    Phone = contact.Phone,
                    Name = contact.Name
                };
            }

            return null;
        }

        public static void UpdateContact(int contactId, Contact contact)
        {
            if (contactId != contact.ContactId) return;

            var contactToUpdate = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contactToUpdate != null)
            {
                //AutoMapper
                contactToUpdate.Address = contact.Address;
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Phone = contact.Phone;
            }
        }
    }
}
