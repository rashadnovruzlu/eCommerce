
using eCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eDMS.Infrastructure.Persistence.Configurations;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> entity)


    {
        entity.ToTable("Language");

        entity.Property(e => e.Culture)
            .HasMaxLength(10)
            .IsUnicode(false)
            .IsFixedLength();

        entity.Property(e => e.Name)
            .HasMaxLength(5)
            .IsUnicode(false)
            .IsFixedLength();
    }
}