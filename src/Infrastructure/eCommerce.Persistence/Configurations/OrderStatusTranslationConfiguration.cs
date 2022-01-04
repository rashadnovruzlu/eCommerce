
using eCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eDMS.Infrastructure.Persistence.Configurations;

public class OrderStatusTranslationConfiguration : IEntityTypeConfiguration<OrderStatusTranslation>
{
    public void Configure(EntityTypeBuilder<OrderStatusTranslation> entity)


    {
        entity.ToTable("OrderStatusTranslation");

        entity.Property(e => e.Name).HasMaxLength(50);

        entity.HasOne(d => d.Language)
            .WithMany(p => p.OrderStatusTranslations)
            .HasForeignKey(d => d.LanguageId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_OrderStatusTranslation_Language");

        entity.HasOne(d => d.OrderStatus)
            .WithMany(p => p.OrderStatusTranslations)
            .HasForeignKey(d => d.OrderStatusId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_OrderStatusTranslation_OrderStatus");
    }
}