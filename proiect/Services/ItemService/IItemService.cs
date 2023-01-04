using Microsoft.AspNetCore.Components.Web.Virtualization;
using proiect.Models;
using proiect.Models.DTOs;

namespace proiect.Services.ItemService
{
    public interface IItemService
    {
        Task CreateItem(Item newItem);
        Task DeleteItem(Guid ItemId);
        Task<bool> UpdateItem(Guid ItemId, ItemRequestDTO Request);
        Task<Item> GetItemById(Guid ItemId);    
        
    }
}
