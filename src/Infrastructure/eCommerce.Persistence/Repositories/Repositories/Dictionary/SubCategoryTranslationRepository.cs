using eCommerce.Persistence;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;


namespace eCommerce.Persistence.Repositories
{
    public class SubCategoryTranslationRepository : EfRepository<SubCategoryTranslation>, ISubCategoryTranslationRepository
    {
        public SubCategoryTranslationRepository(eCommerceContext context) : base(context)
        {

        }


    }
}
