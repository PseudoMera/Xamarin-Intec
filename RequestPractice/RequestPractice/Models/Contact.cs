using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RequestPractice.Models
{
    public class Contact
    {

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("company")]
        public string Company { get; set; }

        [JsonProperty("nickname")]
        public string Nickname { get; set; }
    }

}
