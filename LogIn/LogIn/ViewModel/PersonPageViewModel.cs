using LogIn.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LogIn.ViewModel
{
    class PersonPageViewModel
    {
        public ICommand LoginCommand { get; set; }
        public Person MyPerson { get; set; } = new Person();
        public PersonPageViewModel()
        {
            LoginCommand = new Command(async () =>
            {
                
                if (string.IsNullOrEmpty(MyPerson.UserName))
                {

                    await App.Current.MainPage.DisplayAlert("Error", "You have to enter a valid username", "Ok");
                }
                else if (string.IsNullOrEmpty(MyPerson.PassWord))
                {
                    await App.Current.MainPage.DisplayAlert("Error", "You have to enter a valid password", "Ok");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Welcome", $"Hello {MyPerson.UserName}", "Ok");
                }
            });
           
        }
    }
}
