using eCommerce.Persistence;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;


namespace eCommerce.Persistence.Repositories
{
    public class BrandRepository : EfRepository<Brand>, IBrandRepository
    {
        public BrandRepository(eCommerceContext context) : base(context)
        {

        }


    }
}
