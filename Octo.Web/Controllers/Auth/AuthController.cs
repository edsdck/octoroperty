using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Octo.Infrastructure.Data;

namespace Octo.Web.Controllers.Auth
{
    public class AuthController : DefaultController
    {
        private readonly UserManager<OctoUser> _userManager;

        public AuthController(UserManager<OctoUser> userManager)
        {
            _userManager = userManager;
        }
        
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            var result = await _userManager.CreateAsync(
                new OctoUser { UserName = registerModel.Username }, registerModel.Password);

            if (result.Succeeded)
            {
                return Accepted();
            }

            return BadRequest(result.Errors);
        }
        
        [HttpPost]
        public async Task<IActionResult> GenerateToken(RegisterModel loginInfo)
        {
            var user = await _userManager.FindByNameAsync(loginInfo.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginInfo.Password))
            {
                return Unauthorized();
            }

            var claims = new List<Claim>();

            var key = new SymmetricSecurityKey(Convert.FromBase64String("cmFuZG9tcmFuZG9tcmFuZG9t"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: "api",
                audience: "api",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds
            );

            var t = new JwtSecurityTokenHandler();
            var to = t.WriteToken(token);
            
            return Ok(new
            {
                token = to
            });
        }
    }
}