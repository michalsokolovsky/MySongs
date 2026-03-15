using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MySongs.Common.DTOs;
using MySongs.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MySongs.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto userDto)
        {
            var existing = _userService.GetAll().FirstOrDefault(u => u.Email == userDto.Email);
            if (existing != null)
                return BadRequest("משתמש עם אימייל זה כבר קיים");

            _userService.Add(userDto);
            return Ok("נרשמת בהצלחה!");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDto userDto)
        {
            var user = _userService.GetAll()
            .FirstOrDefault(u => u.Email == userDto.Email);     if (user == null)
                return Unauthorized("אימייל או סיסמה שגויים");

            var token = GenerateToken(user);
            return Ok(new { token, userId = user.UserId, Username = user.Username });
        }

        private string GenerateToken(UserDto user)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                new Claim(ClaimTypes.Email, user.Email ?? ""),
                new Claim(ClaimTypes.Name, user.Username ?? "")           
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(12),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}