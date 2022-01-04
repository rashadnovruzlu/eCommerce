using eCommerce.Persistence;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Persistence.Repositories
{
    public class CategoryRepository : EfRepository<Category>, ICategoryRepository
    {
        private readonly ICategoryTranslationRepository _translationRepository;

        public CategoryRepository(ICategoryTranslationRepository translationRepository, eCommerceContext context) : base(context)
        {
            _translationRepository = translationRepository;
        }


        public IQueryable<Category> GetAllWithTranslation()
        {
            var query = from o in GetAll()
                        join f in _translationRepository.GetAll() on o.Id equals f.CategoryId
                        into s
                        from t in s.DefaultIfEmpty()
                        where t.LanguageId == Culture
                        select new Category
                        {
                            Id = o.Id,
                            Name = t.Name,
                            IsDeleted = o.IsDeleted,

                        };

            return query;
        }

    }
}
