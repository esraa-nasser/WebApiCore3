using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APICoreLatestVersion.Dtos.UserDtos
{
    public class RegisterUserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You Must Specify Your Email")]

        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "You Must Specify Your Password")]
        public string Password { get; set; }

        public string PhoneNo { get; set; }
    }
}
