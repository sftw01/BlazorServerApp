using BlazorServerApp.Models;
using BlazorServerApp.Pages.ContactComponents;
using System.Collections.Generic;

namespace BlazorServerApp
{
    public interface IContactService
    {

        List<Contact> GetContacts();            // Get all contacts
        void AddContact(Contact contact);       // Add a new contact
        void DeleteAll();                       //delete all contacts from list

    }
}
