using System.ComponentModel.DataAnnotations;

namespace proiect.Models.DTOs
{
    public class UserResponseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string CountyName    { get; set; }
        public string CityName      { get; set; }
        public string StreetName    { get; set; }
        public int StreetNo  { get; set; }
        public string ZipCode   { get; set; }
        public string BuildingName     { get; set; }
        public string Floor { get; set; }
        public string FlatNo { get; set; }
        
    }
}
