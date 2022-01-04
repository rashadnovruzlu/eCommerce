using eCommerce.Persistence;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;


namespace eCommerce.Persistence.Repositories
{
    public class OrderDetailRepository : EfRepository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(eCommerceContext context) : base(context)
        {

        }


    }
}
