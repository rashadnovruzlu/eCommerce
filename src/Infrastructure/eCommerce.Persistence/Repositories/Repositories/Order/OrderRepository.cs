using eCommerce.Persistence;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;


namespace eCommerce.Persistence.Repositories
{
    public class OrderRepository : EfRepository<Order>, IOrderRepository
    {
        public OrderRepository(eCommerceContext context) : base(context)
        {

        }


    }
}
