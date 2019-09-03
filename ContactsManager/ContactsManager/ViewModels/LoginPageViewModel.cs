using ContactsManager.Models;
using ContactsManager.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using ContactsManager.Views;

namespace ContactsManager.ViewModels
{
    class LoginPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public Account MyAccount { get; set; } = new Account();

        public string LoginError { get; set; }

        public LoginPageViewModel()
        {
            LoginCommand = new Command(async () =>
            {

                LoginError = LoginError.LoginValidator(MyAccount);

                if(LoginError.Equals(string.Empty))
                {
                    await App.Current.MainPage.Navigation.PushAsync(new ContactsListPage());
                }
                
               
            });

            RegisterCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
            });
        }
       

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
