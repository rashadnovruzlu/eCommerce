using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Interfaces
{
    public interface ICategoryService : IEntityService<Category>
    {
        IEnumerable<DropDownDto> GetList();
        IEnumerable<DropDownDto> GetPageableList(DropdownRequest request);
        IEnumerable<CategoryTableResponse> GetTable();
        CategoryUpdateRequest GetForUpdateById(int id);
        Task EditAsync(CategoryUpdateRequest model);
        void DeleteById(int id);
        Task<CategoryDTO> GetById(int id);

    }
}
