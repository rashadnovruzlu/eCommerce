using eCommerce.Application.DTOs;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;
using eCommerce.Application;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace eCommerce.Web.Controllers;

public class BrandController : BaseController
{
    private readonly IBrandService _brandService;
    private readonly IMapper _mapper;

    public BrandController(IBrandService brandService, IMapper mapper)
    {
        _brandService = brandService;
        _mapper = mapper;
    }

    /// <summary>
    /// Add new Brand
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("Add")]
    public async Task<IActionResult> Add(BrandAddRequest model)
    {
        var entity = _mapper.Map<Brand>(model);

        await _brandService.AddAsync(entity);

        var dto = _mapper.Map<BrandDTO>(entity);

        return Ok(dto);
    }


    /// <summary>
    /// Update Brand
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("Update")]
    public async Task<IActionResult> Update(BrandUpdateRequest model)
    {
        await _brandService.EditAsync(model);

        return Ok(null);
    }


    /// <summary>
    /// Get Brand data by ID (This endpoint generally used for update Brand)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetForUpdateById")]
    public IActionResult GetForUpdateById(string id)
    {
        var result = _brandService.GetForUpdateById(Decrypt(id));

        return Ok(result);
    }


    /// <summary>
    /// Get Brand data by ID (This endpoint generally used for view of Brand data. It does not contains relations)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _brandService.GetById(Decrypt(id));

        return Ok(result);
    }

    /// <summary>
    /// Delete Brand
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("Delete")]
    public IActionResult Delete(string id)
    {
        _brandService.DeleteById(Decrypt(id));

        return Ok();
    }



    /// <summary>
    /// Get DropDown friendly Brand data 
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetList")]
    public IActionResult GetList()
    {
        var result = _brandService.GetList();

        return Ok(result);
    }




    [HttpGet("GetListCountryId")]
    public IActionResult GetListCountryId(string CountryId)
    {
        var result = _brandService.GetListCountryId(Decrypt(CountryId));

        return Ok(result);
    }



    /// <summary>
    /// Get DropDown friendly Brand data. (This method use for server side pagination)
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpGet("GetPageableList")]
    public IActionResult GetPageableList(DropdownRequest request)
    {
        var result = _brandService.GetPageableList(request);

        return Ok(result);
    }



    /// <summary>
    /// Get DropDown friendly Brand data by request. (This method use for server side pagination)
    /// </summary>
    /// <param name="request"></param>
    [HttpGet("GetPageableListByCountryId")]
    public IActionResult GetPageableListByCountryId(DropdownRequest request)
    {
        var result = _brandService.GetPageableListByCountryId(request);

        return Ok(result);
    }



    /// <summary>
    ///  Get all Brand data.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetTable")]
    public IActionResult GetTable()
    {
        var result = _brandService.GetTable();

        return Ok(result);
    }



    /// <summary>
    /// Get all Brand data by countryId
    /// </summary>
    /// <param name="countryId"></param>
    /// <returns></returns>
    [HttpGet("GetTableByCountryId")]
    public IActionResult GetTableByCountryId(string countryId)
    {
        var result = _brandService.GetTableByCountryId(Decrypt(countryId));

        return Ok(result);
    }




}
