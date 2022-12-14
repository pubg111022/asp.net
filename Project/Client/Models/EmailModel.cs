using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    public class EmailModel
    {
        public EmailModel()
        {
            From = "vandat97875@gmail.com";
            Password = "xnprvgvhhyqtnxri";
        }
        public string To { get; set; }
        public string Subject { get; set; }
        public string From { get; set; }
        public string Password { get; set; }
    }
}
