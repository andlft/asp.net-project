    using System.ComponentModel.DataAnnotations;

namespace proiect.Models.DTOs
{
    public class UserAuthResDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public UserAuthResDTO(User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName; 
            LastName = user.LastName;   
            PhoneNumber = user.PhoneNumber; 
            Email = user.Email; 
            Token = token;  
        }

    }
}
