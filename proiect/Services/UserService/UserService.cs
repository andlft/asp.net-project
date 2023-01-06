using proiect.Helpers.JwtUtils;
using proiect.Models;
using proiect.Models.DTOs;
using proiect.Repositories.DatabaseRepository;
using BCryptNet = BCrypt.Net.BCrypt;

namespace proiect.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepository _userRepository;
        public IJwtUtils _jwtUtils;

        public UserService (IUserRepository userRepository, IJwtUtils jwtUtils)
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
        }

        public UserAuthResDTO Authentificate(UserAuthReqDTO user)
        {
            var foundUser = _userRepository.FindByEmail(user.Email);
            if (foundUser == null || !BCryptNet.Verify(user.Password, foundUser.PasswordHash))
            {
                return null;
            }

            var jwtToken = _jwtUtils.GenerateJwtToken(foundUser);
            return new UserAuthResDTO(foundUser, jwtToken);
        }

        public async Task<Guid> CreateUser(User newUser)
        {
            Guid Id;
            Id = await _userRepository.CreateAsync(newUser);
            await _userRepository.SaveAsync();
            return Id;
         }

        public async Task<bool> DeleteUser(Guid UserId)
        {
            var user = await _userRepository.FindByIdAsync(UserId);
            if (user == null)
            {
                return false;
            }
            _userRepository.Delete(user);
            await _userRepository.SaveAsync();
            return true;
        }

        public IEnumerable<User> GetEmployees()
        {
            return _userRepository.GetEmployees();
        }

        public async Task<User> GetUserById(Guid UserId)
        {
            return _userRepository.GetUserWithInclude(UserId);
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
            user.PasswordHash = BCryptNet.HashPassword(Request.Password);
            await _userRepository.SaveAsync();
            return true;
        }
    }
}
