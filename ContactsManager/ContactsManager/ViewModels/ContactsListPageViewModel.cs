using ContactsManager.Models;
using ContactsManager.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ContactsManager.Views;
using System.Linq;

namespace ContactsManager.ViewModels
{
    class ContactsListPageViewModel
    {

        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();

        //Contact contact;
        public Contact SelectedContact
        {
            get; set;
           
        }


        public ICommand DeleteContactCommand { get; set; } 
        public ICommand EditContactCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand DeleteAccount { get; set; }
        AccountDB Db  = new AccountDB();
        public ContactsListPageViewModel(Account account)
        {
            Contacts = Db.FindContact(account);
            DeleteContactCommand= new Command<Contact>(async (param) =>
            {
               var result = await App.Current.MainPage.DisplayActionSheet($"Are you sure you want to delete {param.FirstName} {param.LastName}", "Cancel", "Delete");
               if(result.Equals("Delete"))
                {
                    Db.DeleteContact(param);
                    Contacts.Remove(param);
                }
            });

            DeleteAccount = new Command(async() =>
            {
                var result = await App.Current.MainPage.DisplayActionSheet($"Are you sure you want to delete {account.Name}", "Cancel", "Delete");
                if (result.Equals("Delete"))
                {
                    Db.DeleteAccount(account);
                    await App.Current.MainPage.Navigation.PopToRootAsync();
                }
            });

          
            EditContactCommand = new Command<Contact>(async (param) =>
            {
                var result = await App.Current.MainPage.DisplayActionSheet(null,"Cancel",null, $"Call +{param.PhoneNumber}", 
                            $"Email {param.Email}", $"Message +{param.PhoneNumber}","Edit");

                result.MoreMenuValidator(param);
                if (result.Equals("Edit"))
                {
                   SelectedContact = param;
                   await App.Current.MainPage.Navigation.PushAsync(new EditContactPage(SelectedContact));
                    SubscribeEditContact();

                }
            });

            AddCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new AddContactPage());
                SubscribeAddContact(account);

            });


        }

        public void SubscribeAddContact(Account account)
        {
            MessagingCenter.Subscribe<AddContactPageViewModel, Contact>(this, "CreateContact", (s, a) =>
            {
                Db.AddContact(a, account);
                Contacts.Add(a);
            });
        }

        public void SubscribeEditContact()
        {
            MessagingCenter.Subscribe<EditContactPageViewModel, Contact>(this, "EditContact", (s, a) =>
            {
                Db.UpdateContact(a);
               var res =  Contacts.FirstOrDefault(x => x.FirstName == SelectedContact.FirstName);
               int index = Contacts.IndexOf(res);
               Contacts[index] = a;
            });
        }

     

      
    }
}
