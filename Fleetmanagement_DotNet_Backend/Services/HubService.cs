using FM.Repositories;
using FM.Modles;
using Microsoft.EntityFrameworkCore;
namespace Fleetmanagement_new.Services
{
    public class HubService: IHubService
    {
        private readonly FMContext _context;

        public HubService(FMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hub>> GetAllHubsAsync()
        {
            return await _context.Hubs
                .Include(h => h.City)
                .Include(h => h.State)
                .ToListAsync();
        }

        public async Task<IEnumerable<Hub>> GetHubByCity(String city)
        {
            return await _context.Hubs
                .Where(hub => hub.City.CityName == city)
                .ToListAsync(); 
        }

        public async Task<Hub> PostHub(Hub hub)
        {
            var city = await _context.CityMasters.FindAsync(hub.CityId);
            var state = await _context.StateMasters.FindAsync(hub.StateId);

            if (city == null || state == null)
            {
                throw new Exception("Referenced city or state does not exist");
            }

            _context.Hubs.Add(hub);
            await _context.SaveChangesAsync();
            return hub;
        }

        public async Task<Hub> PutHub(long hubId, Hub hub)
        {
            var existingHub = await _context.Hubs.FindAsync(hubId);
            if (existingHub == null)
            {
                return null; // Or throw an exception if you prefer
            }

            // Update properties
            existingHub.HubName = hub.HubName;
            existingHub.HubAddressAndDetails = hub.HubAddressAndDetails;
            existingHub.ContactNumber = hub.ContactNumber;
            existingHub.CityId = hub.CityId;
            existingHub.StateId = hub.StateId;

            await _context.SaveChangesAsync();
            return existingHub;
        }

        public async Task<bool> DeleteHub(long hubId)
        {
            var hub = await _context.Hubs.FindAsync(hubId);
            if (hub == null)
            {
                return false;
            }

            _context.Hubs.Remove(hub);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
