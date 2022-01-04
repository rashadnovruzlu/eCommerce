using eCommerce.Domain.Entities;

namespace eCommerce.Application.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        IQueryable<Category> GetAllWithTranslation();
    }
}
