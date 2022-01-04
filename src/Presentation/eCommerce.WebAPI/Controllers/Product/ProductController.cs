using eCommerce.Application.DTOs;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;
using eCommerce.Application;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace eCommerce.Web.Controllers;

public class ProductController : BaseController
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    /// <summary>
    /// Add new Product
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("Add")]
    public async Task<IActionResult> Add(ProductAddRequest model)
    {
        var entity = _mapper.Map<Product>(model);

        await _productService.AddAsync(entity);

        var dto = _mapper.Map<ProductDTO>(entity);

        return Ok(dto);
    }


    /// <summary>
    /// Update Product
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("Update")]
    public async Task<IActionResult> Update(ProductUpdateRequest model)
    {
        await _productService.EditAsync(model);

        return Ok(null);
    }


    /// <summary>
    /// Get Product data by ID (This endpoint generally used for update Product)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetForUpdateById")]
    public IActionResult GetForUpdateById(string id)
    {
        var result = _productService.GetForUpdateById(Decrypt(id));

        return Ok(result);
    }


    /// <summary>
    /// Get Product data by ID (This endpoint generally used for view of Product data. It does not contains relations)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _productService.GetById(Decrypt(id));

        return Ok(result);
    }

    /// <summary>
    /// Delete Product
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("Delete")]
    public IActionResult Delete(string id)
    {
        _productService.DeleteById(Decrypt(id));

        return Ok();
    }



    /// <summary>
    ///  Get all Product data.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetTable")]
    public IActionResult GetTable()
    {
        var result = _productService.GetTable();

        return Ok(result);
    }




}
