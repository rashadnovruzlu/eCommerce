using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Services
{
    public class OrderStatusTranslationService : BaseEntityService<OrderStatusTranslation>, IOrderStatusTranslationService
    {
        private readonly IMapper _mapper;
        private readonly IOrderStatusTranslationRepository _repository;


        public OrderStatusTranslationService(IMapper mapper, IOrderStatusTranslationRepository repository) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;

        }



        public IEnumerable<OrderStatusTranslationTableResponse> GetTable()
        {
            var query = from o in _repository.GetAll()

                        select new OrderStatusTranslationTableResponse
                        {
                            Id = o.Id,
                            LanguageId = o.LanguageId,
                            OrderStatusId = o.OrderStatusId,
                            Name = o.Name,

                        };

            return query;

        }
        public OrderStatusTranslationUpdateRequest GetForUpdateById(int id)
        {
            var entity = Get(id);
            var model = _mapper.Map<OrderStatusTranslationUpdateRequest>(entity);

            return model;
        }
        public async Task EditAsync(OrderStatusTranslationUpdateRequest model)
        {
            var entity = _mapper.Map<OrderStatusTranslation>(model);

            await UpdateAsync(entity);


        }
        public void DeleteById(int id)
        {
            OrderStatusTranslation entity = new OrderStatusTranslation { Id = id };

            Delete(entity);
        }
        public async Task<OrderStatusTranslationDTO> GetById(int id)
        {
            var entity = await GetAsync(id);

            return _mapper.Map<OrderStatusTranslationDTO>(entity);
        }

    }

}
