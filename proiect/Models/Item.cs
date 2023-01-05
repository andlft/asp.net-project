namespace proiect.Models
{
    public class Item: BaseEntity.BaseEntity
    {
        public string ProductName { get; set; }   
        public string Description { get; set; }
        public int Price { get; set; }
        public string Manufacturer { get; set;}

        public List<OrderItem>? OrderItems { get; set; }

    }
}
