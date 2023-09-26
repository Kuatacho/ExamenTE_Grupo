using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using System.Security.Cryptography;
namespace Servicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly string secretKey;
        public AuthenticationController(IConfiguration config)
        {
            secretKey = config.GetSection("settings").GetSection("secretkey").ToString();
        }

        [HttpPost("Validar")]
        public IActionResult Validar(string CI)
        {
          
            if (string.IsNullOrWhiteSpace(CI))
                return StatusCode(StatusCodes.Status401Unauthorized, new { token = "" });

            var keyBytes = Encoding.ASCII.GetBytes(secretKey);
            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, CI));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
               Subject = claims,
               Expires = DateTime.UtcNow.AddMinutes(5),
               SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandeler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandeler.CreateToken(tokenDescriptor);
            string tokenCreado = tokenHandeler.WriteToken(tokenConfig);
            return StatusCode(StatusCodes.Status200OK, new { token = tokenCreado });
           
               
            
        }
        static byte[] Encrypt(string pass)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] data = md5.ComputeHash(utf8.GetBytes(pass));
                return data;
            }
        }
    }
}
