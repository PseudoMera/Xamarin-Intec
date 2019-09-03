using ContactsManager.Models;
using ContactsManager.Views;
using ContactsManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactsManager.ViewModels
{
    class EditContactPageViewModel
    {
        public Contact MyContact { get; set; } = new Contact();
        public ICommand SaveProfile { get; set; }
        public EditContactPageViewModel(Contact contact)
        {
            MyContact = contact;

            SaveProfile = new Command(async () =>
            {
                MessagingCenter.Send(this, "EditContact", MyContact);
                await App.Current.MainPage.Navigation.PopAsync();
            });
        }
    }
}
