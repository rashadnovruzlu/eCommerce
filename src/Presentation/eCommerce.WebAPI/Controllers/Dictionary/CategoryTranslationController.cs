using eCommerce.Application.DTOs;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;
using eCommerce.Application;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace eCommerce.Web.Controllers;

public class CategoryTranslationController : BaseController
{
    private readonly ICategoryTranslationService _categoryTranslationService;
    private readonly IMapper _mapper;

    public CategoryTranslationController(ICategoryTranslationService categoryTranslationService, IMapper mapper)
    {
        _categoryTranslationService = categoryTranslationService;
        _mapper = mapper;
    }

    /// <summary>
    /// Add new CategoryTranslation
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("Add")]
    public async Task<IActionResult> Add(CategoryTranslationAddRequest model)
    {
        var entity = _mapper.Map<CategoryTranslation>(model);

        await _categoryTranslationService.AddAsync(entity);

        var dto = _mapper.Map<CategoryTranslationDTO>(entity);

        return Ok(dto);
    }


    /// <summary>
    /// Update CategoryTranslation
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("Update")]
    public async Task<IActionResult> Update(CategoryTranslationUpdateRequest model)
    {
        await _categoryTranslationService.EditAsync(model);

        return Ok(null);
    }


    /// <summary>
    /// Get CategoryTranslation data by ID (This endpoint generally used for update CategoryTranslation)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetForUpdateById")]
    public IActionResult GetForUpdateById(string id)
    {
        var result = _categoryTranslationService.GetForUpdateById(Decrypt(id));

        return Ok(result);
    }


    /// <summary>
    /// Get CategoryTranslation data by ID (This endpoint generally used for view of CategoryTranslation data. It does not contains relations)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _categoryTranslationService.GetById(Decrypt(id));

        return Ok(result);
    }

    /// <summary>
    /// Delete CategoryTranslation
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("Delete")]
    public IActionResult Delete(string id)
    {
        _categoryTranslationService.DeleteById(Decrypt(id));

        return Ok();
    }



    /// <summary>
    ///  Get all CategoryTranslation data.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetTable")]
    public IActionResult GetTable()
    {
        var result = _categoryTranslationService.GetTable();

        return Ok(result);
    }




}
