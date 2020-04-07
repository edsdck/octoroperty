using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Octo.Web.Controllers
{
    public class TestController : DefaultController
    {
        [HttpGet]
        [Authorize]
        public IActionResult Authentication()
        {
            return Ok();
        }
    }
}