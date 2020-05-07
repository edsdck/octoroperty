using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Octo.Core.Entities;
using Octo.Core.Services.Accommodations;

namespace Octo.Web.Controllers.Accommodations
{
    [Authorize]
    public class AccommodationController : DefaultController
    {
        private readonly IAccommodationService _accommodationService;

        public AccommodationController(IAccommodationService accommodationService)
        {
            _accommodationService = accommodationService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] AccommodationRequestModel model)
        {
            var accomodation = new Accommodation
            {
                Name = model.Name,
                Description = model.Description,
                Address = new Address
                {
                    AddressLine = model.Address.AddressLine,
                    Country = model.Address.Country,
                    City = model.Address.City,
                    Zip = model.Address.Zip
                }
            };

            try
            {
                await _accommodationService.Create(GetUserId(), accomodation);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            
            return Ok(accomodation);
        }
    }
}