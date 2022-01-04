using eCommerce.Persistence;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;


namespace eCommerce.Persistence.Repositories
{
    public class LanguageRepository : EfRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(eCommerceContext context) : base(context)
        {

        }


    }
}
