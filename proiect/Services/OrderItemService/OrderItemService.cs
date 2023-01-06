using proiect.Models;
using proiect.Repositories.DatabaseRepository;

namespace proiect.Services.OrderItemService
{
    public class OrderItemService : IOrderItemService
    {
        public IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task AddItemToOrder(OrderItem orderItem)
        {
    
            await _orderItemRepository.CreateAsync(orderItem);
            await _orderItemRepository.SaveAsync();
        }

        public async Task DeleteItemFromOrder(Guid OrderItemId)
        {
            var orderToDelete = await _orderItemRepository.FindByIdAsync(OrderItemId);
            _orderItemRepository.Delete(orderToDelete);
            await _orderItemRepository.SaveAsync();
        }

        public async Task<List<Item>> GetOrderItems(Guid OrderId)
        {
            return _orderItemRepository.GetOrderItems(OrderId);
        }
    }
}
