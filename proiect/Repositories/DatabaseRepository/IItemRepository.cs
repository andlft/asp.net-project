using proiect.Models;
using proiect.Repositories.GenericRepository;

namespace proiect.Repositories.DatabaseRepository
{
    public interface IItemRepository : IGenericRepository<Item>
    {
    }
}
