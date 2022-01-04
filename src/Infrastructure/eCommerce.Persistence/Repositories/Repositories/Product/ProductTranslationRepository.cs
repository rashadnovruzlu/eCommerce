using eCommerce.Persistence;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;


namespace eCommerce.Persistence.Repositories
{
    public class ProductTranslationRepository : EfRepository<ProductTranslation>, IProductTranslationRepository
    {
        public ProductTranslationRepository(eCommerceContext context) : base(context)
        {

        }


    }
}
