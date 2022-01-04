using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Interfaces
{
    public interface ISubCategoryTranslationService : IEntityService<SubCategoryTranslation>
    {
        IEnumerable<SubCategoryTranslationTableResponse> GetTable();
        SubCategoryTranslationUpdateRequest GetForUpdateById(int id);
        Task EditAsync(SubCategoryTranslationUpdateRequest model);
        void DeleteById(int id);
        Task<SubCategoryTranslationDTO> GetById(int id);

    }
}
