namespace proiect.Models
{
    public class OrderItem : BaseEntity.BaseEntity
    {
        public Guid OrderId { get; set; } 
        public Order order { get; set; }
        public Guid ItemId { get; set; }
        public Item item { get; set; }

    }
}
