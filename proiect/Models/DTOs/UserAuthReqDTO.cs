    using System.ComponentModel.DataAnnotations;

namespace proiect.Models.DTOs
{
    public class UserAuthReqDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
