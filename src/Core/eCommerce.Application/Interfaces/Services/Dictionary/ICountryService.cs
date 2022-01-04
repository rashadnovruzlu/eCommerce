using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Interfaces
{
    public interface ICountryService : IEntityService<Country>
    {
        IEnumerable<CountryTableResponse> GetTable();
        CountryUpdateRequest GetForUpdateById(int id);
        Task EditAsync(CountryUpdateRequest model);
        void DeleteById(int id);
        Task<CountryDTO> GetById(int id);

    }
}
