using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ContactsManager.Models
{
    public class Contact : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        
        public string Adress { get; set; }


        public string Relationship { get; set; }
        public string Photo { get; set; }

        protected void OnPropertyChanged(string change)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(change));
            }
        }
    }
}
