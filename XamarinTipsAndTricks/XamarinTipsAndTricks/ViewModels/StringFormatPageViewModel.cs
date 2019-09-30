using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinTipsAndTricks.Models;
using XamarinTipsAndTricks.Views;

namespace XamarinTipsAndTricks.ViewModels
{
    public class StringFormatPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public User MyUser { get; set; }

        public ICommand ChangePageCommand { get; set; }
        public StringFormatPageViewModel()
        {

            MyUser = new User();

            ChangePageCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new StaticPropertyPage());
            });
        }

    }
}
