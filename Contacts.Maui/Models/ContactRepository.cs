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
            new Contact { ContactId = 0, Name = "John Doe", Email = "JohnDoe@Gmail.com" },
            new Contact { ContactId = 1, Name = "Jane Doe", Email = "JaneDoe@Gmail.com" },
            new Contact { ContactId = 2, Name = "Tom Hanks", Email = "TomHanks@Gmail.com" },
            new Contact { ContactId = 3, Name = "Frank Liu", Email = "FrankLiu@Gmail.com" }
        };

        public static List<Contact> GetContacts() => _contacts;

        public static Contact? GetContactById (int contactId) => _contacts.FirstOrDefault(x => x.ContactId == contactId);
    }
}
