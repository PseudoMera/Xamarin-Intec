using ContactsManager.Models;
using ContactsManager.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.ComponentModel;
using ContactsManager.Views;

namespace ContactsManager.ViewModels
{
    class RegisterPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand RegisterCommand { get; set; }
        public string ConfirmPassword { get; set; }

        public string RegisterError { get; set; }
        

        public Account MyAccount { get; set; } = new Account();
        public RegisterPageViewModel()
        {
            RegisterCommand = new Command(async () =>
            {
                RegisterError = RegisterError.RegisterValidator(MyAccount, ConfirmPassword);

                if(RegisterError.Equals(string.Empty))
                {
                    await App.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(new ContactsListPage()));
                }
            });

        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
