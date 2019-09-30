using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinTipsAndTricks.ViewModels
{
    public class VisualStatePageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsEnabled { get; set; } = false;
        public string IsEnabledstr { get; set; } = "False";
        public ICommand ChangeStateCommand { get; set; }
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
        }
    }
}
