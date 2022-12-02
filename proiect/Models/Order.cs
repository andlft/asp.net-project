namespace proiect.Models
{
    public class Order: BaseEntity.BaseEntity
    {
        public int TotalPrice { get; set; }   
        public DateTime ExpectedDeliveryDate { get; set; }
        public Customer Customer { get; set; }  
        public ICollection<Item> Items { get; set; }

    }
}
