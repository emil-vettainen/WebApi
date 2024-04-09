using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebApi.Filters;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [UseApiKey]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("token")]
        public IActionResult GetToken()
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var secret = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]!);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Audience"],
                    Expires = DateTime.Now.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]!)), SecurityAlgorithms.HmacSha256Signature),

                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Ok(tokenHandler.WriteToken(token));

            }
            catch (Exception)
            {
                
                return Unauthorized();
            }
            
        }
    }
}