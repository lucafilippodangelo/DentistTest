using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Helpers;
using WebApplication1.Models.Entities;

namespace WebApplication1.Services
{
    public interface IJwtAuthenticationService
    {
        ApiAuthenticableUser Authenticate(string username, string password);
        IEnumerable<ApiAuthenticableUser> GetAll();
    }

    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<ApiAuthenticableUser> _users = new List<ApiAuthenticableUser>
        {
            new ApiAuthenticableUser { Username = "test", Password = "test", Id = Guid.Parse("6605cbd9-821b-4132-8468-4bf899c1f453") }
        };

        private readonly AppSettings _appSettings;

        public JwtAuthenticationService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Method for authenticating user credentials and returning a JWT token.
        /// 
        /// On successful authentication the Authenticate method generates a JWT (JSON Web Token) using the JwtSecurityTokenHandler class 
        /// that generates a token that is digitally signed using a secret key stored in appsettings.json. The JWT token is returned to the 
        /// client application which then must include it in the HTTP Authorization header of subsequent web api requests for authentication.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ApiAuthenticableUser Authenticate(string username, string password)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role , "aPatient")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            user.Token = tokenHandler.WriteToken(token);
            // remove password before returning
            user.Password = null;

            return user;
        }

        /// <summary>
        /// Method for getting all users in the application. THIS IS A TEST
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ApiAuthenticableUser> GetAll()
        {
            // return users without passwords
            return _users.Select(x => {
                x.Password = null;
                return x;
            });
        }
    }
}
