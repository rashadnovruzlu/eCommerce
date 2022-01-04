using System;
using System.Collections.Generic;

namespace eCommerce.Domain.Entities
{
    public partial class OrderStatus : BaseEntity
    {
        public OrderStatus()
        {
            OrderStatusTranslations = new HashSet<OrderStatusTranslation>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        [TranslatableColumn]
        public string Name { get; set; } = null!;

        [ChildTable]
        public virtual ICollection<OrderStatusTranslation> OrderStatusTranslations { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
