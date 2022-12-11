using proiect.Data;
using proiect.Models;
using proiect.Repositories.GenericRepository;

namespace proiect.Repositories.DatabaseRepository
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(ProjectContext context) : base(context)
        {
        }

    }
}
