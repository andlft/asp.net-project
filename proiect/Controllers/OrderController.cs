using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proiect.Helpers;
using proiect.Models;
using proiect.Models.DTOs;
using proiect.Models.Enums;
using proiect.Services.OrderItemService;
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
        private IOrderItemService _orderItemService;

        public OrderController(IOrderService orderService, IUserService userService, IOrderItemService orderItemService)
        {
            _orderService = orderService;
            _userService = userService;
            _orderItemService = orderItemService;

        }

        //[AuthorizationAttribute(Roles.Customer, Roles.Admin, Roles.Employee)]
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
        //[AuthorizationAttribute(Roles.Customer, Roles.Admin, Roles.Employee)]
        [HttpPost("add-item-order/{OrderId}/{ItemId}")]
        public async Task<ActionResult> AddItemToOrder(Guid OrderId, Guid ItemId)
        {
            var orderItemToCreate = new OrderItem
            {
                OrderId = OrderId,
                ItemId = ItemId,
                DateCreated = DateTime.Now
            };
            await _orderItemService.AddItemToOrder(orderItemToCreate);
            return Ok();
        }
        //[AuthorizationAttribute(Roles.Customer, Roles.Admin, Roles.Employee)]
        [HttpDelete("delete-item-order")]
        public async Task<ActionResult> DeleteItemFromOrder([FromBody] Guid OrderItemId)
        {
            await _orderItemService.DeleteItemFromOrder(OrderItemId);
            return Ok();
        }
        //[AuthorizationAttribute(Roles.Customer, Roles.Admin, Roles.Employee)]
        [HttpGet("get-order-items/{OrderId}")]
        public async Task<ActionResult<List<Tuple<Order, OrderItem, Item>>>> GetOrderItems (Guid OrderId)
        {
            return Ok(await _orderItemService.GetOrderItems(OrderId));
        }
        //[AuthorizationAttribute(Roles.Customer, Roles.Admin, Roles.Employee)]
        [HttpGet("get-orders/{UserId}")]
        public async Task<ActionResult<List<Order>>> GetUserOrders (Guid UserId)
        {
            return Ok(_orderService.GetAllFromUser(UserId));
        }
        //[AuthorizationAttribute(Roles.Customer, Roles.Admin, Roles.Employee)]
        [HttpGet("get-order/{OrderId}")]
        public async Task<ActionResult<Order>> GetOrderById (Guid OrderId)
        {
            Order order = await _orderService.GetOrderById(OrderId);
            return Ok(order);
        }

        //[AuthorizationAttribute(Roles.Customer, Roles.Admin, Roles.Employee)]
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

        //[AuthorizationAttribute(Roles.Customer, Roles.Admin, Roles.Employee)]
        [HttpDelete("delete-order/{OrderId}")]
        public async Task<ActionResult> DeleteOrder(Guid OrderId)
        {
            await _orderService.DeleteOrder(OrderId);
            return Ok();
        }
    }
    


}
