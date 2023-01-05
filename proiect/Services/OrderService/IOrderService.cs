using proiect.Models;

namespace proiect.Services.OrderService
{
    public interface IOrderService
    {
        Task CreateOrder(Order newOrder);
        Task DeleteOrder(Guid OrderId);
        Task UpdateOrder(Order newOrder);
        Task<Order> GetOrderById(Guid OrderId);
        List<Order> GetAllFromUser(Guid UserId);
    }
}
