using proiect.Models.Enums;

namespace proiect.Models
{
    public class User: BaseEntity.BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Roles RoleName   { get; set; }

        public Address? Address{ get; set; }
        public ICollection<Order>? Orders { get; set; }

    }
}
