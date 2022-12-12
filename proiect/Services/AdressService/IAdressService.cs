using proiect.Models;
using proiect.Models.DTOs;

namespace proiect.Services.AdressService
{
    public interface IAdressService
    {
        Task CreateAdress(Adress newAdress);
        Task DeleteAdress(Guid AdressId);
        Task<bool> UpdateAdress(Guid AdressId, AdressRequestDTO Request);
        Task<Adress> GetAdressById (Guid id);

    }
}
