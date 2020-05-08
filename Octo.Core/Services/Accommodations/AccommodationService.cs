using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Octo.Core.Entities;
using Octo.SharedKernel.Interfaces;

namespace Octo.Core.Services.Accommodations
{
    public class AccommodationService : IAccommodationService
    {
        private readonly IAsyncRepository<Accommodation> _repository;

        public AccommodationService(IAsyncRepository<Accommodation> repository)
        {
            _repository = repository;
        }
        
        public async Task<IList<Accommodation>> GetListByUser(string userId)
        {
            return await _repository.Table
                .Where(accomodation => accomodation.OwnerId == userId)
                .ToListAsync();
        }
        
        public async Task<Accommodation> Get(int id)
        {
            return await _repository.Table
                .SingleOrDefaultAsync(accommodation => accommodation.Id == id);
        }

        public async Task<Accommodation> Create(string userId, Accommodation accommodation)
        {
            accommodation.OwnerId = userId;

            await _repository.AddAsync(accommodation);

            return accommodation;
        }
        
        public async Task<Accommodation> Update(int id, Accommodation updatedAccommodation)
        {
            var accommodation = await _repository.Table
                .Include(a => a.Address)
                .SingleAsync(a => a.Id == id);

            accommodation.Name = updatedAccommodation.Name;
            accommodation.Description = updatedAccommodation.Description;
            accommodation.Address.AddressLine = updatedAccommodation.Address.AddressLine;
            accommodation.Address.Country = updatedAccommodation.Address.Country;
            accommodation.Address.City = updatedAccommodation.Address.City;
            accommodation.Address.Zip = updatedAccommodation.Address.Zip;

            await _repository.UpdateAsync(accommodation);
            
            return accommodation;
        }
        
        public async Task Delete(Accommodation accommodation)
        {
            await _repository.DeleteAsync(accommodation);
        }
    }
}