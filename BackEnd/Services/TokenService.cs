using BackEnd.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackEnd.Services
{
    public class TokenService : ITokenService
    {
        public string GerarToken(string key, string issuer, string audience, Usuario usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.UserName),
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString()),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var credentials = new SigningCredentials(securityKey,
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: issuer, 
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            var TokenHandler = new JwtSecurityTokenHandler();
            var stringToken = TokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
