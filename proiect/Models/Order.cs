namespace proiect.Models
{
    public class Order: BaseEntity.BaseEntity
    {
        public int? TotalPrice { get; set; }   
        public DateTime? ExpectedDeliveryDate { get; set; }
        public string? Status { get; set; }
        public User? Customer { get; set; } 
        public List<OrderItem>? OrderItems { get; set; }

    }
}
