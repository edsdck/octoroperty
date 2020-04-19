using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Octo.Core.Entities;

namespace Octo.Infrastructure.Data
{
    public class OctoContext : IdentityDbContext<OctoUser>
    {
        public OctoContext(DbContextOptions<OctoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Accommodation> Accommodations { get; set; }
    }
}