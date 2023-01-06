using proiect.Models;
using proiect.Repositories.GenericRepository;

namespace proiect.Repositories.DatabaseRepository
{
    public interface IOrderItemRepository : IGenericRepository<OrderItem>
    {

        public List<Item> GetOrderItems(Guid OrderId);
        
    }
}
