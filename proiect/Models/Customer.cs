namespace proiect.Models
{
    public class Customer: BaseEntity.BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Adress Adress{ get; set; }
        public ICollection<Order> Orders { get; set; }


    }
}
