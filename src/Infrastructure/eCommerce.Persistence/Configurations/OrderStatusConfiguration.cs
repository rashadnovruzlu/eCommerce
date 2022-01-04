
using eCommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eDMS.Infrastructure.Persistence.Configurations;

public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
{
    public void Configure(EntityTypeBuilder<OrderStatus> entity)


    {
        entity.ToTable("OrderStatus");

        entity.Property(e => e.Name).HasMaxLength(50);
    }
}