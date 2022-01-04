using System;
using System.Collections.Generic;

namespace eCommerce.Domain.Entities
{
    public partial class Product : BaseEntity
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ProductTranslations = new HashSet<ProductTranslation>();
        }

        public int Id { get; set; }
        public int BrendId { get; set; }
        public int SubCategoryId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Code { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public DateTime InsertDate { get; set; }

        [LeftJoinableColumn]
        public virtual Brand Brend { get; set; } = null!;
        [JoinableColumn]
        public virtual SubCategoryTranslation SubCategory { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [ChildTable]
        public virtual ICollection<ProductTranslation> ProductTranslations { get; set; }
    }
}
