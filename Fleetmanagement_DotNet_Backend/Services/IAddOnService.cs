using FM.Modles;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fleetmanagement_new.Service
{
    public interface IAddOnService
    {
        Task<IEnumerable<AddOn>> GetAllAddOnsAsync();
        Task<AddOn> GetAddOnByIdAsync(long id);
        Task AddAddOnAsync(AddOn addOn);
        Task UpdateAddOnAsync(AddOn addOn);
        Task DeleteAddOnAsync(long id);
    }
}
