using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinTipsAndTricks.Models;

namespace XamarinTipsAndTricks.ViewModels
{
    public class StringFormatPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public User MyUser { get; set; } 
        public StringFormatPageViewModel()
        {

            MyUser = new User();
        }

    }
}
