using System;
using System.Collections.Generic;

namespace eCommerce.Domain.Entities
{
    [DropDown]
    public partial class Category : BaseEntity, ISoftDelete
    {
        public Category()
        {
            CategoryTranslations = new HashSet<CategoryTranslation>();
            SubCategories = new HashSet<SubCategory>();
        }

        public int Id { get; set; }
        [TranslatableColumn]
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; }

        [ChildTable]
        public virtual ICollection<CategoryTranslation> CategoryTranslations { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
