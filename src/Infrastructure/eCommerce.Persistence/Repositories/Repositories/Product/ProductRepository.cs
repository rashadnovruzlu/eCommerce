using eCommerce.Persistence;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;


namespace eCommerce.Persistence.Repositories
{
    public class ProductRepository : EfRepository<Product>, IProductRepository
    {
        public ProductRepository(eCommerceContext context) : base(context)
        {

        }


    }
}
