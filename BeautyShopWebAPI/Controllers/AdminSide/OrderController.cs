using BeautyShopApplication.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeautyShopWebAPI.Controllers.AdminSide
{
    [Route("api/Admin/Order")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }



        [HttpGet]
        public async Task<ActionResult> GetListOfPayedOrders(CancellationToken cancellation=default)
        {
            var model = await _orderService.GetListOfPayedOrders(cancellation);
            return Ok(model);
        }


        [HttpGet("{OrderId}")]
        public async Task<ActionResult> GetPayedOrderInDetail(int OrderId,CancellationToken cancellation)
        {
            var model = await _orderService.GetPayedOrderInDetail(OrderId, cancellation);
            if (model == null) return NotFound();
            return Ok(model);
        }


        [HttpPost("ShippOrder/{orderId}")]
        public async Task<ActionResult> ShippOrder(int orderId,CancellationToken cancellation=default)
        {
            var result = await _orderService.ShippOrder(orderId, cancellation);
            if (!result) return BadRequest();
            return Ok("OrderStatus changed to Shipped Successfully");
        }
    }
}
