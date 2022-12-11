using proiect.Data;
using proiect.Models;
using proiect.Repositories.GenericRepository;

namespace proiect.Repositories.DatabaseRepository
{
    public class AdressRepository : GenericRepository<Adress>, IAdressRepository
    {
        public AdressRepository(ProjectContext context) : base(context)
        {
        }

        public Guid FindByCity(string CityName)
        {
            return _table.FirstOrDefault(x => x.CityName == CityName).Id;
        }

        public Guid FindByZipcode(string Zipcode)
        {
            return _table.FirstOrDefault(x => x.ZipCode == Zipcode).Id;
        }
    }
}
