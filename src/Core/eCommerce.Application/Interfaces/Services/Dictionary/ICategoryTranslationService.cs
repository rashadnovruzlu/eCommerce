using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Interfaces
{
    public interface ICategoryTranslationService : IEntityService<CategoryTranslation>
    {
        IEnumerable<CategoryTranslationTableResponse> GetTable();
        CategoryTranslationUpdateRequest GetForUpdateById(int id);
        Task EditAsync(CategoryTranslationUpdateRequest model);
        void DeleteById(int id);
        Task<CategoryTranslationDTO> GetById(int id);

    }
}
