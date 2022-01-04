using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Interfaces
{
    public interface IOrderService : IEntityService<Order>
    {
        OrderTableListResponse GetTable(PagingRequest pagingRequest);
        OrderUpdateRequest GetForUpdateById(int id);
        Task EditAsync(OrderUpdateRequest model);
        void DeleteById(int id);
        Task<OrderDTO> GetById(int id);

    }
}
