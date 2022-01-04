using System;
using System.Collections.Generic;

namespace eCommerce.Domain.Entities
{
    [DropDown]
    public partial class SubCategory : BaseEntity, ISoftDelete
    {
        public SubCategory()
        {
            SubCategoryTranslations = new HashSet<SubCategoryTranslation>();
        }

        public int Id { get; set; }
        [FileterableColumn]
        public int CategoryId { get; set; }
        [TranslatableColumn]
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual Category Category { get; set; } = null!;
        [ChildTable]
        public virtual ICollection<SubCategoryTranslation> SubCategoryTranslations { get; set; }
    }
}
