using FM.Modles;
using FM.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fleetmanagement_new.Services
{
    public class CarService:ICarService
    {
        private readonly FMContext _context;

        public CarService(FMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _context.Cars
                .Include(c => c.CarType)
                .Include(c => c.Hub)
                .ToListAsync();
        }

        public async Task<Car> GetCarByIdAsync(long carId)
        {
            return await _context.Cars
                .Include(c => c.CarType)
                .Include(c => c.Hub)
                .FirstOrDefaultAsync(c => c.CarId == carId);
        }
        public async Task<IEnumerable<Car>> GetCarsByTypeAndHubAsync(long carTypeId, long hubId)
        {
            return await _context.Cars
                .Where(c => c.CarTypeId == carTypeId && c.HubId == hubId)
                .ToListAsync();
        }
        public async Task<Car> CreateCarAsync(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> UpdateCarAsync(long carId, Car car)
        {
            var existingCar = await _context.Cars.FindAsync(carId);
            if (existingCar == null)
            {
                return null; // Or throw an exception if preferred
            }

            // Update properties
            existingCar.CarTypeId = car.CarTypeId;
            existingCar.CarName = car.CarName;
            existingCar.NumberPlate = car.NumberPlate;
            existingCar.Status = car.Status;
            existingCar.Capacity = car.Capacity;
            existingCar.Mileage = car.Mileage;
            existingCar.HubId = car.HubId;
            existingCar.IsAvailable = car.IsAvailable;
            existingCar.MaintenanceDueDate = car.MaintenanceDueDate;

            await _context.SaveChangesAsync();
            return existingCar;
        }

        public async Task<bool> DeleteCarAsync(long carId)
        {
            var car = await _context.Cars.FindAsync(carId);
            if (car == null)
            {
                return false;
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
