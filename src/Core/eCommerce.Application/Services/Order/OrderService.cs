using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Services
{
    public class OrderService : BaseEntityService<Order>, IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _repository;

        private readonly IOrderStatusRepository _orderStatusRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderService(IMapper mapper, IOrderRepository repository, IOrderStatusRepository orderStatusRepository, IOrderDetailRepository orderDetailRepository) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;
            _orderStatusRepository = orderStatusRepository;
            _orderDetailRepository = orderDetailRepository;

        }



        public OrderTableListResponse GetTable(PagingRequest pagingRequest)
        {
            var query = from o in _repository.GetAll()
                        join b in _orderStatusRepository.GetAllWithTranslation() on o.OrderStatusId equals b.Id
                        select new OrderTableResponse
                        {
                            Id = o.Id,
                            TransactionCode = o.TransactionCode,
                            OrderStatusId = o.OrderStatusId,
                            InsertDate = o.InsertDate,
                            OrderStatusName = b.Name,

                        };


            query = AddFilter(query, pagingRequest);


            return new OrderTableListResponse { Count = query.Count(), Data = query.ToList() };

        }
        public OrderUpdateRequest GetForUpdateById(int id)
        {
            var entity = IncludeMany(x => x.Id == id, x => x.OrderDetails).SingleOrDefault();
            var model = _mapper.Map<OrderUpdateRequest>(entity);

            return model;
        }
        public async Task EditAsync(OrderUpdateRequest model)
        {
            var entity = _mapper.Map<Order>(model);

            await UpdateAsync(entity);


            foreach (var id in model.DeletedOrderDetails)
            {
                var deleted = new OrderDetail { Id = id };

                _orderDetailRepository.Delete(deleted);
            }
        }
        public void DeleteById(int id)
        {
            Order entity = new Order { Id = id };

            Delete(entity);
        }
        public async Task<OrderDTO> GetById(int id)
        {
            var entity = await GetAsync(id);

            return _mapper.Map<OrderDTO>(entity);
        }

    }

}
