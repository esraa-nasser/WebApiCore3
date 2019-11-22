using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICoreLatestVersion.Models
{
    public class EmailModel
    { 
        public int PortNo { get; set; }

        public string Host { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
