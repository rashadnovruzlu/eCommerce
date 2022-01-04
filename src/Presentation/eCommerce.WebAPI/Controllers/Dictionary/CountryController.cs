using eCommerce.Application.DTOs;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;
using eCommerce.Application;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace eCommerce.Web.Controllers;

public class CountryController : BaseController
{
    private readonly ICountryService _countryService;
    private readonly IMapper _mapper;

    public CountryController(ICountryService countryService, IMapper mapper)
    {
        _countryService = countryService;
        _mapper = mapper;
    }

    /// <summary>
    /// Add new Country
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("Add")]
    public async Task<IActionResult> Add(CountryAddRequest model)
    {
        var entity = _mapper.Map<Country>(model);

        await _countryService.AddAsync(entity);

        var dto = _mapper.Map<CountryDTO>(entity);

        return Ok(dto);
    }


    /// <summary>
    /// Update Country
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("Update")]
    public async Task<IActionResult> Update(CountryUpdateRequest model)
    {
        await _countryService.EditAsync(model);

        return Ok(null);
    }


    /// <summary>
    /// Get Country data by ID (This endpoint generally used for update Country)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetForUpdateById")]
    public IActionResult GetForUpdateById(string id)
    {
        var result = _countryService.GetForUpdateById(Decrypt(id));

        return Ok(result);
    }


    /// <summary>
    /// Get Country data by ID (This endpoint generally used for view of Country data. It does not contains relations)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _countryService.GetById(Decrypt(id));

        return Ok(result);
    }

    /// <summary>
    /// Delete Country
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("Delete")]
    public IActionResult Delete(string id)
    {
        _countryService.DeleteById(Decrypt(id));

        return Ok();
    }



    /// <summary>
    ///  Get all Country data.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetTable")]
    public IActionResult GetTable()
    {
        var result = _countryService.GetTable();

        return Ok(result);
    }




}
