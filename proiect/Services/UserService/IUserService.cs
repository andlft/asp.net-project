using proiect.Models;
using proiect.Models.DTOs;

namespace proiect.Services.UserService
{
    public interface IUserService
    {
        Task<Guid> CreateUser(User newUser);
        Task<bool> DeleteUser(Guid UserId);
        Task<bool> UpdateUser(Guid UserId, UserRequestDTO Request);
        Task<User> GetUserById(Guid UserId);
        IEnumerable<User> GetEmployees();
        UserAuthResDTO Authentificate(UserAuthReqDTO user);

    }
}
