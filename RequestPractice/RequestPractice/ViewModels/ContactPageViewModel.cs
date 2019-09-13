using Newtonsoft.Json;
using Refit;
using RequestPractice.Models;
using RequestPractice.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace RequestPractice.ViewModels
{
    class ContactPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Contact> Contacts { get; set; } = new ObservableCollection<Contact>();

        public ICommand GetContactsCommand { get; set; }
        public ContactPageViewModel()
        {
            GetContactsCommand = new Command(async () =>
            {
                var internet = Connectivity.NetworkAccess;
                if (internet == NetworkAccess.Internet)
                {
                    Contacts = await CallApi();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Error", "You do not have access to the internet right now", "Ok");
                }
            });
        }

        async Task<ObservableCollection<Contact>> CallApi()
        {
            var apiResponse = RestService.For<IPersonalRelations>("https://dockpad.xyz");
            var contacts = await apiResponse.GetContacts();
            return contacts;
        }
        protected void OnPropertyChanged(string change)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(change));
        }

    }
}
