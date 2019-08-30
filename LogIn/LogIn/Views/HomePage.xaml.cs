using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LogIn
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        public string name { get; set; }
        public HomePage(string username)
        {
            InitializeComponent();
            DisplayUsername(username);
        }

        async private static void DisplayUsername(string username)
        {
            await App.Current.MainPage.DisplayAlert("Wecome", $"Welcome {username}", "Ok");
        }
    }
}