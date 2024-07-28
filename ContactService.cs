using BlazorServerApp.Models;
using System.Collections.Generic;

namespace BlazorServerApp
{
    public class ContactService : IContactService
    {
        private List<Contact> ContactList = new List<Contact>();



        public List<Contact> GetContacts()
        {
            return ContactList;
        }

        public void AddContact(Contact contact)
        {
            ContactList.Add(contact);
        }

        public void DeleteAll()
        {
            ContactList.Clear();
        }
    }
}
