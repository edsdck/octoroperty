using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Octo.Core.Entities;
using Octo.Core.Factories;
using Octo.Infrastructure.Data;
using Octo.Web.Filters;

namespace Octo.Web.Controllers.Auth
{
    public class AuthController : DefaultController
    {
        private readonly UserManager<OctoUser> _userManager;
        private readonly IJwtFactory _jwtFactory;

        public AuthController(UserManager<OctoUser> userManager,
            IJwtFactory jwtFactory)
        {
            _userManager = userManager;
            _jwtFactory = jwtFactory;
        }
        
        [HttpPost("Register"), AllowAnonymous]
        [ValidateModel]
        public async Task<IActionResult> Register(RegisterRequestModel registerInfo)
        {
            var result = await _userManager.CreateAsync(
                new OctoUser { UserName = registerInfo.Username }, registerInfo.Password );

            if (result.Succeeded)
            {
                return Accepted();
            }
            
            return BadRequest(result.Errors);
        }
        
        [HttpPost("Login"), AllowAnonymous]
        [ValidateModel]
        public async Task<IActionResult> Login(LoginRequestModel loginRequestInfo)
        {
            var user = await _userManager.FindByNameAsync(loginRequestInfo.Username);
            var isCorrectCredentials = await _userManager.CheckPasswordAsync(user, loginRequestInfo.Password);
            
            if (!isCorrectCredentials)
            {
                return Unauthorized();
            }

            var jwtToken = _jwtFactory.GenerateJwtToken(user);

            return Ok(jwtToken);
        }
    }
}