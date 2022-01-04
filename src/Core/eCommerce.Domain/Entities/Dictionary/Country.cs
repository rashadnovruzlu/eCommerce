using System;
using System.Collections.Generic;

namespace eCommerce.Domain.Entities
{
    public partial class Country:BaseEntity
    {
        public Country()
        {
            Brands = new HashSet<Brand>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Brand> Brands { get; set; }
    }
}
