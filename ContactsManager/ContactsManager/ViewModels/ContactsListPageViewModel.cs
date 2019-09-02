using ContactsManager.Models;
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

        public ICommand DeleteElementCommand { get; set; } 
        public ContactsListPageViewModel()
        {
            Contacts.Add(new Contact() { FirstName = "Albin", LastName = "Frias", PhoneNumber = "829-743-1205", Photo = "https://wallpapercave.com/wp/ZW0anaB.jpg" });
            Contacts.Add(new Contact() { FirstName = "Albin", LastName = "Frias", PhoneNumber = "829-743-1205", Photo = "https://wallpapercave.com/wp/wp266304.png" });
            Contacts.Add(new Contact() { FirstName = "Albin", LastName = "Frias", PhoneNumber = "829-743-1205", Photo = "https://images.template.net/wp-content/uploads/2015/09/16232744/Burn-Dark-Wallpaper-Free-Download.jpg" });


            DeleteElementCommand = new Command<Contact>(async (param) =>
            {
               var result = await App.Current.MainPage.DisplayActionSheet($"Are you sure you want to delete {param.FirstName} {param.LastName}", "Cancel", "Delete");
               if(result.Equals("Delete"))
                {
                    Contacts.Remove(param);
                }
            });

        }
    }
}
