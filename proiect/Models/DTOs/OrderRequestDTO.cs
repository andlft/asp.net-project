using System.ComponentModel.DataAnnotations;

namespace proiect.Models.DTOs
{
    public class OrderRequestDTO
    {
        [Required]
        public int TotalPrice { get; set; }
        [Required]
        public DateTime dateTime { get; set; }
        [Required]
        public string status { get; set; }  
    }
}
