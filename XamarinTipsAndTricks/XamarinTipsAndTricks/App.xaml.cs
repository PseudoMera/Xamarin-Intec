using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTipsAndTricks.Views;

namespace XamarinTipsAndTricks
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StringFormatPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
