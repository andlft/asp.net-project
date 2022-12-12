using proiect.Models;
using proiect.Models.DTOs;
using proiect.Repositories.DatabaseRepository;

namespace proiect.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;

        public UserService (IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task CreateUser(User newUser)
        {
            await _userRepository.CreateAsync(newUser);
            await _userRepository.SaveAsync();
        }

        public async Task DeleteUser(Guid UserId)
        {
            var user = await _userRepository.FindByIdAsync(UserId);
            _userRepository.Delete(user);
            await _userRepository.SaveAsync();
        }

        public async Task<User> GetUserById(Guid UserId)
        {
            return await _userRepository.FindByIdAsync(UserId);
        }

        public async Task<bool> UpdateUser(Guid UserId, UserRequestDTO Request)
        {
            var user = await _userRepository.FindByIdAsync(UserId);
            if(user == null)
            {
                return false;
            }
            user.FirstName = Request.FirstName;
            user.LastName = Request.LastName;
            user.PhoneNumber = Request.PhoneNumber;
            user.Email = Request.Email;
            user.PasswordHash = Request.PasswordHash;
            return true;
        }
    }
}
