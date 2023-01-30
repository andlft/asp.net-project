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
        public string Password { get; set; }
        [Required]
        public string CountyName { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public string StreetName { get; set; }
        [Required]
        public int StreetNo { get; set; }
        [Required]
        public string ZipCode { get; set; }
        public string BuildingName { get; set; }
        public string Floor { get; set; }
        public string FlatNo { get; set; }
      

    }
}
