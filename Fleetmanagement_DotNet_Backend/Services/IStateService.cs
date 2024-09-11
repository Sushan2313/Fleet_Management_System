using FM.Modles;
using Microsoft.AspNetCore.Mvc;
namespace Fleetmanagement_new.Services
{
    public interface IStateService
    {
        Task<IEnumerable<State>> GetAllStatesAsync();
        Task<State> GetStateById(long stateId);
        Task<State> PostState(State state);
        Task<State> PutState(long stateId, State state);
        Task<bool> DeleteState(long stateId);
    }
}
