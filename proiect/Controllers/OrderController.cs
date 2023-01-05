using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proiect.Models;
using proiect.Models.DTOs;
using proiect.Services.OrderService;
using proiect.Services.UserService;

namespace proiect.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;
        private IUserService _userService;

        public OrderController (IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;

        }


        [HttpPost("create-order/{UserId}")]
        public async Task<ActionResult> CreateOrder(Guid UserId)
        {
            User customerToFind = await _userService.GetUserById(UserId);
            var ordertocreate = new Order
            {
                Customer = customerToFind,
                DateCreated = DateTime.Now
            };
            await _orderService.CreateOrder(ordertocreate);

            return Ok();
        }
        [HttpGet("get-orders/{UserId}")]
        public async Task<ActionResult<List<Order>>> GetUserOrders (Guid UserId)
        {
            return Ok(_orderService.GetAllFromUser(UserId));
        }
        [HttpGet("get-order/{OrderId}")]
        public async Task<ActionResult<Order>> GetOrderById (Guid OrderId)
        {
            Order order = await _orderService.GetOrderById(OrderId);
            return Ok(order);
        }
        [HttpPut("update-order/{OrderId}")]
        public async Task<ActionResult<Order>> UpdateOrder(Guid OrderId, OrderRequestDTO order)
        {
            Order newOrder = await _orderService.GetOrderById(OrderId);
            if (newOrder == null)
            {
                return BadRequest(null);
            }
            newOrder.TotalPrice = order.TotalPrice;
            newOrder.ExpectedDeliveryDate = order.dateTime;
            newOrder.Status = order.status;
            newOrder.DateModified = DateTime.Now;
            _orderService.UpdateOrder(newOrder);
            return Ok(newOrder);
        }
        [HttpDelete("delete-order/{OrderId}")]
        public async Task<ActionResult> DeleteOrder(Guid OrderId)
        {
            await _orderService.DeleteOrder(OrderId);
            return Ok();
        }
    }
    


}
