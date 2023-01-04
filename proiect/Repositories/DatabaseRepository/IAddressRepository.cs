using proiect.Models;
using proiect.Repositories.GenericRepository;

namespace proiect.Repositories.DatabaseRepository
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Guid FindByCity(string CityName);
        Guid FindByZipcode (string Zipcode);
    }
}
