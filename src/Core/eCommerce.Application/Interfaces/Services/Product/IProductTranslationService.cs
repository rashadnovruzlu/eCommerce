using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Interfaces
{
    public interface IProductTranslationService : IEntityService<ProductTranslation>
    {
        IEnumerable<ProductTranslationTableResponse> GetTable();
        ProductTranslationUpdateRequest GetForUpdateById(int id);
        Task EditAsync(ProductTranslationUpdateRequest model);
        void DeleteById(int id);
        Task<ProductTranslationDTO> GetById(int id);

    }
}
