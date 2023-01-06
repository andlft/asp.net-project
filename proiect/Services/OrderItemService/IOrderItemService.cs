using proiect.Models;

namespace proiect.Services.OrderItemService
{
    public interface IOrderItemService
    {
        Task AddItemToOrder(OrderItem orderItem);
        Task DeleteItemFromOrder(Guid OrderItemId);
        Task <List<Item>> GetOrderItems(Guid OrderId);

    }
}
