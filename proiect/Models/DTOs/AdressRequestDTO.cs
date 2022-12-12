using System.ComponentModel.DataAnnotations;

namespace proiect.Models.DTOs
{
    public class AdressRequestDTO
    {
        [Required]
        public string CountyName { get; set; }
        [Required]
        public string CityName   { get; set; }
        [Required]
        public string StreetName { get; set; }
        [Required]
        public int StreetNo { get; set; }
        [Required]
        public string ZipCode { get; set; } 

        public string? BuildingName { get; set; }    
        public string? Floor { get; set; }
        public string? FlatNo    { get; set; }

    }
}
