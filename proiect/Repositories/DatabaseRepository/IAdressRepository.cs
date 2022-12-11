using proiect.Models;
using proiect.Repositories.GenericRepository;

namespace proiect.Repositories.DatabaseRepository
{
    public interface IAdressRepository : IGenericRepository<Adress>
    {
        Guid FindByCity(string CityName);
        Guid FindByZipcode (string Zipcode);
    }
}
