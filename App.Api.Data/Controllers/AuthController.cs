using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using App.Data.Entities;
using App.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace App.Api.Data.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IDataRepository<UserEntity> _userRepository;
        private readonly IConfiguration _configuration;

        public AuthController(
            IDataRepository<UserEntity> userRepository,
            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var users = await _userRepository.GetAllAsync();

            var user = users.FirstOrDefault(x =>
                x.Email == request.Email &&
                x.Password == request.Password &&
                x.Enabled);

            if (user == null)
                return NotFound();

            string roleName = user.RoleId switch
            {
                1 => "Admin",
                2 => "Seller",
                3 => "Buyer",
                _ => ""
            };

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, roleName)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new LoginResponse
            {
                Token = tokenString,
                Role = roleName,
                UserId = user.Id,
                FullName = $"{user.FirstName} {user.LastName}"
            });
        }
    }

    public class LoginRequest
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }

    public class LoginResponse
    {
        public string Token { get; set; } = null!;
        public string Role { get; set; } = null!;
        public int UserId { get; set; }
        public string FullName { get; set; } = null!;
    }
}