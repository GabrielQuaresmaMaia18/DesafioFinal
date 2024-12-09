using Microsoft.IdentityModel.Tokens;
using DesafioFinal.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DesafioFinal.Helpers
{
    public class JwtHelper
    {
        private const string SecretKey = "minha_chave_super_super_secreta_1234567";

        public string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMonths(1),
                signingCredentials: creds);  
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
