using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using APICoreLatestVersion.Dtos.UserDtos;
using APICoreLatestVersion.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace APICoreLatestVersion.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly Token _tokenSettings;
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel(){ Id=1, Email="esraa.nasser",FirstName="Esraa",LastName="Nasser",Password="123456aa",PhoneNo="011111111111"},
            new UserModel(){ Id=2, Email="ahmed.nasser",FirstName="Ahmed",LastName="Nasser",Password="654321aa",PhoneNo="011111111111"},
            new UserModel(){ Id=3, Email="yassin.ahmed",FirstName="Yassin",LastName="Ahmed",Password="456789aa",PhoneNo="011111111111"},
            new UserModel(){ Id=4, Email="nada.nasser",FirstName="Nada",LastName="Nasser",Password="987654aa",PhoneNo="011111111111"}
        };
        public UserService(IOptions<Token> tokenSettings)
        {
            _tokenSettings = tokenSettings.Value;
        }
        public ReturnFromLoginDto AuthenticateUser(UserLoginDto user)
        {
            var userLoggedIn = Users.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
            ReturnFromLoginDto returnFromLoginDto;
            if (userLoggedIn != null)
            {
                var token = GenerateToken(userLoggedIn);
                returnFromLoginDto = new ReturnFromLoginDto()
                {
                    Message = $"Welcome Back {user.Email}",
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    ExpirationDate = token.ValidTo,
                    StatusCode = System.Net.HttpStatusCode.OK,
                    FirstName = userLoggedIn.FirstName,
                    Id = userLoggedIn.Id,
                    LastName = userLoggedIn.LastName,
                    UserName = userLoggedIn.FirstName +' '+userLoggedIn.LastName
                    
                };
            }
            else
            {
                returnFromLoginDto = new ReturnFromLoginDto()
                {
                    StatusCode = System.Net.HttpStatusCode.Unauthorized
                };
            }
            return returnFromLoginDto;
        }
        
        private JwtSecurityToken GenerateToken(UserModel user)
        {
            var authClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            var key = _tokenSettings.SecureKey;
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var token = new JwtSecurityToken(
                issuer: "http://dotnetdetail.net",
                audience: "http://dotnetdetail.net",
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new Microsoft.IdentityModel.Tokens.SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }

        public ReturnFromRegisterUser RegisterUser(RegisterUserDto dto)
        {
            var UserExists = Users.Any(u => u.Email == dto.Email);
            if (UserExists)
            {
                return new ReturnFromRegisterUser() { HttpStatusCode = HttpStatusCode.BadRequest, User = new UserModel() };
            }
            else
            {
                UserModel newUser = new UserModel()
                {
                    Email = dto.Email,
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Password = dto.Password,
                    PhoneNo = dto.PhoneNo
                };
                Users.Add(newUser);
                return new ReturnFromRegisterUser() { HttpStatusCode = HttpStatusCode.Created, User = newUser };
            }
        }
    }
}
