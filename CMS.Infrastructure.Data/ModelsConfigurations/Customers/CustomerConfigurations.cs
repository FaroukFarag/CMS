using CMS.Domain.Models.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.Data.ModelsConfigurations.Customers;

public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(c => c.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(c => c.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(c => c.Email)
            .IsUnique();

        builder.Property(c => c.Email)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Phone)
            .HasMaxLength(15)
            .IsRequired(false);

        builder.Property(c => c.Address)
            .HasMaxLength(250)
            .IsRequired(false);
    }
}
