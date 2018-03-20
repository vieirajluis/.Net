using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactManager.Models;
using System.IO;

namespace ContactManager.Services
{
    public class ContactRepository
    {
        private const string CacheKey = "ContactStore";
        private List<Contact> contactsList = new List<Contact>();

        public ContactRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var contacts = new Contact[]
                    {
                        new Contact
                        {
                            CustomerID = "1", ContactName = "Glenn Block"
                        },
                        new Contact
                        {
                            CustomerID = "2", ContactName = "Dan Roth"
                        }
                    };

                    ctx.Cache[CacheKey] = contacts;
                    contactsList.AddRange(contacts);

                    
                }
            }
        }

        public Contact[] GetAllContacts()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                contactsList.AddRange((Contact[])ctx.Cache[CacheKey]);
                return (Contact[])ctx.Cache[CacheKey];
            }

            var contacts = new Contact[]
            {
                new Contact
                {
                    CustomerID = "0",
                    ContactName = "Placeholder"
                }

                
            };

            contactsList.AddRange(contacts);
            return contacts;
        }

        public Contact Get(int id)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                var contacts = (Contact[])ctx.Cache[CacheKey];
                return contacts.ToList().Find(c => c.CustomerID == id.ToString());
            }

            return new Contact
            {

                CustomerID = "0",
                ContactName = "Placeholder"
               
            };

            
        }

        public bool SaveContact(Contact contact)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((Contact[])ctx.Cache[CacheKey]).ToList();
                    currentData.Add(contact);
                    ctx.Cache[CacheKey] = currentData.ToArray();
                    contactsList.Add(contact);

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }

      
    }
}