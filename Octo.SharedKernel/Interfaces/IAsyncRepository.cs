using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Octo.SharedKernel.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync<TKey>(TKey id);
        
        Task<IReadOnlyList<T>> ListAllAsync();
        
        Task<T> AddAsync(T entity);
        
        Task UpdateAsync(T entity);
        
        Task DeleteAsync(T entity);
        
        DbSet<T> Table { get; }
    }
}