using eCommerce.Application.DTOs;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;
using eCommerce.Application;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace eCommerce.Web.Controllers;

public class ProductTranslationController : BaseController
{
    private readonly IProductTranslationService _productTranslationService;
    private readonly IMapper _mapper;

    public ProductTranslationController(IProductTranslationService productTranslationService, IMapper mapper)
    {
        _productTranslationService = productTranslationService;
        _mapper = mapper;
    }

    /// <summary>
    /// Add new ProductTranslation
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("Add")]
    public async Task<IActionResult> Add(ProductTranslationAddRequest model)
    {
        var entity = _mapper.Map<ProductTranslation>(model);

        await _productTranslationService.AddAsync(entity);

        var dto = _mapper.Map<ProductTranslationDTO>(entity);

        return Ok(dto);
    }


    /// <summary>
    /// Update ProductTranslation
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("Update")]
    public async Task<IActionResult> Update(ProductTranslationUpdateRequest model)
    {
        await _productTranslationService.EditAsync(model);

        return Ok(null);
    }


    /// <summary>
    /// Get ProductTranslation data by ID (This endpoint generally used for update ProductTranslation)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetForUpdateById")]
    public IActionResult GetForUpdateById(string id)
    {
        var result = _productTranslationService.GetForUpdateById(Decrypt(id));

        return Ok(result);
    }


    /// <summary>
    /// Get ProductTranslation data by ID (This endpoint generally used for view of ProductTranslation data. It does not contains relations)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _productTranslationService.GetById(Decrypt(id));

        return Ok(result);
    }

    /// <summary>
    /// Delete ProductTranslation
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("Delete")]
    public IActionResult Delete(string id)
    {
        _productTranslationService.DeleteById(Decrypt(id));

        return Ok();
    }



    /// <summary>
    ///  Get all ProductTranslation data.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetTable")]
    public IActionResult GetTable()
    {
        var result = _productTranslationService.GetTable();

        return Ok(result);
    }




}
