using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Models.User;
using API.Context;
using Swashbuckle.AspNetCore.Annotations;
using API.Models.ErrorMessage;
using API.Filters;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using API.Entities;
using API.Configurations;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {   
        private readonly CourseContext _context;
        private readonly JwtService _jwtService = new JwtService();

        public UserController(CourseContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        [SwaggerResponse(statusCode: 200, description:"Successfully login", type:typeof(LoginInput))]
        [SwaggerResponse(statusCode: 400, description:"Fill in all fields", type:typeof(ValidField))]
        [SwaggerResponse(statusCode: 500, description:"Internal error", type:typeof(GenericErrorMessage))]
        [ValidateModelStateFilter]
        public IActionResult Login(LoginInput loginInput)
        {
            var userOutput = _context.User.FirstOrDefault(value => value.Login == loginInput.Login);

            if (userOutput == null) return BadRequest();
            if (userOutput.Password != loginInput.Password) return BadRequest("Invalid Password");

            var token = _jwtService.GetToken(userOutput);

            return Ok(new {
                Token = token,
                User = userOutput
            });
        }

        [HttpPost]
        [Route("register")]
        [SwaggerResponse(statusCode: 200, description:"Successfully login", type:typeof(LoginInput))]
        [SwaggerResponse(statusCode: 400, description:"Fill in all fields", type:typeof(ValidField))]
        [SwaggerResponse(statusCode: 500, description:"Internal error", type:typeof(GenericErrorMessage))]
        [ValidateModelStateFilter]
        public IActionResult Register(Registry registry)
        {
            User user = new User();
            user.Login = registry.Login;
            user.Password = registry.Password;
            user.Email = registry.Email;

            _context.User.Add(user);
            _context.SaveChanges();

            return Created("Successfully Registered", registry);
        }
        
    }
}