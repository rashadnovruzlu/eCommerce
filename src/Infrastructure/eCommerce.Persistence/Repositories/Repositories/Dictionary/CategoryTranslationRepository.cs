using eCommerce.Persistence;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;


namespace eCommerce.Persistence.Repositories
{
    public class CategoryTranslationRepository : EfRepository<CategoryTranslation>, ICategoryTranslationRepository
    {
        public CategoryTranslationRepository(eCommerceContext context) : base(context)
        {

        }


    }
}
