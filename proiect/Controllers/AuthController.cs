using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using proiect.Models.DTOs;
using proiect.Models.Enums;
using proiect.Models;
using proiect.Services.UserService;
using BCryptNet = BCrypt.Net.BCrypt;

namespace proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("createCustomer")]
        public async Task<ActionResult<Guid>> CreateCustomer(UserRequestDTO Customer)
        {
            var userToCreate = new User
            {
                FirstName = Customer.FirstName,
                LastName = Customer.LastName,
                PhoneNumber = Customer.PhoneNumber,
                Email = Customer.Email,
                PasswordHash = BCryptNet.HashPassword(Customer.Password),
                RoleName = Roles.Customer,
                Address = new Address
                {
                    CountyName = Customer.Address.CountyName,
                    CityName = Customer.Address.CityName,
                    StreetName = Customer.Address.StreetName,
                    StreetNo = Customer.Address.StreetNo,
                    ZipCode = Customer.Address.ZipCode,
                    BuildingName = Customer.Address.BuildingName,
                    Floor = Customer.Address.Floor,
                    FlatNo = Customer.Address.FlatNo,
                    DateCreated = DateTime.Now
                },
                DateCreated = DateTime.Now
            };
            Guid userId = await _userService.CreateUser(userToCreate);
            return Ok(userId);
        }


        [HttpPost("login")]
        public IActionResult Login(UserAuthReqDTO user)
        {
            var response = _userService.Authentificate(user);
            if (response == null)
            {
                return BadRequest("Username or password is invalid!");
            }
            return Ok(response);
        }
    }
}
