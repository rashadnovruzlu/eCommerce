using eCommerce.Persistence;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;


namespace eCommerce.Persistence.Repositories
{
    public class CountryRepository : EfRepository<Country>, ICountryRepository
    {
        public CountryRepository(eCommerceContext context) : base(context)
        {

        }


    }
}
