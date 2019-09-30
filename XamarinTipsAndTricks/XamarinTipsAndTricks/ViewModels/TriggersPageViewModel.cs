using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinTipsAndTricks.Views;

namespace XamarinTipsAndTricks.ViewModels
{
    public class TriggersPageViewModel 
    {
        public ICommand ChangePageCommand { get; set; }

        public TriggersPageViewModel()
        {
            ChangePageCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new VisualStatePage());
            });
        }
    }
}
