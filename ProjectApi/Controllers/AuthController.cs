using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ProjectApi.Data;
using ProjectApi.Models.DTO;
using System.Text;

namespace ProjectApi.Controllers
{
  
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _db;

        public AuthController(IConfiguration configuration, ApplicationDbContext db)
        {
            _configuration = configuration;
            _db = db;
        }


        [HttpPost("login")]
        public IActionResult Login(LoginInputDTO loginDetails)
        {
            // Check if provided username and password match the predefined user
            var user = _db.PredefinedUsers.FirstOrDefault(u =>
                u.Username == loginDetails.Username && u.Password == loginDetails.Password);

            if (user != null)
            {
                // User is authenticated, generate a token and return a JWT token
                string token = GenerateJwtToken(user.Username);

                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid credentials");
        }

        // Method to generate JWT Token
        private string GenerateJwtToken(string username)
        {
            // Get the JWT secret from the configurations
            string jwtSecret = _configuration["Jwt:SecretKey"];

            // Create a token handler and specify signing credentials
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(jwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, username)
            }),
                Expires = DateTime.UtcNow.AddDays(7), // Token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            // Create the JWT Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
