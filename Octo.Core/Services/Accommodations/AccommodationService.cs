using System.Threading.Tasks;
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

        public async Task<Accommodation> Create(string userId, Accommodation accommodation)
        {
            accommodation.OwnerId = userId;

            await _repository.AddAsync(accommodation);

            return accommodation;
        }
    }
}