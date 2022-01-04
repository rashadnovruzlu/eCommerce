using eCommerce.Application.DTOs;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;
using eCommerce.Application;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace eCommerce.Web.Controllers;

public class OrderStatusController : BaseController
{
    private readonly IOrderStatusService _orderStatusService;
    private readonly IMapper _mapper;

    public OrderStatusController(IOrderStatusService orderStatusService, IMapper mapper)
    {
        _orderStatusService = orderStatusService;
        _mapper = mapper;
    }

    /// <summary>
    /// Add new OrderStatus
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("Add")]
    public async Task<IActionResult> Add(OrderStatusAddRequest model)
    {
        var entity = _mapper.Map<OrderStatus>(model);

        await _orderStatusService.AddAsync(entity);

        var dto = _mapper.Map<OrderStatusDTO>(entity);

        return Ok(dto);
    }


    /// <summary>
    /// Update OrderStatus
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("Update")]
    public async Task<IActionResult> Update(OrderStatusUpdateRequest model)
    {
        await _orderStatusService.EditAsync(model);

        return Ok(null);
    }


    /// <summary>
    /// Get OrderStatus data by ID (This endpoint generally used for update OrderStatus)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetForUpdateById")]
    public IActionResult GetForUpdateById(string id)
    {
        var result = _orderStatusService.GetForUpdateById(Decrypt(id));

        return Ok(result);
    }


    /// <summary>
    /// Get OrderStatus data by ID (This endpoint generally used for view of OrderStatus data. It does not contains relations)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _orderStatusService.GetById(Decrypt(id));

        return Ok(result);
    }

    /// <summary>
    /// Delete OrderStatus
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("Delete")]
    public IActionResult Delete(string id)
    {
        _orderStatusService.DeleteById(Decrypt(id));

        return Ok();
    }



    /// <summary>
    ///  Get all OrderStatus data.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetTable")]
    public IActionResult GetTable()
    {
        var result = _orderStatusService.GetTable();

        return Ok(result);
    }




}
