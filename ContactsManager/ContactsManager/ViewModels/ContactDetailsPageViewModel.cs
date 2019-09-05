using ContactsManager.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsManager.ViewModels
{
    class ContactDetailsPageViewModel
    {

        public Contact MyContact { get; set; }
        public ContactDetailsPageViewModel(Contact contact)
        {
            MyContact = contact;
        }
    }
}
