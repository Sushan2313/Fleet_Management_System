using System.Collections.Generic;
using System.Threading.Tasks;
using FM.Modles;
using FM.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fleetmanagement_new.Services
{
    public class CityService:ICityService
    {
        private readonly FMContext _context;
       
        public CityService(FMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetAllCitiesAsync()
        {
            return await _context.CityMasters.Include(c => c.State).ToListAsync();
        }

        public async Task<City> GetCityById(long cityId)
        {
            return await _context.CityMasters.Include(c => c.State).FirstOrDefaultAsync(c => c.CityId == cityId);
        }

        public async Task<City> PostCity(City city)
        {
            _context.CityMasters.Add(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task<City> PutCity(long cityId, City city)
        {
            var existingCity = await _context.CityMasters.FindAsync(cityId);
            if (existingCity == null)
            {
                return null; // Or throw an exception if you prefer
            }

            existingCity.CityName = city.CityName;
            existingCity.State_ID = city.State_ID;
            // Update other properties as necessary

            await _context.SaveChangesAsync();
            return existingCity;
        }

        public async Task<bool> DeleteCity(long cityId)
        {
            var city = await _context.CityMasters.FindAsync(cityId);
            if (city == null)
            {
                return false;
            }

            _context.CityMasters.Remove(city);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
