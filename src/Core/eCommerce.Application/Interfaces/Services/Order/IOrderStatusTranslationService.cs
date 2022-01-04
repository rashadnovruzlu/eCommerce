using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Interfaces
{
    public interface IOrderStatusTranslationService : IEntityService<OrderStatusTranslation>
    {
        IEnumerable<OrderStatusTranslationTableResponse> GetTable();
        OrderStatusTranslationUpdateRequest GetForUpdateById(int id);
        Task EditAsync(OrderStatusTranslationUpdateRequest model);
        void DeleteById(int id);
        Task<OrderStatusTranslationDTO> GetById(int id);

    }
}
