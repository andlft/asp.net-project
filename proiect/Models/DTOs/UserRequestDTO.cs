using System.ComponentModel.DataAnnotations;

namespace proiect.Models.DTOs
{
    public class UserRequestDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public Adress Adress { get; set; }
    }
}
