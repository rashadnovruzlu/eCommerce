using eCommerce.Persistence;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;


namespace eCommerce.Persistence.Repositories
{
    public class OrderStatusTranslationRepository : EfRepository<OrderStatusTranslation>, IOrderStatusTranslationRepository
    {
        public OrderStatusTranslationRepository(eCommerceContext context) : base(context)
        {

        }


    }
}
