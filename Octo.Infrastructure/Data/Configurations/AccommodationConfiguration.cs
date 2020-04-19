using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Octo.Core.Entities;

namespace Octo.Infrastructure.Data.Configurations
{
    public class AccommodationConfiguration : IEntityTypeConfiguration<Accommodation>
    {
        public void Configure(EntityTypeBuilder<Accommodation> builder)
        {
            builder.ToTable("Accommodations");

            builder.Property(accommodation => accommodation.Name).IsRequired();
            builder.Property(accommodation => accommodation.OwnerId).IsRequired();
        }
    }
}