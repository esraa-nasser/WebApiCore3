using APICoreLatestVersion.Dtos.UserDtos;
using APICoreLatestVersion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace APICoreLatestVersion.Services.UserService
{
    public interface IUserService
    {
        ReturnFromLoginDto AuthenticateUser(UserLoginDto user);
        ReturnFromRegisterUser RegisterUser(RegisterUserDto dto);
    }
}
