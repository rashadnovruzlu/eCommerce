
using eCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eDMS.Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)


    {
        entity.ToTable("Product");

        entity.Property(e => e.Code).HasMaxLength(25);

        entity.Property(e => e.Description).HasMaxLength(4000);

        entity.Property(e => e.InsertDate).HasColumnType("datetime");

        entity.Property(e => e.Name).HasMaxLength(250);

        entity.HasOne(d => d.Brend)
            .WithMany(p => p.Products)
            .HasForeignKey(d => d.BrendId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Product_Brand");

        entity.HasOne(d => d.SubCategory)
            .WithMany(p => p.Products)
            .HasForeignKey(d => d.SubCategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Product_SubCategoryTranslation");
    }
}