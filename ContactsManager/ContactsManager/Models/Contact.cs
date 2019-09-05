using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite.Net.Attributes;

namespace ContactsManager.Models
{
    public class Contact : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    

        [Indexed]
        public int AccountId { get; set; }
        public string FirstName
        { 
            get; set;
        }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        
        public string Adress { get; set; }


        public string Relationship { get; set; }
        public string Photo { get; set; }

        protected void OnPropertyChanged(string change)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(change));
        }
    }
}
