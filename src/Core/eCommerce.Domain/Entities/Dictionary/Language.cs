using System;
using System.Collections.Generic;

namespace eCommerce.Domain.Entities
{
    public partial class Language:BaseEntity
    {
        public Language()
        {
            CategoryTranslations = new HashSet<CategoryTranslation>();
            OrderStatusTranslations = new HashSet<OrderStatusTranslation>();
            ProductTranslations = new HashSet<ProductTranslation>();
            SubCategoryTranslations = new HashSet<SubCategoryTranslation>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Culture { get; set; } = null!;

        public virtual ICollection<CategoryTranslation> CategoryTranslations { get; set; }
        public virtual ICollection<OrderStatusTranslation> OrderStatusTranslations { get; set; }
        public virtual ICollection<ProductTranslation> ProductTranslations { get; set; }
        public virtual ICollection<SubCategoryTranslation> SubCategoryTranslations { get; set; }
    }
}
