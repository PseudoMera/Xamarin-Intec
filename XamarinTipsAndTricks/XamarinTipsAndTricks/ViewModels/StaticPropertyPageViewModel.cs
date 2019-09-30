using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinTipsAndTricks.Views;

namespace XamarinTipsAndTricks.ViewModels
{
    public class StaticPropertyPageViewModel
    {
        public ICommand ChangePageCommand { get; set; }
        public StaticPropertyPageViewModel()
        {
            ChangePageCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new GenericStylesPage());
            });
        }
    }
}
