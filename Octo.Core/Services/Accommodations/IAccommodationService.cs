using System.Threading.Tasks;
using Octo.Core.Entities;

namespace Octo.Core.Services.Accommodations
{
    public interface IAccommodationService
    {
        Task<Accommodation> Create(string userId, Accommodation accommodation);
    }
}