using proiect.Models;
using proiect.Models.DTOs;

namespace proiect.Services.AddressService
{
    public interface IAddressService
    {
        Task<Guid> CreateAddress(Address newAddress);
        Task DeleteAddress(Guid AddressId);
        Task<bool> UpdateAddress(Guid AddressId, AddressRequestDTO Request);
        Task<Address> GetAddressById (Guid id);

    }
}
