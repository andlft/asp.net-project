using System.ComponentModel.DataAnnotations;

namespace proiect.Models.DTOs
{
    public class ItemRequestDTO
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public string Manufacturer { get; set; }

    }
}
