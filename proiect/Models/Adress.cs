namespace proiect.Models
{
    public class Adress: BaseEntity.BaseEntity
    {
        public string CountyName { get; set; }
        public string CityName { get; set; }
        public string StreetName { get; set; }
        public int StreetNo { get; set; }
        public string ZipCode { get; set; }
        public string? BuildingName { get; set; }
        public string? Floor { get; set; }
        public string? FlatNo { get; set; }

        public Guid CustomerId { get; set; }    
        public Customer Customer { get; set; }

    }
}
