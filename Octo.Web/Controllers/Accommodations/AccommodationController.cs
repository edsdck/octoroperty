using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Octo.Core.Entities;
using Octo.Core.Services.Accommodations;

namespace Octo.Web.Controllers.Accommodations
{
    [Authorize]
    public class AccommodationsController : DefaultController
    {
        private readonly IAccommodationService _accommodationService;

        public AccommodationsController(IAccommodationService accommodationService)
        {
            _accommodationService = accommodationService;
        }
        
        [HttpGet]
        [Route("-/users/{id}")]
        public async Task<IActionResult> GetUserList(string id)
        {
            var accommodation = await _accommodationService.GetListByUser(id);

            return Ok(accommodation);
        }
        
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var accommodation = await _accommodationService.Get(id);

            if (accommodation is null)
            {
                return BadRequest();
            }
            
            if (accommodation.OwnerId != GetUserId())
            {
                return Unauthorized();
            }

            return Ok(accommodation);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] AccommodationRequestModel model)
        {
            var accommodation = new Accommodation
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

            await _accommodationService.Create(GetUserId(), accommodation);

            return Ok(accommodation);
        }
        
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id,
            [FromBody] AccommodationRequestModel model)
        {
            var accommodation = await _accommodationService.Get(id);

            if (accommodation is null)
            {
                return BadRequest();
            }
            
            if (accommodation.OwnerId != GetUserId())
            {
                return Unauthorized();
            }
            
            var updatedAccomodation = new Accommodation
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

            await _accommodationService.Update(id, updatedAccomodation);
           
            return Ok(accommodation);
        }
        
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var accommodation = await _accommodationService.Get(id);

            if (accommodation is null)
            {
                return BadRequest();
            }
                
            if (accommodation.OwnerId != GetUserId())
            {
                return Unauthorized();
            }

            await _accommodationService.Delete(accommodation);
           
            return Ok();
        }
    }
}