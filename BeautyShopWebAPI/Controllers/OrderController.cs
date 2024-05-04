using BeautyShopApplication.Services.Interface;
using BeautyShopApplication.Utilities;
using BeautyShopDomain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeautyShopWebAPI.Controllers
{
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
            var userId = User.GetUserId();
            
            var result = await _orderService.AddItemToShopCard(addToShopCardDTO, userId, cancellation);

            if (!result) return BadRequest();
            return Ok("Item added successfully");
        }


        [HttpPost("RemoveItemFromShopCard/{orderItemId}")]
        public async Task<ActionResult> RemoveItemFromShopCard(int orderItemId,CancellationToken cancellation=default)
        {
            var userId = User.GetUserId();
            var result = await _orderService.RemoveItemFromShopCard(orderItemId, userId, cancellation);

            if (!result) return NotFound();
            return Ok("Item removed successfully");
        }


        [HttpGet("ShopCard")]
        public async Task<ActionResult> GetShopCard(CancellationToken cancellation=default)
        {
            var userId = User.GetUserId();
            var model = await _orderService.GetShopCard(userId, cancellation);
            if (model == null) return NotFound("There is no Open Order Yet");
            return Ok(model);
        }


        [HttpPost("RemoveShopCard")]
        public async Task<ActionResult> RemoveShopCard(CancellationToken cancellation=default)
        {
            var userId = User.GetUserId();
            var result = await _orderService.RemoveShopCard(userId, cancellation);
            if (!result) return NotFound();
            return Ok("ShopCard removed successfully");
        }
    }
}
