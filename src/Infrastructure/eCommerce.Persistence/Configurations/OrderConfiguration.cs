
using eCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eDMS.Infrastructure.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> entity)


    {
        entity.ToTable("Order");

        entity.Property(e => e.InsertDate).HasColumnType("datetime");

        entity.Property(e => e.TransactionCode)
            .HasMaxLength(25)
            .IsUnicode(false)
            .IsFixedLength();

        entity.HasOne(d => d.OrderStatus)
            .WithMany(p => p.Orders)
            .HasForeignKey(d => d.OrderStatusId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Order_OrderStatus");
    }
}