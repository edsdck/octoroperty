using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Octo.Web.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        protected string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}