using System;
using System.Collections.Generic;

namespace eCommerce.Domain.Entities
{
    public partial class OrderDetail:BaseEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }

        public virtual Order Order { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
