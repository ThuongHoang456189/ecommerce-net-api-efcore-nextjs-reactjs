using AmazonaAPI.Services;
using EFDataAccessLibary.DTOs;
using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AmazonaAPI.Controllers
{
    [ApiController]
    [Route(template: "users")]
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _repository;
        private readonly UserService _service;
        private readonly JwtService _jwtService;
        public UserController(IConfiguration configuration, IUserRepository repository, JwtService jwtService)
        {
            _configuration = configuration;
            _repository = repository;
            _service = new UserService(_repository);
            _jwtService = jwtService;
        }
        private object GetUserInfo(LoginInfo loginInfo)
        {
            var user = _service.Login(loginInfo);
            if (user == null)
                return new { };

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user._id.ToString()),
                new Claim(ClaimTypes.Name, user.name),
                new Claim(ClaimTypes.Email, user.email),
                new Claim(ClaimTypes.Role, user.isAdmin.ToString().ToLower())
            };
            var jwt = _jwtService.Generate(
                _configuration.GetValue<string>("Jwt:Key"),
                _configuration.GetValue<string>("Jwt:Issuer"),
                _configuration.GetValue<string>("Jwt:Audience"),
                claims
                );
            return new
            {
                email = user.email,
                isAdmin = user.isAdmin.ToString().ToLower(),
                name = user.name,
                token = jwt,
                _id = user._id,
            };
        }
        [HttpPost(template: "login")]
        public IActionResult Login(LoginInfo loginInfo)
        {
            var user = _service.Login(loginInfo);
            if (user == null)
                return Unauthorized(new { message = "Invalid Credentials" });

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user._id.ToString()),
                new Claim(ClaimTypes.Name, user.name),
                new Claim(ClaimTypes.Email, user.email),
                new Claim(ClaimTypes.Role, user.isAdmin.ToString().ToLower())
            };
            var jwt = _jwtService.Generate(
                _configuration.GetValue<string>("Jwt:Key"),
                _configuration.GetValue<string>("Jwt:Issuer"),
                _configuration.GetValue<string>("Jwt:Audience"),
                claims
                );
            return Ok(new
            {
                email = user.email,
                isAdmin = user.isAdmin,
                name = user.name,
                token = jwt,
                _id = user._id,
            });
        }
        [HttpPost(template: "register")]
        public IActionResult Register(RegistrationInfo registrationInfo)
        {
            if (_service.Register(registrationInfo))
            {
                return Created(uri: "success", value: GetUserInfo(
                    new LoginInfo
                    {
                        email = registrationInfo.email,
                        password = registrationInfo.password
                    }
                    ));
            }
            return BadRequest(new { message = "Created Failed" });
        }
    }
}
