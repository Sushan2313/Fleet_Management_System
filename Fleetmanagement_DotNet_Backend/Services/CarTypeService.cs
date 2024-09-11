using FM.Modles;
using FM.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fleetmanagement_new.Services
{
    public class CarTypeService : ICarTypeService
    {
        private readonly FMContext _context;

        public CarTypeService(FMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CarType>> GetAllCarTypesAsync()
        {
            return await _context.CarTypes.ToListAsync();
        }

        public async Task<CarType> GetCarTypeByIdAsync(long carTypeId)
        {
            return await _context.CarTypes.FindAsync(carTypeId);
        }

        public async Task<CarType> CreateCarTypeAsync(CarType carType)
        {
            _context.CarTypes.Add(carType);
            await _context.SaveChangesAsync();
            return carType;
        }

        public async Task<CarType> UpdateCarTypeAsync(long carTypeId, CarType carType)
        {
            var existingCarType = await _context.CarTypes.FindAsync(carTypeId);
            if (existingCarType == null)
            {
                return null; // Or throw an exception if preferred
            }

            // Update properties
            existingCarType.CarTypeName = carType.CarTypeName;
            existingCarType.DailyRate = carType.DailyRate;
            existingCarType.WeeklyRate = carType.WeeklyRate;
            existingCarType.MonthlyRate = carType.MonthlyRate;
            existingCarType.ImagePath = carType.ImagePath;

            await _context.SaveChangesAsync();
            return existingCarType;
        }

        public async Task<bool> DeleteCarTypeAsync(long carTypeId)
        {
            var carType = await _context.CarTypes.FindAsync(carTypeId);
            if (carType == null)
            {
                return false;
            }

            _context.CarTypes.Remove(carType);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

