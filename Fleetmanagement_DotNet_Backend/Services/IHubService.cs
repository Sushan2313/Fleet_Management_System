using FM.Repositories;
using FM.Modles;
using Microsoft.EntityFrameworkCore;

namespace Fleetmanagement_new.Services
{
    public interface IHubService
    {
        Task<IEnumerable<Hub>> GetAllHubsAsync();
        Task<IEnumerable<Hub>> GetHubByCity(String city);
        Task<Hub> PostHub(Hub hub);
        Task<Hub> PutHub(long hubId, Hub hub);
        Task<bool> DeleteHub(long hubId);
    }
}
