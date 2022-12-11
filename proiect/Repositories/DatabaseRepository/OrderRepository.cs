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

        public List<Order> GetAllInTimeIntervalWithInclude(DateTime Begin, DateTime End)
        {
            return _table.Include(x => x.Items).Where(x => x.DateCreated > Begin && x.DateCreated < End).ToList();
        }

        public List<Order> GetAllWithInclude()
        {
            return _table.Include(x => x.Items).ToList();
        }
    }
}
