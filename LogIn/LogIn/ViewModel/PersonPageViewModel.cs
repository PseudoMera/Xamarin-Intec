using LogIn.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LogIn.ViewModel
{
    class PersonPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _logInError;

        public string LogInError
        {
            get { return _logInError; }
            set
            {
                _logInError = value;
                OnPropertyChanged(nameof(LogInError));

            }
        }
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public Person MyPerson { get; set; } = new Person();
        public PersonPageViewModel()
        {
            LoginCommand = new Command( async () =>
            {

                if (string.IsNullOrEmpty(MyPerson.UserName))
                {

                    LogInError = "You have to enter a valid username";
                }
                else if (string.IsNullOrEmpty(MyPerson.PassWord))
                {
                    LogInError = "You have to enter a valid password";
                }
                else
                {
                    await App.Current.MainPage.Navigation.PushAsync(new HomePage(MyPerson.UserName));
                }
            });

            
            RegisterCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());

            });

        }

        protected void OnPropertyChanged(string logInError)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(logInError));
            }
        }
    }
}
