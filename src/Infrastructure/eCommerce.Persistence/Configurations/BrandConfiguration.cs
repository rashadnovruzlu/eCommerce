
using eCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eDMS.Infrastructure.Persistence.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> entity)


    {
        entity.ToTable("Brand");

        entity.Property(e => e.Name).HasMaxLength(100);

        entity.HasOne(d => d.Country)
            .WithMany(p => p.Brands)
            .HasForeignKey(d => d.CountryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Brand_Country");
    }
}