
using eCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eDMS.Infrastructure.Persistence.Configurations;

public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
{
    public void Configure(EntityTypeBuilder<SubCategory> entity)


    {
        entity.ToTable("SubCategory");

        entity.Property(e => e.Name).HasMaxLength(250);

        entity.HasOne(d => d.Category)
            .WithMany(p => p.SubCategories)
            .HasForeignKey(d => d.CategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_SubCategory_Category");
    }
}