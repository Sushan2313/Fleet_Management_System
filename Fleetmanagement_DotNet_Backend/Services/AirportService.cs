using FM.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Fleetmanagement_new.Services
{
    public class AirportService:IAirportService
    {
        private readonly FMContext _context;

        public AirportService(FMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Airport>> GetAllAirportsAsync()
        {
            return await _context.Airports
                .Include(a => a.City)
                .Include(a => a.State)
                .Include(a => a.Hub)
                .ToListAsync();
        }

        public async Task<Airport> GetAirportById(long airportId)
        {
            return await _context.Airports
                .Include(a => a.City)
                .Include(a => a.State)
                .Include(a => a.Hub)
                .FirstOrDefaultAsync(a => a.AirportId == airportId);
        }

        public async Task<Airport> PostAirport(Airport airport)
        {
            var city = await _context.CityMasters.FindAsync(airport.CityId);
            var state = await _context.StateMasters.FindAsync(airport.StateId);
            var hub = await _context.Hubs.FindAsync(airport.HubId);

            if (city == null || state == null || hub == null)
            {
                throw new Exception("Referenced city, state, or hub does not exist");
            }

            _context.Airports.Add(airport);
            await _context.SaveChangesAsync();
            return airport;
        }

        public async Task<Airport> PutAirport(long airportId, Airport airport)
        {
            var existingAirport = await _context.Airports.FindAsync(airportId);
            if (existingAirport == null)
            {
                return null; // Or throw an exception if you prefer
            }

            // Update properties
            existingAirport.AirportCode = airport.AirportCode;
            existingAirport.AirportName = airport.AirportName;
            existingAirport.CityId = airport.CityId;
            existingAirport.StateId = airport.StateId;
            existingAirport.HubId = airport.HubId;

            await _context.SaveChangesAsync();
            return existingAirport;
        }

        public async Task<bool> DeleteAirport(long airportId)
        {
            var airport = await _context.Airports.FindAsync(airportId);
            if (airport == null)
            {
                return false;
            }

            _context.Airports.Remove(airport);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
