using FM.Modles;

namespace Fleetmanagement_new.Services
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAllCarsAsync();
        Task<Car> GetCarByIdAsync(long carId);
        Task<Car> CreateCarAsync(Car car);
        Task<Car> UpdateCarAsync(long carId, Car car);
        Task<bool> DeleteCarAsync(long carId);
        Task<IEnumerable<Car>> GetCarsByTypeAndHubAsync(long carTypeId, long hubId);
    
    }
}
