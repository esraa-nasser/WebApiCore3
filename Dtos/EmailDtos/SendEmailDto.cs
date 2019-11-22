using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APICoreLatestVersion.Dtos.EmailDtos
{
    public class SendEmailDto
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="You Must Specify the Reciever Email")]
        public string To { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "You Must Subject")]
        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
