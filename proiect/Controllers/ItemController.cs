using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proiect.Helpers;
using proiect.Models;
using proiect.Models.DTOs;
using proiect.Models.Enums;
using proiect.Services.ItemService;

namespace proiect.Controllers
{
    [Route("api/item")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [AuthorizationAttribute(Roles.Admin, Roles.Employee)]
        [HttpPost("create-item")]
        public async Task<ActionResult<Item>> CreateItem(ItemRequestDTO item)
        {
            var itemToCreate = new Item
            {
                ProductName = item.ProductName,
                Description = item.Description,
                Price = item.Price,
                Manufacturer = item.Manufacturer,
                DateCreated = DateTime.Now
            };
            _itemService.CreateItem(itemToCreate);
            return Ok(itemToCreate);
        }

        [AuthorizationAttribute(Roles.Customer, Roles.Admin, Roles.Employee)]
        [HttpGet("get-item/{itemId}")]
        public async Task<ActionResult<Item>> GetItem(Guid itemId)
        {
            return Ok(await _itemService.GetItemById(itemId));
        }
        [AuthorizationAttribute(Roles.Customer, Roles.Admin, Roles.Employee)]
        [HttpGet("getallitems")]
        public async Task<ActionResult<Item>> GetAllItems()
        {
            return Ok(await _itemService.GetAllItems());
        }

        [AuthorizationAttribute(Roles.Admin, Roles.Employee)]
        [HttpPut("update-item/{itemId}")]
        public async Task<ActionResult> UpdateItem(Guid itemId, [FromBody] ItemRequestDTO item)
        {
            var result = await _itemService.UpdateItem(itemId, item);
            if (result == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [AuthorizationAttribute(Roles.Admin, Roles.Employee)]
        [HttpDelete("delete-item/{itemId}")]
        public async Task<ActionResult> DeleteItem (Guid itemId)
        {
            await _itemService.DeleteItem(itemId);
            return Ok();
        }




    }



}
