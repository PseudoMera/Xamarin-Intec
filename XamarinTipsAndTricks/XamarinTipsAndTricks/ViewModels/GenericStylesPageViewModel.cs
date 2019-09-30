using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinTipsAndTricks.ViewModels
{
    class GenericStylesPageViewModel
    {
        public ICommand ChangePageCommand { get; set; }

        public GenericStylesPageViewModel()
        {
            ChangePageCommand = new Command(async () =>
            {
               // await App.Current.MainPage.Navigation.PushAsync();
            });
        }
    }
}
