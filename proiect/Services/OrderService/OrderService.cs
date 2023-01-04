using proiect.Models;
using proiect.Repositories.DatabaseRepository;

namespace proiect.Services.OrderService
{
    public class OrderService : IOrderService
    {
        public IOrderRepository _orderRepository;

        public OrderService (IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task CreateOrder(Order newOrder)
        {
            await _orderRepository.CreateAsync(newOrder);
            await _orderRepository.SaveAsync();
        }

        public async Task DeleteOrder(Guid OrderId)
        {
            var order = await _orderRepository.FindByIdAsync(OrderId);
            _orderRepository.Delete(order);
            await _orderRepository.SaveAsync();
        }

        public async Task<Order> GetOrderById(Guid OrderId)
        {
            return await _orderRepository.FindByIdAsync(OrderId);
        }
    }
}
