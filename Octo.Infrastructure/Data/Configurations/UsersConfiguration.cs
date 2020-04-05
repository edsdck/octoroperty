using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Octo.Core.Entities;

namespace Octo.Infrastructure.Data.Configurations
{
    public class UsersConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(prop => prop.Username)
                .IsRequired();
            builder.Property(prop => prop.PasswordHash)
                .IsRequired();
            builder.Property(prop => prop.PasswordSalt)
                .IsRequired();
        }
    }
}