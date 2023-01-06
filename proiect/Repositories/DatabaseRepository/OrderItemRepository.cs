using Microsoft.Identity.Client;
using proiect.Data;
using proiect.Models;
using proiect.Repositories.GenericRepository;

namespace proiect.Repositories.DatabaseRepository
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(ProjectContext context) : base(context)
        {
            
        }

        public List<Item> GetOrderItems(Guid OrderId)
        {
            var query = _table.Where(orderitems => orderitems.OrderId == OrderId).Join(_context.Items, orderItems => orderItems.ItemId, items => items.Id, (orderItems, items) => new { orderItems, items }).Select(obj => obj.items);

            return query.ToList();
        }
    }
}
