using Microsoft.EntityFrameworkCore;
using proiect.Data;
using proiect.Models;
using proiect.Repositories.GenericRepository;

namespace proiect.Repositories.DatabaseRepository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ProjectContext context) : base(context)
        {
        }

        public List<Order> GetAllFromUser(Guid UserId)
        {
            return _table.Include(x => x.OrderItems).Where(x => x.Customer.Id == UserId).ToList();
        }

        public List<Order> GetAllWithInclude()
        {
            return _table.Include(x => x.OrderItems).ToList();
        }
    }
}
