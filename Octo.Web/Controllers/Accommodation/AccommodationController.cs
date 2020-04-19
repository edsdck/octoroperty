using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Octo.Web.Controllers.Accommodation
{
    [Authorize]
    public class AccommodationController : DefaultController
    {
        [HttpPost]
        public Task<IActionResult> CreateAccomodation(
            [FromBody] AccommodationRequestModel model)
        {
            return Task.FromResult<IActionResult>(Ok());
        }
    }
}