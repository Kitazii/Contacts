﻿using System;
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
            new Contact { ContactId = 1, Name = "Jane Doe", Email = "JaneDoe@Gmail.com", Phone = "07456367377", Address = "45, Edinbrugh Way" },
            new Contact { ContactId = 2, Name = "Tom Hanks", Email = "TomHanks@Gmail.com", Phone = "079787465488", Address = "1, Bristle Ave" },
            new Contact { ContactId = 3, Name = "Frank Liu", Email = "FrankLiu@Gmail.com", Phone = "078765757575", Address = "32, Highland Street" }
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
            if (contactToUpdate != null )
            {
                contactToUpdate.Address = contact.Address;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Phone = contact.Phone;
                contactToUpdate.Name = contact.Name;
            }
        }

        public static void AddContact(Contact contact)
        {
            var maxId = _contacts.Max(x => x.ContactId);
            contact.ContactId = maxId+1;
            _contacts.Add(contact);
        }

        public static void DeleteContact (int contactId)
        {
            var contact = _contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contact != null)
            {
                _contacts.Remove(contact);
            }
        }

        public static List<Contact> SearchContacts(string filterText)
        {
            var contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Name) && x.Name?.StartsWith(filterText, StringComparison.OrdinalIgnoreCase) == true)?.ToList();

            if (contacts == null || contacts?.Count <= 0)
                contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email?.StartsWith(filterText, StringComparison.OrdinalIgnoreCase) == true)?.ToList();
            else
                return contacts ?? new();

            if (contacts == null || contacts?.Count <= 0)
                contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Phone) && x.Phone?.StartsWith(filterText, StringComparison.OrdinalIgnoreCase) == true)?.ToList();
            else
                return contacts ?? new();

            if (contacts == null || contacts?.Count <= 0)
                contacts = _contacts.Where(x => !string.IsNullOrWhiteSpace(x.Address) && x.Address?.StartsWith(filterText, StringComparison.OrdinalIgnoreCase) == true)?.ToList();
            else
                return contacts ?? new();

            return contacts ?? new();
            
        }
    }
}
