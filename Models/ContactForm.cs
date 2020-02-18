using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portfliodemo.Models
{
    public class ContactForm
    {
        
        public long Id { get; set; }
        public string name { get; set; }
        public string email { get; set; }   
        public string message { get; set; }
    }
}
