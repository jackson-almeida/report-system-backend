using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace sistema_relatorios.utils
{
    public class TokenGenerator
    {
        private const string Secret = "chave-secreta-sistema-relatorios-backend";

        public static string GenerateToken(string email)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, email)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Secret));

            var token = new JwtSecurityToken(
                issuer: "sistema-relatorios-backend",
                audience: "sistema-relatorios-frontend",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(24),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
