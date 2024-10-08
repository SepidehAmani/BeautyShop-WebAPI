﻿using BeautyShopApplication.Services.Interface;
using BeautyShopDomain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BeautyShopDomain.Utilities;

namespace BeautyShopWebAPI.Controllers;

[Route("api/Order")]
[ApiController]
[Authorize]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }



    [HttpPost("AddItemToShopCard")]
    public async Task<ActionResult> AddItemToShopCard(AddToShopCardDTO addToShopCardDTO,CancellationToken cancellation=default)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var userId = User.GetUserId();
        
        var result = await _orderService.AddItemToShopCard(addToShopCardDTO, userId, cancellation);

        if (!result) return BadRequest();
        return Ok("Item was added successfully");
    }


    [HttpDelete("RemoveItemFromShopCard/{orderItemId}")]
    public async Task<ActionResult> RemoveItemFromShopCard(int orderItemId,CancellationToken cancellation=default)
    {
        var userId = User.GetUserId();
        var result = await _orderService.RemoveItemFromShopCard(orderItemId, userId, cancellation);

        if (!result) return NotFound();
        return Ok("Item was removed successfully");
    }


    [HttpGet("CurrentShopCard")]
    public async Task<ActionResult> GetShopCard(CancellationToken cancellation=default)
    {
        var userId = User.GetUserId();
        var model = await _orderService.GetShopCard(userId, cancellation);
        if (model == null) return NotFound("There is no Open Order Yet");
        return Ok(model);
    }


    [HttpDelete("RemoveShopCard")]
    public async Task<ActionResult> RemoveShopCard(CancellationToken cancellation=default)
    {
        var userId = User.GetUserId();
        var result = await _orderService.RemoveShopCard(userId, cancellation);
        if (!result) return NotFound("There is no open Order");
        return Ok("ShopCard was removed successfully");
    }


    [HttpPost("PayCurrentShopCard")]
    public async Task<ActionResult> PayShopCard(AddressDTO addressDTO,CancellationToken cancellation=default)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var userId = User.GetUserId();
        var result = await _orderService.PayShopCard(userId,addressDTO, cancellation);
        if (!result) return BadRequest();
        return Ok("ShopCard was closed successfully");
    }


    [HttpGet("MakeOrderPayed/{orderId}")]
    public async Task<ActionResult> OrderPayed(int orderId,CancellationToken cancellation=default)
    {
        var userId = User.GetUserId();
        var result = await _orderService.OrderPayed(orderId, userId, cancellation);
        if (!result) return NotFound();
        return Ok("Order was payed successfully");
    }
}
