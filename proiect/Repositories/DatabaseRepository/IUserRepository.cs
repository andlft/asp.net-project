using proiect.Models;
using proiect.Repositories.GenericRepository;

namespace proiect.Repositories.DatabaseRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        List<User> GetAllWithInclude();
        User GetUserWithInclude(Guid id);
        User FindByEmail(string email);
        IEnumerable<User> GetAdmins();
        IEnumerable<User> GetEmployees();
    }
}
