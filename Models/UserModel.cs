using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICoreLatestVersion.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get { return FirstName + ' ' + LastName; } }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNo { get; set; }

    }
}
