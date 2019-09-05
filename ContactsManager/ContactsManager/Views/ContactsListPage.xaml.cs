using ContactsManager.Models;
using ContactsManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactsManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsListPage : ContentPage
    {
        public ContactsListPage(Account account)
        {
            InitializeComponent();
            this.BindingContext = new ContactsListPageViewModel(account);
        }

        async void OnItemTapped(object sender, ItemTappedEventArgs eve)
        {
            var content = eve.Item as Contact;

            await App.Current.MainPage.Navigation.PushAsync(new ContactDetailsPage(content));
        }
    }
}