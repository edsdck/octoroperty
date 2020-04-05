using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Octo.Core.Entities;

namespace Octo.Infrastructure.Data
{
    public class OctoContext : DbContext
    {
        public OctoContext(DbContextOptions<OctoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<User> Users { get; set; }
    }
}