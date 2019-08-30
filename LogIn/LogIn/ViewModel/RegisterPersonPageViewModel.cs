using LogIn.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LogIn.ViewModel
{
    class RegisterPersonPageViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private string _registerError;
        
        public string RegisterError
        {
            get { return _registerError; }
            set
            {
                _registerError = value;
                OnPropertyChanged(nameof(RegisterError));

            }
        }

        public Person MyPerson { get; set; }  = new Person();
        public ICommand RegisterCommand { get; set; }

        public string ConfirmPassword { get; set; }
        public RegisterPersonPageViewModel()
        {
            RegisterCommand = new Command(async () =>
            {

                if (string.IsNullOrEmpty(MyPerson.UserName))
                {

                    RegisterError = "Your name cannot be empty";
                }
                else if(string.IsNullOrEmpty(MyPerson.Email))
                {
                    RegisterError = "Your email cannot be empty";
                }
                else if (string.IsNullOrEmpty(MyPerson.PassWord))
                {
                    RegisterError = "Your password cannot be empty";
                }
                else if(string.IsNullOrEmpty(ConfirmPassword))
                {
                    RegisterError = "Your confirm password cannot be empty";
                }
                else if(!ConfirmPassword.Equals(MyPerson.PassWord))
                {
                    RegisterError = "Your password does not match";
                }
                else
                {
                    await App.Current.MainPage.Navigation.PushAsync(new HomePage(MyPerson.UserName));
                }
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
