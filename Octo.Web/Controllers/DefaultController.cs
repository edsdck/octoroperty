using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Octo.Web.Controllers
{
    [Route("v1/api/[controller]/")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        protected string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}