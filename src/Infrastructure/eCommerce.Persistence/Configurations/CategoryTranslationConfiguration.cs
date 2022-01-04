
using eCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eDMS.Infrastructure.Persistence.Configurations;

public class CategoryTranslationConfiguration : IEntityTypeConfiguration<CategoryTranslation>
{
    public void Configure(EntityTypeBuilder<CategoryTranslation> entity)


    {
        entity.ToTable("CategoryTranslation");

        entity.Property(e => e.Name).HasMaxLength(250);

        entity.HasOne(d => d.Category)
            .WithMany(p => p.CategoryTranslations)
            .HasForeignKey(d => d.CategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_CategoryTranslation_Category");

        entity.HasOne(d => d.Language)
            .WithMany(p => p.CategoryTranslations)
            .HasForeignKey(d => d.LanguageId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_CategoryTranslation_Language");
    }
}