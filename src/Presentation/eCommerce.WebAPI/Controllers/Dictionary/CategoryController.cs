using eCommerce.Application.DTOs;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;
using eCommerce.Application;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace eCommerce.Web.Controllers;

public class CategoryController : BaseController
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    /// <summary>
    /// Add new Category
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("Add")]
    public async Task<IActionResult> Add(CategoryAddRequest model)
    {
        var entity = _mapper.Map<Category>(model);

        await _categoryService.AddAsync(entity);

        var dto = _mapper.Map<CategoryDTO>(entity);

        return Ok(dto);
    }


    /// <summary>
    /// Update Category
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("Update")]
    public async Task<IActionResult> Update(CategoryUpdateRequest model)
    {
        await _categoryService.EditAsync(model);

        return Ok(null);
    }


    /// <summary>
    /// Get Category data by ID (This endpoint generally used for update Category)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetForUpdateById")]
    public IActionResult GetForUpdateById(string id)
    {
        var result = _categoryService.GetForUpdateById(Decrypt(id));

        return Ok(result);
    }


    /// <summary>
    /// Get Category data by ID (This endpoint generally used for view of Category data. It does not contains relations)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _categoryService.GetById(Decrypt(id));

        return Ok(result);
    }

    /// <summary>
    /// Delete Category
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("Delete")]
    public IActionResult Delete(string id)
    {
        _categoryService.DeleteById(Decrypt(id));

        return Ok();
    }



    /// <summary>
    /// Get DropDown friendly Category data 
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetList")]
    public IActionResult GetList()
    {
        var result = _categoryService.GetList();

        return Ok(result);
    }



    /// <summary>
    /// Get DropDown friendly Category data. (This method use for server side pagination)
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("GetPageableList")]
    public IActionResult GetPageableList(DropdownRequest request)
    {
        var result = _categoryService.GetPageableList(request);

        return Ok(result);
    }



    /// <summary>
    ///  Get all Category data.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetTable")]
    public IActionResult GetTable()
    {
        var result = _categoryService.GetTable();

        return Ok(result);
    }




}
