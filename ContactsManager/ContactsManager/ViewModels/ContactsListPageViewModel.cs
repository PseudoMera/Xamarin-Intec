﻿using ContactsManager.Models;
using ContactsManager.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactsManager.ViewModels
{
    class ContactsListPageViewModel
    {

        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();

        public ICommand DeleteContactCommand { get; set; } 
        public ICommand EditContactCommand { get; set; }
        public ContactsListPageViewModel()
        {
            Contacts.Add(new Contact() { FirstName = "Albin", LastName = "Frias", PhoneNumber = "829-743-1205", Email="albinest@gmail.com",Photo = "https://wallpapercave.com/wp/ZW0anaB.jpg"});
            Contacts.Add(new Contact() { FirstName = "Albin", LastName = "Frias", PhoneNumber = "829-743-1205", Email = "albinest@gmail.com", Photo = "https://wallpapercave.com/wp/wp266304.png" });
            Contacts.Add(new Contact() { FirstName = "Albin", LastName = "Frias", PhoneNumber = "829-743-1205", Email = "albinest@gmail.com", Photo = "https://images.template.net/wp-content/uploads/2015/09/16232744/Burn-Dark-Wallpaper-Free-Download.jpg" });


            DeleteContactCommand= new Command<Contact>(async (param) =>
            {
               var result = await App.Current.MainPage.DisplayActionSheet($"Are you sure you want to delete {param.FirstName} {param.LastName}", "Cancel", "Delete");
               if(result.Equals("Delete"))
                {
                    Contacts.Remove(param);
                }
            });

            EditContactCommand = new Command<Contact>(async (param) =>
            {
                var result = await App.Current.MainPage.DisplayActionSheet(null,"Cancel",null, $"Call +{param.PhoneNumber}", 
                            $"Email {param.Email}", $"Message +{param.PhoneNumber}","Edit");

                result.MoreMenuValidator(param);
            });

        }
    }
}
