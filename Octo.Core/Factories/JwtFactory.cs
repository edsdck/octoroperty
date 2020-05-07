using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Octo.Core.Entities;

namespace Octo.Core.Factories
{
    public class JwtFactory : IJwtFactory
    {
        private readonly IdentitySettings _identitySettings;

        public JwtFactory(IOptions<IdentitySettings> identitySettings)
        {
            _identitySettings = identitySettings.Value;
        }

        public string GenerateJwtToken(OctoUser user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_identitySettings.Secret));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                }),
                Expires = DateTime.Now.AddHours(6),
                Issuer = _identitySettings.Issuer,
                SigningCredentials = credentials
            };
            
            /*var token = new JwtSecurityToken(
                issuer: _identitySettings.Issuer,
                expires: DateTime.Now.AddHours(6),
                signingCredentials: credentials);*/

            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(tokenDescriptor);
            
            return handler.WriteToken(token);
        }
    }
}