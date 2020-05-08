using System.Collections.Generic;
using System.Threading.Tasks;
using Octo.Core.Entities;

namespace Octo.Core.Services.Accommodations
{
    public interface IAccommodationService
    {
        Task<Accommodation> Get(int id);
        
        Task<Accommodation> Create(string userId, Accommodation accommodation);

        Task<Accommodation> Update(int id, Accommodation updatedAccommodation);

        Task Delete(Accommodation accommodation);

        Task<IList<Accommodation>> GetListByUser(string userId);
    }
}