using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinTipsAndTricks.Views;

namespace XamarinTipsAndTricks.ViewModels
{
    public class VisualStatePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsEnabled { get; set; } = false;
        public string IsEnabledstr { get; set; } = "False";
        public ICommand ChangeStateCommand { get; set; }
        public ICommand FinalPageCommand { get; set; }

        public VisualStatePageViewModel()
        {
            ChangeStateCommand = new Command(() =>
            {
                if(IsEnabled)
                {
                    IsEnabled = false;
                    IsEnabledstr = "False";
                }
                else
                {
                    IsEnabled = true;
                    IsEnabledstr = "True";
                }
            });

            FinalPageCommand = new Command(async () =>
            {
                await App.Current.MainPage.Navigation.PushAsync(new FinalPage());
            });
        }
    }
}
