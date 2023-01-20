using backend.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using proiect.Data;
using proiect.Models;
using proiect.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace proiect.Repositories.DatabaseRepository
{
    public class UserRepository : GenericRepository.GenericRepository<User>, IUserRepository
    {
        public UserRepository(ProjectContext context) : base(context)
        {
            
        }

        public User FindByEmail(string email)
        {
            return _table.FirstOrDefault(x => x.Email == email);
        }

        public IEnumerable<User> GetAdmins()
        {
            return _table.Where(x => x.RoleName == Models.Enums.Roles.Admin).ToList();
        }

        public User GetUserWithInclude(Guid id)
        {
            return _table.Include(x => x.Address).FirstOrDefault(x => x.Id == id);
        }

        public List<User> GetAllWithInclude()
        {
            return _table.Include(x => x.Address).Include(x => x.Orders).ToList();
        }

        public IEnumerable<User> GetEmployees()
        {
            return _table.Where(x => x.RoleName == Models.Enums.Roles.Employee).ToList();
        }

        public List<RoleCounterPairDTO> GetUsersGroupByUserRole()
        {
            var result = from c in _table
                         group c by c.RoleName;
            var res = new List<RoleCounterPairDTO> { };
            foreach (var user in result)
            {
                var aux = new RoleCounterPairDTO
                {
                    role = user.Key,
                    counter = user.Count()
                };
                res.Add(aux);
            }

            return res;
        }
    }
}
