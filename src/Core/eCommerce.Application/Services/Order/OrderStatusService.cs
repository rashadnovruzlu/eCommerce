using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Services
{
    public class OrderStatusService : BaseEntityService<OrderStatus>, IOrderStatusService
    {
        private readonly IMapper _mapper;
        private readonly IOrderStatusRepository _repository;

        private readonly IOrderStatusTranslationRepository _orderStatusTranslationRepository;

        public OrderStatusService(IMapper mapper, IOrderStatusRepository repository, IOrderStatusTranslationRepository orderStatusTranslationRepository) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;
            _orderStatusTranslationRepository = orderStatusTranslationRepository;

        }



        public IEnumerable<OrderStatusTableResponse> GetTable()
        {
            var query = from o in _repository.GetAllWithTranslation()

                        select new OrderStatusTableResponse
                        {
                            Id = o.Id,
                            Name = o.Name,

                        };

            return query;

        }
        public OrderStatusUpdateRequest GetForUpdateById(int id)
        {
            var entity = IncludeMany(x => x.Id == id, x => x.OrderStatusTranslations).SingleOrDefault();
            var model = _mapper.Map<OrderStatusUpdateRequest>(entity);

            return model;
        }
        public async Task EditAsync(OrderStatusUpdateRequest model)
        {
            var entity = _mapper.Map<OrderStatus>(model);

            await UpdateAsync(entity);


            foreach (var id in model.DeletedOrderStatusTranslations)
            {
                var deleted = new OrderStatusTranslation { Id = id };

                _orderStatusTranslationRepository.Delete(deleted);
            }
        }
        public void DeleteById(int id)
        {
            OrderStatus entity = new OrderStatus { Id = id };

            Delete(entity);
        }
        public async Task<OrderStatusDTO> GetById(int id)
        {
            var entity = await GetAsync(id);

            return _mapper.Map<OrderStatusDTO>(entity);
        }

    }

}
