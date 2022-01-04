using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Interfaces
{
    public interface IOrderDetailService : IEntityService<OrderDetail>
    {
        IEnumerable<OrderDetailTableResponse> GetTable();
        OrderDetailUpdateRequest GetForUpdateById(int id);
        Task EditAsync(OrderDetailUpdateRequest model);
        void DeleteById(int id);
        Task<OrderDetailDTO> GetById(int id);

    }
}
