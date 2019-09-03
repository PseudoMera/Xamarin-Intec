using ContactsManager.Models;
using ContactsManager.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactsManager.ViewModels
{
    class AddContactPageViewModel
    {
        public Contact contact { get; set; } = new Contact();
        public ICommand AddCommand { get; set; }
        public AddContactPageViewModel()
        {
            AddCommand = new Command(async () =>
            {
                MessagingCenter.Send(this, "CreateContact", contact);
                await App.Current.MainPage.Navigation.PopAsync();
                //await App.Current.MainPage.Navigation.PushAsync(new ContactsListPage());
            });
        }
    }
}
