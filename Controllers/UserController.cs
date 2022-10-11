using AdminRegister.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace AdminRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _config;
        public readonly UserContext _context;
        public UserController(IConfiguration config, UserContext context)
        {
            _config = config;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost("CreateUser")]
        public IActionResult Create(User user)
        {
            if (_context.AdminUser.Where(u => u.Email == user.Email).FirstOrDefault() != null)
            {
                return Ok("Already Registered");
            }
            user.MemberScince = DateTime.Now;
            _context.AdminUser.Add(user);
            _context.SaveChanges();
            return Ok("Success");
        }

        [AllowAnonymous]
        [HttpPost("LoginUser")]
        public IActionResult Login(Login user)
        {
            var userRegistered = _context.AdminUser.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
            if (userRegistered != null)
            {
                return Ok(new JwtService(_config).GenerateToken(
                    userRegistered.UserID.ToString(),
                    userRegistered.Name,
                    userRegistered.Email,
                    userRegistered.UniqueUsername,
                    userRegistered.Address,
                    userRegistered.PhoneNumber
                    ));
            }
            return Ok("Failure");
        }
    }
}