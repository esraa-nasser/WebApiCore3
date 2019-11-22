using APICoreLatestVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace APICoreLatestVersion.Services.UserService
{
    public class ReturnFromRegisterUser
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public UserModel User { get; set; }
    }
}
