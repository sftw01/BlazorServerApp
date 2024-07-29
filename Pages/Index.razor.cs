using BlazorServerApp.Models;
using BlazorServerApp.Pages.ContactComponents;
using BlazorServerApp.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServerApp.Pages
{
    public partial class Index
    {
        [Inject]
        IContactService contactService { get; set; }

        [Inject]
        NavigationManager navigationManager { get; set; }

        [CascadingParameter]
        public Theme AppTheme { get; set; }


        private List<Contact> contacts;
        private bool IsContactDisplayed = true;
        private ContactList contactList;

        //using for MyTextbox component
        private Dictionary<string, object> MyTextboxAttributes = new Dictionary<string, object>
        {
            { "placeholder", "First Name"}
        };

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(1000);

            contacts = contactService.GetContacts();

            await base.OnInitializedAsync();
        }


        private void HideContacts()
        {
            IsContactDisplayed = !IsContactDisplayed;
            if (!IsContactDisplayed)
            {
                contactList.HideContact();
            }
            else
            {
                contactList.ShowContact();
            }
        }


        //for modal window to confimation delete all contacts
        protected DeleteAllConfirmation deleteAllConfirmation { get; set; }
        
        //to shopw mopdal after click button
        public void ShowModal()
        {
            deleteAllConfirmation.Show("button kilkniety");
        }

        //this method will be invoke when user confirm delete all contycts
        public void DeleteAllContacts(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                contactService.DeleteAll();
            }
        }

        private void NavigateToTestPage()
        {
            navigationManager.NavigateTo("./testpage");
        }
    }

}

