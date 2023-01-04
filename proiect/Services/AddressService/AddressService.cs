using proiect.Models;
using proiect.Models.DTOs;
using proiect.Repositories.DatabaseRepository;

namespace proiect.Services.AddressService
{
    public class AddressService : IAddressService
    {
        public IAddressRepository _addressRepository;

        public AddressService (IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Guid> CreateAddress(Address newAddress)
        {
            Guid Id = await _addressRepository.CreateAsync(newAddress);
            await _addressRepository.SaveAsync();
            return Id;
        }

        public async Task DeleteAddress(Guid AddressId)
        {
            var address = await _addressRepository.FindByIdAsync(AddressId);
            _addressRepository.Delete(address);
            await _addressRepository.SaveAsync();
        }

        public async Task<Address> GetAddressById(Guid AddressId)
        {
            return await _addressRepository.FindByIdAsync(AddressId);   
        }

        public async Task<bool> UpdateAddress(Guid AddressId, AddressRequestDTO RequestDTO)
        {
            var address = await _addressRepository.FindByIdAsync(AddressId);
            if (address == null)
            {
                return false;
            }
            address.CountyName = RequestDTO.CountyName;
            address.CityName = RequestDTO.CityName;
            address.StreetName = RequestDTO.StreetName;
            address.StreetNo = RequestDTO.StreetNo;
            address.ZipCode = RequestDTO.ZipCode;
            address.BuildingName = RequestDTO.BuildingName;
            address.Floor = RequestDTO.Floor;
            address.FlatNo = RequestDTO.FlatNo;
            address.DateModified = DateTime.UtcNow;
            return true;
        }
    }
}
