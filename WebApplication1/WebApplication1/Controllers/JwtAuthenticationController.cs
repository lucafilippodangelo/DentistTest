using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.Entities;
using WebApplication1.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{

        [Authorize]
        [ApiController]
        [Route("[controller]")]
        public class JwtAuthenticationController : ControllerBase
        {
            private IJwtAuthenticationService _authSer;

            public JwtAuthenticationController(IJwtAuthenticationService authSer)
            {
                _authSer = authSer;
            }


            /*
            /JwtAuthentication/authenticate - public route that accepts HTTP POST requests containing the username and password in the body. 
            If the username and password are correct then a JWT authentication token and the user details are returned.
            */
            [AllowAnonymous]
            [HttpPost("authenticate")]
            public IActionResult Authenticate([FromBody]ApiAuthenticableUser userParam)
            {
                var user = _authSer.Authenticate(userParam.Username, userParam.Password);

                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                return Ok(user);
            }

        /*
         JwtAuthentication/getall - secure route that accepts HTTP GET requests and returns a list of all the users in the application if the HTTP Authorization header contains a valid JWT token. 
         If there is no auth token or the token is invalid then a 401 Unauthorized response is returned.
         */
         
        [HttpGet("getall")]
        [Authorize(Roles = "aPatient")] //It works because the token has setup this role. 
        public IActionResult GetAll()
        {
            var users = _authSer.GetAll();
            return Ok(users);
        }
        }
    
}
