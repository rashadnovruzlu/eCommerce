using eCommerce.Application;
using eCommerce.Application.DTOs;
using AutoMapper;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;

namespace eCommerce.Application.Interfaces
{
    public interface IProductService : IEntityService<Product>
    {
        IEnumerable<ProductTableResponse> GetTable();
        ProductUpdateRequest GetForUpdateById(int id);
        Task EditAsync(ProductUpdateRequest model);
        void DeleteById(int id);
        Task<ProductDTO> GetById(int id);

    }
}
