using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Octo.Core.Factories
{
    public class JwtFactory : IJwtFactory
    {
        private readonly IdentitySettings _identitySettings;

        public JwtFactory(IOptions<IdentitySettings> identitySettings)
        {
            _identitySettings = identitySettings.Value;
        }

        public string GenerateJwtToken()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_identitySettings.Secret));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            
            var token = new JwtSecurityToken(
                issuer: _identitySettings.Issuer,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            var handler = new JwtSecurityTokenHandler();
            
            return handler.WriteToken(token);
        }
    }
}