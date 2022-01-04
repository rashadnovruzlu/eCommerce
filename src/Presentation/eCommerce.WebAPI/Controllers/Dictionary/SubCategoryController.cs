using eCommerce.Application.DTOs;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;
using eCommerce.Application;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace eCommerce.Web.Controllers;

public class SubCategoryController : BaseController
{
    private readonly ISubCategoryService _subCategoryService;
    private readonly IMapper _mapper;

    public SubCategoryController(ISubCategoryService subCategoryService, IMapper mapper)
    {
        _subCategoryService = subCategoryService;
        _mapper = mapper;
    }

    /// <summary>
    /// Add new SubCategory
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("Add")]
    public async Task<IActionResult> Add(SubCategoryAddRequest model)
    {
        var entity = _mapper.Map<SubCategory>(model);

        await _subCategoryService.AddAsync(entity);

        var dto = _mapper.Map<SubCategoryDTO>(entity);

        return Ok(dto);
    }


    /// <summary>
    /// Update SubCategory
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("Update")]
    public async Task<IActionResult> Update(SubCategoryUpdateRequest model)
    {
        await _subCategoryService.EditAsync(model);

        return Ok(null);
    }


    /// <summary>
    /// Get SubCategory data by ID (This endpoint generally used for update SubCategory)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetForUpdateById")]
    public IActionResult GetForUpdateById(string id)
    {
        var result = _subCategoryService.GetForUpdateById(Decrypt(id));

        return Ok(result);
    }


    /// <summary>
    /// Get SubCategory data by ID (This endpoint generally used for view of SubCategory data. It does not contains relations)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _subCategoryService.GetById(Decrypt(id));

        return Ok(result);
    }

    /// <summary>
    /// Delete SubCategory
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("Delete")]
    public IActionResult Delete(string id)
    {
        _subCategoryService.DeleteById(Decrypt(id));

        return Ok();
    }



    /// <summary>
    /// Get DropDown friendly SubCategory data 
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetList")]
    public IActionResult GetList()
    {
        var result = _subCategoryService.GetList();

        return Ok(result);
    }



    /// <summary>
    /// Get DropDown friendly SubCategory data by categoryId
    /// </summary>
    /// <param name="categoryId "></param>           
    /// <returns></returns>
    [HttpGet("GetListByCategoryId")]
    public IActionResult GetListByCategoryId(string categoryId)
    {
        var result = _subCategoryService.GetListByCategoryId(Decrypt(categoryId));

        return Ok(result);
    }



    /// <summary>
    /// Get DropDown friendly SubCategory data. (This method use for server side pagination)
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("GetPageableList")]
    public IActionResult GetPageableList(DropdownRequest request)
    {
        var result = _subCategoryService.GetPageableList(request);

        return Ok(result);
    }



    /// <summary>
    /// Get DropDown friendly SubCategory data by request. (This method use for server side pagination)
    /// </summary>
    /// <param name="request"></param>
    [HttpGet("GetPageableListByCategoryId")]
    public IActionResult GetPageableListByCategoryId(DropdownRequest request)
    {
        var result = _subCategoryService.GetPageableListByCategoryId(request);

        return Ok(result);
    }



    /// <summary>
    ///  Get all SubCategory data.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetTable")]
    public IActionResult GetTable()
    {
        var result = _subCategoryService.GetTable();

        return Ok(result);
    }



    /// <summary>
    /// Get all SubCategory data by categoryId
    /// </summary>
    /// <param name="categoryId"></param>
    /// <returns></returns>
    [HttpGet("GetTableByCategoryId")]
    public IActionResult GetTableByCategoryId(string categoryId)
    {
        var result = _subCategoryService.GetTableByCategoryId(Decrypt(categoryId));

        return Ok(result);
    }




}
