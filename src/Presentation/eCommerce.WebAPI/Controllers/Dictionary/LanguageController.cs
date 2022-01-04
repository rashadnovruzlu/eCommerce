using eCommerce.Application.DTOs;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;
using eCommerce.Application;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace eCommerce.Web.Controllers;

public class LanguageController : BaseController
{
    private readonly ILanguageService _languageService;
    private readonly IMapper _mapper;

    public LanguageController(ILanguageService languageService, IMapper mapper)
    {
        _languageService = languageService;
        _mapper = mapper;
    }

    /// <summary>
    /// Add new Language
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("Add")]
    public async Task<IActionResult> Add(LanguageAddRequest model)
    {
        var entity = _mapper.Map<Language>(model);

        await _languageService.AddAsync(entity);

        var dto = _mapper.Map<LanguageDTO>(entity);

        return Ok(dto);
    }


    /// <summary>
    /// Update Language
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("Update")]
    public async Task<IActionResult> Update(LanguageUpdateRequest model)
    {
        await _languageService.EditAsync(model);

        return Ok(null);
    }


    /// <summary>
    /// Get Language data by ID (This endpoint generally used for update Language)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetForUpdateById")]
    public IActionResult GetForUpdateById(string id)
    {
        var result = _languageService.GetForUpdateById(Decrypt(id));

        return Ok(result);
    }


    /// <summary>
    /// Get Language data by ID (This endpoint generally used for view of Language data. It does not contains relations)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _languageService.GetById(Decrypt(id));

        return Ok(result);
    }

    /// <summary>
    /// Delete Language
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("Delete")]
    public IActionResult Delete(string id)
    {
        _languageService.DeleteById(Decrypt(id));

        return Ok();
    }



    /// <summary>
    ///  Get all Language data.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetTable")]
    public IActionResult GetTable()
    {
        var result = _languageService.GetTable();

        return Ok(result);
    }




}
