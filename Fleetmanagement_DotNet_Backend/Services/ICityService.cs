using FM.Modles;

namespace Fleetmanagement_new.Services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetAllCitiesAsync();
        Task<City> GetCityById(long cityId);
        Task<City> PostCity(City city);
        Task<City> PutCity(long cityId, City city);
        Task<bool> DeleteCity(long cityId);
    }
}
