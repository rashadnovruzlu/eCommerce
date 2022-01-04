using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Interfaces
{
    public interface IOrderStatusService : IEntityService<OrderStatus>
    {
        IEnumerable<OrderStatusTableResponse> GetTable();
        OrderStatusUpdateRequest GetForUpdateById(int id);
        Task EditAsync(OrderStatusUpdateRequest model);
        void DeleteById(int id);
        Task<OrderStatusDTO> GetById(int id);

    }
}
