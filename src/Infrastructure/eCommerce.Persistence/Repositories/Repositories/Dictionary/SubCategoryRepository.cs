using eCommerce.Persistence;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Persistence.Repositories
{
    public class SubCategoryRepository : EfRepository<SubCategory>, ISubCategoryRepository
    {
        private readonly ISubCategoryTranslationRepository _translationRepository;

        public SubCategoryRepository(ISubCategoryTranslationRepository translationRepository, eCommerceContext context) : base(context)
        {
            _translationRepository = translationRepository;
        }


        public IQueryable<SubCategory> GetAllWithTranslation()
        {
            var query = from o in GetAll()
                        join f in _translationRepository.GetAll() on o.Id equals f.SubCategoryId
                        into s
                        from t in s.DefaultIfEmpty()
                        where t.LanguageId == Culture
                        select new SubCategory
                        {
                            Id = o.Id,
                            CategoryId = o.CategoryId,
                            Name = t.Name,
                            IsDeleted = o.IsDeleted,

                        };

            return query;
        }

    }
}
