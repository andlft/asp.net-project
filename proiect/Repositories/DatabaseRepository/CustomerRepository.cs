using Microsoft.EntityFrameworkCore;
using proiect.Data;
using proiect.Models;

namespace proiect.Repositories.DatabaseRepository
{
    public class CustomerRepository : GenericRepository.GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ProjectContext context) : base(context)
        {
            
        }

        public List<Customer> GetAllWithInclude()
        {
            return _table.Include(x => x.Adress).Include(x => x.Orders).ToList();
        }
    }
}
