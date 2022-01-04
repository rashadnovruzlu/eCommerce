using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Services
{
    public class OrderDetailService : BaseEntityService<OrderDetail>, IOrderDetailService
    {
        private readonly IMapper _mapper;
        private readonly IOrderDetailRepository _repository;


        public OrderDetailService(IMapper mapper, IOrderDetailRepository repository) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;

        }



        public IEnumerable<OrderDetailTableResponse> GetTable()
        {
            var query = from o in _repository.GetAll()

                        select new OrderDetailTableResponse
                        {
                            Id = o.Id,
                            OrderId = o.OrderId,
                            ProductId = o.ProductId,
                            Price = o.Price,
                            Count = o.Count,

                        };

            return query;

        }
        public OrderDetailUpdateRequest GetForUpdateById(int id)
        {
            var entity = Get(id);
            var model = _mapper.Map<OrderDetailUpdateRequest>(entity);

            return model;
        }
        public async Task EditAsync(OrderDetailUpdateRequest model)
        {
            var entity = _mapper.Map<OrderDetail>(model);

            await UpdateAsync(entity);


        }
        public void DeleteById(int id)
        {
            OrderDetail entity = new OrderDetail { Id = id };

            Delete(entity);
        }
        public async Task<OrderDetailDTO> GetById(int id)
        {
            var entity = await GetAsync(id);

            return _mapper.Map<OrderDetailDTO>(entity);
        }

    }

}
