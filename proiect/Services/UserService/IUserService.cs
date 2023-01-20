using backend.Models.DTOs;
using proiect.Models;
using proiect.Models.DTOs;
using proiect.Models.Enums;

namespace proiect.Services.UserService
{
    public interface IUserService
    {
        Task<Guid> CreateUser(User newUser);
        Task<bool> DeleteUser(Guid UserId);
        Task<bool> UpdateUser(Guid UserId, UserRequestDTO Request);
        Task<User> GetUserById(Guid UserId);
        IEnumerable<User> GetEmployees();
        List<RoleCounterPairDTO> GetAllUsersGroupByRole();
        UserAuthResDTO Authentificate(UserAuthReqDTO user);

    }
}
