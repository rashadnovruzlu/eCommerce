using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Interfaces
{
    public interface IBrandService : IEntityService<Brand>
    {
        IEnumerable<DropDownDto> GetList();
        IEnumerable<DropDownDto> GetListCountryId(int CountryId);
        IEnumerable<DropDownDto> GetPageableList(DropdownRequest request);
        IEnumerable<DropDownDto> GetPageableListByCountryId(DropdownRequest request);
        IEnumerable<BrandTableResponse> GetTable();
        IEnumerable<BrandDTO> GetTableByCountryId(int countryId);
        BrandUpdateRequest GetForUpdateById(int id);
        Task EditAsync(BrandUpdateRequest model);
        void DeleteById(int id);
        Task<BrandDTO> GetById(int id);

    }
}
