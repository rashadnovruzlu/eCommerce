using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Interfaces
{
    public interface ILanguageService : IEntityService<Language>
    {
        IEnumerable<LanguageTableResponse> GetTable();
        LanguageUpdateRequest GetForUpdateById(int id);
        Task EditAsync(LanguageUpdateRequest model);
        void DeleteById(int id);
        Task<LanguageDTO> GetById(int id);

    }
}
