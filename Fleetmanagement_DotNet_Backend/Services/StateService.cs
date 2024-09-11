using FM.Modles;
using Microsoft.AspNetCore.Mvc;
using FM.Repositories;
using Microsoft.EntityFrameworkCore;
namespace Fleetmanagement_new.Services
{
    public class StateService : IStateService
    {
        private readonly FMContext _context;

        public StateService(FMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<State>> GetAllStatesAsync()
        {
            return await _context.StateMasters.ToListAsync();
        }

        public async Task<State> GetStateById(long stateId)
        {
            return await _context.StateMasters.FindAsync(stateId);
        }

        public async Task<State> PostState(State state)
        {
            _context.StateMasters.Add(state);
            await _context.SaveChangesAsync();
            return state;
        }

        public async Task<State> PutState(long stateId, State state)
        {
            var existingState = await _context.StateMasters.FindAsync(stateId);
            if (existingState == null)
            {
                return null; // Or throw an exception if you prefer
            }

            // Update properties
            existingState.StateName = state.StateName;
            // Update other properties as necessary

            await _context.SaveChangesAsync();
            return existingState;
        }

        public async Task<bool> DeleteState(long stateId)
        {
            var state = await _context.StateMasters.FindAsync(stateId);
            if (state == null)
            {
                return false;
            }

            _context.StateMasters.Remove(state);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
