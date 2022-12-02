using proiect.Models;
using proiect.Repositories.GenericRepository;

namespace proiect.Repositories.DatabaseRepository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        List<Customer> GetAllWithInclude();
    }
}
