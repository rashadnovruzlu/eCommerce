using eCommerce.Domain.Entities;

namespace eCommerce.Application.Interfaces
{
    public interface IOrderStatusRepository : IRepository<OrderStatus>
    {
        IQueryable<OrderStatus> GetAllWithTranslation();
    }
}
