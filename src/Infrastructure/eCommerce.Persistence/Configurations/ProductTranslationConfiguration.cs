
using eCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eDMS.Infrastructure.Persistence.Configurations;

public class ProductTranslationConfiguration : IEntityTypeConfiguration<ProductTranslation>
{
    public void Configure(EntityTypeBuilder<ProductTranslation> entity)


    {
        entity.ToTable("ProductTranslation");

        entity.Property(e => e.Description).HasMaxLength(4000);

        entity.Property(e => e.Name).HasMaxLength(250);

        entity.HasOne(d => d.Language)
            .WithMany(p => p.ProductTranslations)
            .HasForeignKey(d => d.LanguageId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProductTranslation_Language");

        entity.HasOne(d => d.Product)
            .WithMany(p => p.ProductTranslations)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProductTranslation_Product");
    }
}