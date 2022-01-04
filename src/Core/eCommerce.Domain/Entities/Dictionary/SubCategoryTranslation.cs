using System;
using System.Collections.Generic;

namespace eCommerce.Domain.Entities
{
    public partial class SubCategoryTranslation:BaseEntity
    {
        public SubCategoryTranslation()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int LanguageId { get; set; }
        public int SubCategoryId { get; set; }

        public virtual Language Language { get; set; } = null!;
        public virtual SubCategory SubCategory { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; }
    }
}
