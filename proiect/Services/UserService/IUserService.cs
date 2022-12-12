using proiect.Models;
using proiect.Models.DTOs;

namespace proiect.Services.UserService
{
    public interface IUserService
    {
        Task CreateUser(User newUser);
        Task DeleteUser(Guid UserId);
        Task<bool> UpdateUser(Guid UserId, UserRequestDTO Request);
        Task<User> GetUserById(Guid UserId);

    }
}
