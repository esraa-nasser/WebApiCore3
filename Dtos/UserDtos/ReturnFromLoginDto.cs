using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace APICoreLatestVersion.Dtos.UserDtos
{
    public class ReturnFromLoginDto
    {
        public string Token { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Message { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
