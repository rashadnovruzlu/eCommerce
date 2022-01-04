
using eCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eDMS.Infrastructure.Persistence.Configurations;

public class SubCategoryTranslationConfiguration : IEntityTypeConfiguration<SubCategoryTranslation>
{
    public void Configure(EntityTypeBuilder<SubCategoryTranslation> entity)


    {
        entity.ToTable("SubCategoryTranslation");

        entity.Property(e => e.Name).HasMaxLength(250);

        entity.HasOne(d => d.Language)
            .WithMany(p => p.SubCategoryTranslations)
            .HasForeignKey(d => d.LanguageId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_SubCategoryTranslation_Language");

        entity.HasOne(d => d.SubCategory)
            .WithMany(p => p.SubCategoryTranslations)
            .HasForeignKey(d => d.SubCategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_SubCategoryTranslation_SubCategory");
    }
}