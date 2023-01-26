using proiect.Models;
using proiect.Models.DTOs;
using proiect.Repositories.DatabaseRepository;

namespace proiect.Services.ItemService
{
    public class ItemService : IItemService
    {
        public IItemRepository _itemRepository;

        public ItemService (IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task CreateItem(Item newItem)
        {
            await _itemRepository.CreateAsync(newItem);
            await _itemRepository.SaveAsync();
        }

        public async Task DeleteItem(Guid ItemId)
        {
            var item = await _itemRepository.FindByIdAsync(ItemId);
            _itemRepository.Delete(item);
            await _itemRepository.SaveAsync();
        }

        public async Task<IEnumerable<Item>> GetAllItems()
        {
            return await _itemRepository.GetAll();
        }

        public async Task<Item> GetItemById(Guid ItemId)
        {
            return await _itemRepository.FindByIdAsync(ItemId);
        }

        public async Task<bool> UpdateItem(Guid ItemId, ItemRequestDTO Request)
        {
            var item = await _itemRepository.FindByIdAsync(ItemId);
            if (item == null)
            {
                return false;
            }
            item.ProductName = Request.ProductName;
            item.Description = Request.Description;
            item.Price = Request.Price;
            item.Manufacturer = Request.Manufacturer;
            item.DateModified = DateTime.UtcNow;
            _itemRepository.Update(item);
            await _itemRepository.SaveAsync();
            return true;
        }
    }
}
