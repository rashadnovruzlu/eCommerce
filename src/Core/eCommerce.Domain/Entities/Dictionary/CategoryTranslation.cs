using System;
using System.Collections.Generic;

namespace eCommerce.Domain.Entities
{
    public partial class CategoryTranslation:BaseEntity
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; } = null!;

        public virtual Category Category { get; set; } = null!;
        public virtual Language Language { get; set; } = null!;
    }
}
