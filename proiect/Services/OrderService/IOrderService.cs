using proiect.Models;

namespace proiect.Services.OrderService
{
    public interface IOrderService
    {
        Task CreateOrder(Order newOrder);
        Task DeleteOrder(Guid OrderId);
        Task<Order> GetOrderById(Guid OrderId);
    }
}
