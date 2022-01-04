using eCommerce.Domain.Entities;

namespace eCommerce.Application.Interfaces
{
    public interface ISubCategoryRepository : IRepository<SubCategory>
    {
        IQueryable<SubCategory> GetAllWithTranslation();
    }
}
