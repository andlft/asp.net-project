using proiect.Models;
using proiect.Models.DTOs;
using proiect.Repositories.DatabaseRepository;

namespace proiect.Services.AdressService
{
    public class AdressService : IAdressService
    {
        public IAdressRepository _adressRepository;

        public AdressService (IAdressRepository adressRepository)
        {
            _adressRepository = adressRepository;
        }

        public async Task CreateAdress(Adress newAdress)
        {
            await _adressRepository.CreateAsync(newAdress);
            await _adressRepository.SaveAsync();   
        }

        public async Task DeleteAdress(Guid AdressId)
        {
            var adress = await _adressRepository.FindByIdAsync(AdressId);
            _adressRepository.Delete(adress);
            await _adressRepository.SaveAsync();
        }

        public async Task<Adress> GetAdressById(Guid AdressId)
        {
            return await _adressRepository.FindByIdAsync(AdressId);   
        }

        public async Task<bool> UpdateAdress(Guid AdressId, AdressRequestDTO RequestDTO)
        {
            var adress = await _adressRepository.FindByIdAsync(AdressId);
            if (adress == null)
            {
                return false;
            }
            adress.CountyName = RequestDTO.CountyName;
            adress.CityName = RequestDTO.CityName;
            adress.StreetName = RequestDTO.StreetName;
            adress.StreetNo = RequestDTO.StreetNo;
            adress.ZipCode = RequestDTO.ZipCode;
            adress.BuildingName = RequestDTO.BuildingName;
            adress.Floor = RequestDTO.Floor;
            adress.FlatNo = RequestDTO.FlatNo;
            adress.DateModified = DateTime.UtcNow;
            return true;
        }
    }
}
