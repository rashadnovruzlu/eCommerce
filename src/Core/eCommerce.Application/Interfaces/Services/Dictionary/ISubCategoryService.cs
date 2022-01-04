using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Interfaces
{
    public interface ISubCategoryService : IEntityService<SubCategory>
    {
        IEnumerable<DropDownDto> GetList();
        IEnumerable<DropDownDto> GetListByCategoryId(int categoryId);
        IEnumerable<DropDownDto> GetPageableList(DropdownRequest request);
        IEnumerable<DropDownDto> GetPageableListByCategoryId(DropdownRequest request);
        IEnumerable<SubCategoryTableResponse> GetTable();
        IEnumerable<SubCategoryDTO> GetTableByCategoryId(int categoryId);
        SubCategoryUpdateRequest GetForUpdateById(int id);
        Task EditAsync(SubCategoryUpdateRequest model);
        void DeleteById(int id);
        Task<SubCategoryDTO> GetById(int id);

    }
}
