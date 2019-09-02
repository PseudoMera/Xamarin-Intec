﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsManager.Models
{
    class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
        
        public string Adress { get; set; }


        public string Relationship { get; set; }
        public string Photo { get; set; }

    }
}
