using eCommerce.Application.DTOs;
using eCommerce.Application.Interfaces;
using eCommerce.Domain.Entities;
using eCommerce.Application;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
namespace eCommerce.Web.Controllers;

public class OrderDetailController : BaseController
{
    private readonly IOrderDetailService _orderDetailService;
    private readonly IMapper _mapper;

    public OrderDetailController(IOrderDetailService orderDetailService, IMapper mapper)
    {
        _orderDetailService = orderDetailService;
        _mapper = mapper;
    }

    /// <summary>
    /// Add new OrderDetail
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("Add")]
    public async Task<IActionResult> Add(OrderDetailAddRequest model)
    {
        var entity = _mapper.Map<OrderDetail>(model);

        await _orderDetailService.AddAsync(entity);

        var dto = _mapper.Map<OrderDetailDTO>(entity);

        return Ok(dto);
    }


    /// <summary>
    /// Update OrderDetail
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPut("Update")]
    public async Task<IActionResult> Update(OrderDetailUpdateRequest model)
    {
        await _orderDetailService.EditAsync(model);

        return Ok(null);
    }


    /// <summary>
    /// Get OrderDetail data by ID (This endpoint generally used for update OrderDetail)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetForUpdateById")]
    public IActionResult GetForUpdateById(string id)
    {
        var result = _orderDetailService.GetForUpdateById(Decrypt(id));

        return Ok(result);
    }


    /// <summary>
    /// Get OrderDetail data by ID (This endpoint generally used for view of OrderDetail data. It does not contains relations)
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("GetById")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _orderDetailService.GetById(Decrypt(id));

        return Ok(result);
    }

    /// <summary>
    /// Delete OrderDetail
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("Delete")]
    public IActionResult Delete(string id)
    {
        _orderDetailService.DeleteById(Decrypt(id));

        return Ok();
    }



    /// <summary>
    ///  Get all OrderDetail data.
    /// </summary>
    /// <returns></returns>
    [HttpGet("GetTable")]
    public IActionResult GetTable()
    {
        var result = _orderDetailService.GetTable();

        return Ok(result);
    }




}
