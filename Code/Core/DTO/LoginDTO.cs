using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Core.DTO
{
    public class LoginDTO
    {
        public string User { get; set; }
        public string Password { get; set; }
        public string GenerateToken(string keyConfig)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, User)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyConfig));
            var credentials = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }

        public bool ValidateUser() => User == "user" && Password == "123";

    }
}
