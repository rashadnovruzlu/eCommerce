using System;
using System.Collections.Generic;

namespace eCommerce.Domain.Entities
{
    public partial class OrderStatusTranslation:BaseEntity
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public int OrderStatusId { get; set; }
        public string Name { get; set; } = null!;

        public virtual Language Language { get; set; } = null!;
        public virtual OrderStatus OrderStatus { get; set; } = null!;
    }
}
