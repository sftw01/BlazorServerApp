using BlazorServerApp.Models;
using BlazorServerApp.Pages.ContactComponents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServerApp.Seeder
{
    public class ContactListSeeder
    {
        private IContactService _contactService;
        private List<Contact> _contacts;

        public ContactListSeeder(IContactService contactService)
        {
            _contactService = contactService;
        }

        public void Seed()
        {
            var contacts = new List<Contact>()
            {
                new Contact()
                {
                    FirstName = "Konrad",
                    LastName = "Mirek",
                    Email = "k_mirek@gmail.com"
                },
                new Contact()
                    {
                     FirstName = "Anna",
                     LastName = "Nowak",
                     Email = "anna.nowak@example.com"
                    },
                new Contact()
{
    FirstName = "Jan",
    LastName = "Kowalski",
    Email = "jan.kowalski@example.com"
},
new Contact()
{
    FirstName = "Ewa",
    LastName = "Wiśniewska",
    Email = "ewa.wisniewska@example.com"
},
new Contact()
{
    FirstName = "Tomasz",
    LastName = "Wójcik",
    Email = "tomasz.wojcik@example.com"
},
new Contact()
{
    FirstName = "Katarzyna",
    LastName = "Kamińska",
    Email = "katarzyna.kaminska@example.com"
},
new Contact()
{
    FirstName = "Michał",
    LastName = "Lewandowski",
    Email = "michal.lewandowski@example.com"
},
new Contact()
{
    FirstName = "Agnieszka",
    LastName = "Zielińska",
    Email = "agnieszka.zielinska@example.com"
},
new Contact()
{
    FirstName = "Piotr",
    LastName = "Szymański",
    Email = "piotr.szymanski@example.com"
},
new Contact()
{
    FirstName = "Monika",
    LastName = "Dąbrowska",
    Email = "monika.dabrowska@example.com"
},
new Contact()
{
    FirstName = "Marcin",
    LastName = "Król",
    Email = "marcin.krol@example.com"
}



            };

            foreach (var contact in contacts)
            {
                _contactService.AddContact(contact);
            }
        }
    }
}