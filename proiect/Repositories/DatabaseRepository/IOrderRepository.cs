using proiect.Models;
using proiect.Repositories.GenericRepository;

namespace proiect.Repositories.DatabaseRepository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        List<Order> GetAllWithInclude();
        List<Order> GetAllFromUser(Guid UserId);
    }
}
