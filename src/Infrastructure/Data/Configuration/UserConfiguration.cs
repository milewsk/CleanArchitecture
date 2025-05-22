using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(user => user.Id);
        builder.Property(user => user.Id).ValueGeneratedNever();

        builder.Property(user => user.Email)
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(user => user.Password)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(user => user.FirstName)
            .HasMaxLength(40)
            .IsRequired();

        builder.Property(user => user.LastName)
            .HasMaxLength(50)
            .IsRequired();
    }
}
