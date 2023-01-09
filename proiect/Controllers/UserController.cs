using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using proiect.Helpers;
using proiect.Models;
using proiect.Models.DTOs;
using proiect.Models.Enums;
using proiect.Services.AddressService;
using proiect.Services.UserService;
using BCryptNet = BCrypt.Net.BCrypt;

namespace proiect.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IAddressService _addressService;

        public UserController(IUserService userService, IAddressService addressService)
        {
            _userService = userService;
            _addressService = addressService;
        }


            [AuthorizationAttribute(Roles.Admin)]
        [HttpPost("createEmployee")]
        public async Task<ActionResult<Guid>> CreateEmployee(UserRequestDTO Employee)
        {
            var userToCreate = new User
            {
                FirstName = Employee.FirstName,
                LastName = Employee.LastName,
                PhoneNumber = Employee.PhoneNumber,
                Email = Employee.Email,
                PasswordHash = BCryptNet.HashPassword(Employee.Password),
                RoleName = Roles.Employee,
                Address = new Address
                {
                    CountyName = Employee.Address.CountyName,
                    CityName = Employee.Address.CityName,
                    StreetName = Employee.Address.StreetName,
                    StreetNo = Employee.Address.StreetNo,
                    ZipCode = Employee.Address.ZipCode,
                    BuildingName = Employee.Address.BuildingName,
                    Floor = Employee.Address.Floor,
                    FlatNo = Employee.Address.FlatNo,
                    DateCreated = DateTime.Now
                },
                DateCreated = DateTime.Now
            };
            Guid userId = await _userService.CreateUser(userToCreate);
            return Ok(userId);
        }
        [AuthorizationAttribute(Roles.Admin)]
        [HttpPost("CreateAdmin")]
        public async Task<ActionResult<Guid>> CreateAdmin(UserRequestDTO Admin)
        {
            var userToCreate = new User
            {
                FirstName = Admin.FirstName,
                LastName = Admin.LastName,
                PhoneNumber = Admin.PhoneNumber,
                Email = Admin.Email,
                PasswordHash = BCryptNet.HashPassword(Admin.Password),
                RoleName = Roles.Admin,
                Address = new Address
                {
                    CountyName = Admin.Address.CountyName,
                    CityName = Admin.Address.CityName,
                    StreetName = Admin.Address.StreetName,
                    StreetNo = Admin.Address.StreetNo,
                    ZipCode = Admin.Address.ZipCode,
                    BuildingName = Admin.Address.BuildingName,
                    Floor = Admin.Address.Floor,
                    FlatNo = Admin.Address.FlatNo,
                    DateCreated = DateTime.Now
                },
                DateCreated = DateTime.Now
            };
            Guid userId = await _userService.CreateUser(userToCreate);
            return Ok(userId);
        }
        [AuthorizationAttribute(Roles.Employee, Roles.Admin)]
        [HttpGet("GetUserInfo/{id}")]
        public ActionResult<UserResponseDTO> GetUserInfo(Guid id)
        {
            var user = _userService.GetUserById(id);
            var response = new UserResponseDTO
            {
                FirstName = user.Result.FirstName,
                LastName = user.Result.LastName,
                PhoneNumber = user.Result.PhoneNumber,
                Email = user.Result.Email,
                CountyName = user.Result.Address.CountyName,
                CityName = user.Result.Address.CityName,
                StreetName = user.Result.Address.StreetName,
                StreetNo = user.Result.Address.StreetNo,
                ZipCode = user.Result.Address.ZipCode,
                BuildingName = user.Result.Address.BuildingName,
                Floor = user.Result.Address.Floor,
                FlatNo = user.Result.Address.FlatNo
            };
            return Ok(response);
        }
        [AuthorizationAttribute(Roles.Admin)]
        [HttpGet("GetEmployees")]
        public ActionResult<IEnumerable<User>> GetEmployees()
        {
            return Ok(_userService.GetEmployees());
        }
        [Authorization(Roles.Employee, Roles.Admin)]
        [HttpPut("updateUserInfo/{id}")]
        public async Task<ActionResult> UpdateUser(Guid id, [FromBody]UserRequestDTO user)
        {
            var res = await _userService.UpdateUser(id, user);
            if (res)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [AuthorizationAttribute(Roles.Admin)]
        [HttpDelete("deleteUser/{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            var res = await _userService.DeleteUser(id);
            if (res)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }



    }
}
