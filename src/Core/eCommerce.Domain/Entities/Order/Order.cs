using System;
using System.Collections.Generic;

namespace eCommerce.Domain.Entities
{
    [ServerSidePagination]
    public partial class Order : BaseEntity
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string TransactionCode { get; set; } = null!;
        public int OrderStatusId { get; set; }
        public DateTime InsertDate { get; set; }

        [JoinableColumn]
        public virtual OrderStatus OrderStatus { get; set; } = null!;
        [ChildTable]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
