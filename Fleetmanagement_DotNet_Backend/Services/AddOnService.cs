using FM.Modles;
//using Fleetmanagement_new.Data; // Assuming you have a data context class (e.g., FMContext)
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using FM.Repositories;

namespace Fleetmanagement_new.Service
{
    public class AddOnService : IAddOnService
    {
        private readonly FMContext context;

        public AddOnService(FMContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<AddOn>> GetAllAddOnsAsync()
        {
            return await context.AddOns.ToListAsync();
        }

        public async Task<AddOn> GetAddOnByIdAsync(long id)
        {
            return await context.AddOns.FindAsync(id);
        }

        public async Task AddAddOnAsync(AddOn addOn)
        {
            await context.AddOns.AddAsync(addOn);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAddOnAsync(AddOn addOn)
        {
            context.AddOns.Update(addOn);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAddOnAsync(long id)
        {
            var addOn = await context.AddOns.FindAsync(id);
            if (addOn != null)
            {
                context.AddOns.Remove(addOn);
                await context.SaveChangesAsync();
            }
        }
    }
}
