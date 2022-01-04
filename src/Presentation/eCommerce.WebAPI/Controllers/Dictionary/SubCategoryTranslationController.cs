using eCommerce.Application.DTOs;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;
using eCommerce.Application;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace eCommerce.Web.Controllers;

public class SubCategoryTranslationController : BaseController
{
    private readonly ISubCategoryTranslationService _subCategoryTranslationService;
    private readonly IMapper _mapper;

    public SubCategoryTranslationController(ISubCategoryTranslationService subCategoryTranslationService, IMapper mapper)
    {
        _subCategoryTranslationService = subCategoryTranslationService;
        _mapper = mapper;
    }

    /// <summary>
    /// Add new SubCategoryTranslation
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("Add")]
    public async Task<IActionResult> Add(SubCategoryTranslationAddRequest model)
    {
        var entity = _mapper.Map<SubCategoryTranslation>(model);

        await _subCategoryTranslationService.AddAsync(entity);

        var dto = _mapper.Map<SubCategoryTranslationDTO>(entity);

        return Ok(dto);
    }


    /// <summary>
    /// Update SubCategoryTranslation
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("Update")]
    public async Task<IActionResult> Update(SubCategoryTranslationUpdateRequest model)
    {
        await _subCategoryTranslationService.EditAsync(model);

        return Ok(null);
    }


    /// <summary>
    /// Get SubCategoryTranslation data by ID (This endpoint generally used for update SubCategoryTranslation)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetForUpdateById")]
    public IActionResult GetForUpdateById(string id)
    {
        var result = _subCategoryTranslationService.GetForUpdateById(Decrypt(id));

        return Ok(result);
    }


    /// <summary>
    /// Get SubCategoryTranslation data by ID (This endpoint generally used for view of SubCategoryTranslation data. It does not contains relations)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _subCategoryTranslationService.GetById(Decrypt(id));

        return Ok(result);
    }

    /// <summary>
    /// Delete SubCategoryTranslation
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("Delete")]
    public IActionResult Delete(string id)
    {
        _subCategoryTranslationService.DeleteById(Decrypt(id));

        return Ok();
    }



    /// <summary>
    ///  Get all SubCategoryTranslation data.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetTable")]
    public IActionResult GetTable()
    {
        var result = _subCategoryTranslationService.GetTable();

        return Ok(result);
    }




}
