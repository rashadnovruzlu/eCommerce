using eCommerce.Application.DTOs;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;
using eCommerce.Application;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace eCommerce.Web.Controllers;

public class OrderController : BaseController
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public OrderController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }

    /// <summary>
    /// Add new Order
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("Add")]
    public async Task<IActionResult> Add(OrderAddRequest model)
    {
        var entity = _mapper.Map<Order>(model);

        await _orderService.AddAsync(entity);

        var dto = _mapper.Map<OrderDTO>(entity);

        return Ok(dto);
    }


    /// <summary>
    /// Update Order
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("Update")]
    public async Task<IActionResult> Update(OrderUpdateRequest model)
    {
        await _orderService.EditAsync(model);

        return Ok(null);
    }


    /// <summary>
    /// Get Order data by ID (This endpoint generally used for update Order)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetForUpdateById")]
    public IActionResult GetForUpdateById(string id)
    {
        var result = _orderService.GetForUpdateById(Decrypt(id));

        return Ok(result);
    }


    /// <summary>
    /// Get Order data by ID (This endpoint generally used for view of Order data. It does not contains relations)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _orderService.GetById(Decrypt(id));

        return Ok(result);
    }

    /// <summary>
    /// Delete Order
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("Delete")]
    public IActionResult Delete(string id)
    {
        _orderService.DeleteById(Decrypt(id));

        return Ok();
    }



    /// <summary>
    ///  Get  Order data. (This method use for server side pagination)
    /// </summary>
    /// <param name="pagingRequest"></param>
    /// <returns></returns>
    [HttpGet("GetTable")]
    public IActionResult GetTable(PagingRequest pagingRequest)
    {
        var result = _orderService.GetTable(pagingRequest);

        return Ok(result);
    }




}
