using FM.Modles;

namespace Fleetmanagement_new.Services
{
    public interface ICarTypeService
    {
        Task<IEnumerable<CarType>> GetAllCarTypesAsync();
        Task<CarType> GetCarTypeByIdAsync(long carTypeId);
        Task<CarType> CreateCarTypeAsync(CarType carType);
        Task<CarType> UpdateCarTypeAsync(long carTypeId, CarType carType);
        Task<bool> DeleteCarTypeAsync(long carTypeId);
    }
}
