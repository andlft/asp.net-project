using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proiect.Models;
using proiect.Models.DTOs;
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

        [HttpGet("get-item/{itemId}")]
        public async Task<ActionResult<Item>> GetItem(Guid itemId)
        {
            return Ok(await _itemService.GetItemById(itemId));
        }

        [HttpPut("update-item/{itemId}")]
        public async Task<ActionResult> UpdateItem (Guid itemId, [FromBody]ItemRequestDTO item)
        {
            var result = await _itemService.UpdateItem(itemId, item);
            if (result == false)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpDelete("delete-item/{itemId}")]
        public async Task<ActionResult> DeleteItem (Guid itemId)
        {
            await _itemService.DeleteItem(itemId);
            return Ok();
        }




    }



}
