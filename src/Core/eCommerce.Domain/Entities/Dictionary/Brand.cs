using System;
using System.Collections.Generic;

namespace eCommerce.Domain.Entities
{
    [DropDown]
    public partial class Brand : BaseEntity
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        [FileterableColumn]
        public int CountryId { get; set; }
        public string Name { get; set; } = null!;

        [JoinableColumn]
        public virtual Country Country { get; set; } = null!;
        public virtual ICollection<Product> Products { get; set; }
    }
}
