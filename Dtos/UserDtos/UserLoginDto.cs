using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APICoreLatestVersion.Dtos.UserDtos
{
    public class UserLoginDto
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="You Must Enter You Email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage = "You Must Enter You Password")]
        public string Password { get; set; }
    }
}
