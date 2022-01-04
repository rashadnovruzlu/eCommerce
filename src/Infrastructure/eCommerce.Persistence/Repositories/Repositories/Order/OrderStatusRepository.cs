using eCommerce.Persistence;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Persistence.Repositories
{
    public class OrderStatusRepository : EfRepository<OrderStatus>, IOrderStatusRepository
    {
        private readonly IOrderStatusTranslationRepository _translationRepository;

        public OrderStatusRepository(IOrderStatusTranslationRepository translationRepository, eCommerceContext context) : base(context)
        {
            _translationRepository = translationRepository;
        }


        public IQueryable<OrderStatus> GetAllWithTranslation()
        {
            var query = from o in GetAll()
                        join f in _translationRepository.GetAll() on o.Id equals f.OrderStatusId
                        into s
                        from t in s.DefaultIfEmpty()
                        where t.LanguageId == Culture
                        select new OrderStatus
                        {
                            Id = o.Id,
                            Name = t.Name,

                        };

            return query;
        }

    }
}
