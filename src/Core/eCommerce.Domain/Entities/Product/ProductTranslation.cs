using System;
using System.Collections.Generic;

namespace eCommerce.Domain.Entities
{
    public partial class ProductTranslation:BaseEntity
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public virtual Language Language { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
