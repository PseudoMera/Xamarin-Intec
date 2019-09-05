using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite.Net.Attributes;

namespace ContactsManager.Models
{
    public class Account 
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        [Unique]
        public string Email { get; set; }

       
    }
}
