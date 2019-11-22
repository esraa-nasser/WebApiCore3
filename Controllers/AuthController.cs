using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using APICoreLatestVersion.Dtos.EmailDtos;
using APICoreLatestVersion.Dtos.UserDtos;
using APICoreLatestVersion.Models;
using APICoreLatestVersion.Services.NotificationService;
using APICoreLatestVersion.Services.UserService;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MimeKit;

namespace APICoreLatestVersion.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userservice;
        public AuthController(IUserService IUserservice)
        {
            _userservice = IUserservice;
        }
        [HttpPost]
        [Route("Register")]
        public ActionResult<ReturnFromLoginDto> Register([FromBody] RegisterUserDto dto)
        {
            if (ModelState.IsValid)
            {
               var resultOfAdding= _userservice.RegisterUser(dto);
                if (resultOfAdding.HttpStatusCode == HttpStatusCode.Created)
                {
                    return Created("", resultOfAdding.User);
                }
                else
                {
                    return BadRequest("Email Already Exists");
                }
            }
            else
            {
                return BadRequest("Missing Required Fields");
            }      
        }

        [HttpPost]
        [Route("login")]
        public ActionResult<ReturnFromLoginDto> Login([FromBody] UserLoginDto dto)
        {
            if (ModelState.IsValid)
            {
                var returnFromLoginDto = _userservice.AuthenticateUser(dto);
                if (returnFromLoginDto.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return Ok(returnFromLoginDto);
                }
                return Unauthorized("Failed To Login, Please Make Sure You're Using a Valid Email and Password");
            }
            else
                return BadRequest(ModelState);
        }    

    }

    

}
