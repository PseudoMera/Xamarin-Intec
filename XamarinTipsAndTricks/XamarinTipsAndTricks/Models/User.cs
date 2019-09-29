using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace XamarinTipsAndTricks.Models
{
    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

       public string Username { get; set; }
    }
}
