using Microsoft.EntityFrameworkCore;

namespace Octo.Infrastructure.Data
{
    public class OctoContext : DbContext
    {
        public OctoContext(DbContextOptions<OctoContext> options) : base(options)
        {
        }
    }
}