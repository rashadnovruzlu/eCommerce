using eCommerce.Application.DTOs;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;
using eCommerce.Application;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace eCommerce.Web.Controllers;

public class OrderStatusTranslationController : BaseController
{
    private readonly IOrderStatusTranslationService _orderStatusTranslationService;
    private readonly IMapper _mapper;

    public OrderStatusTranslationController(IOrderStatusTranslationService orderStatusTranslationService, IMapper mapper)
    {
        _orderStatusTranslationService = orderStatusTranslationService;
        _mapper = mapper;
    }

    /// <summary>
    /// Add new OrderStatusTranslation
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("Add")]
    public async Task<IActionResult> Add(OrderStatusTranslationAddRequest model)
    {
        var entity = _mapper.Map<OrderStatusTranslation>(model);

        await _orderStatusTranslationService.AddAsync(entity);

        var dto = _mapper.Map<OrderStatusTranslationDTO>(entity);

        return Ok(dto);
    }


    /// <summary>
    /// Update OrderStatusTranslation
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("Update")]
    public async Task<IActionResult> Update(OrderStatusTranslationUpdateRequest model)
    {
        await _orderStatusTranslationService.EditAsync(model);

        return Ok(null);
    }


    /// <summary>
    /// Get OrderStatusTranslation data by ID (This endpoint generally used for update OrderStatusTranslation)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetForUpdateById")]
    public IActionResult GetForUpdateById(string id)
    {
        var result = _orderStatusTranslationService.GetForUpdateById(Decrypt(id));

        return Ok(result);
    }


    /// <summary>
    /// Get OrderStatusTranslation data by ID (This endpoint generally used for view of OrderStatusTranslation data. It does not contains relations)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _orderStatusTranslationService.GetById(Decrypt(id));

        return Ok(result);
    }

    /// <summary>
    /// Delete OrderStatusTranslation
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("Delete")]
    public IActionResult Delete(string id)
    {
        _orderStatusTranslationService.DeleteById(Decrypt(id));

        return Ok();
    }



    /// <summary>
    ///  Get all OrderStatusTranslation data.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetTable")]
    public IActionResult GetTable()
    {
        var result = _orderStatusTranslationService.GetTable();

        return Ok(result);
    }




}
