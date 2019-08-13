using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LogIn
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void LoginClicked(object sender, EventArgs e)
        {

            if(string.IsNullOrEmpty(userName.Text))
            {

                DisplayAlert("Error", "You have to enter a valid username","Ok");
            }
            else if(string.IsNullOrEmpty(passWord.Text))
            {
                DisplayAlert("Error", "You have to enter a valid password", "Ok");
            }
            else
            {
                DisplayAlert("Welcome", "Hello " + userName.Text, "Ok");
            }
        }
    }
}
