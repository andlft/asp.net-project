using backend.Models.DTOs;
using proiect.Models;
using proiect.Models.Enums;
using proiect.Repositories.GenericRepository;

namespace proiect.Repositories.DatabaseRepository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        List<User> GetAllWithInclude();
        List<RoleCounterPairDTO> GetUsersGroupByUserRole();
        User GetUserWithInclude(Guid id);
        User FindByEmail(string email);
        IEnumerable<User> GetAdmins();
        IEnumerable<User> GetEmployees();
    }
}
