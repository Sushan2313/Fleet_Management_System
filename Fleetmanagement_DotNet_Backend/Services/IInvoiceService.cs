using System.Collections.Generic;
using System.Threading.Tasks;

using FM.Modles;

namespace FM.Services
{
    public interface IInvoiceService
    {
        Task<IEnumerable<Invoice>> GetInvoicesAsync();
        Task<Invoice> GetInvoiceByIdAsync(int id);
        Task<Invoice> CreateInvoiceAsync(Invoice invoice);
        Task UpdateInvoiceAsync(int id, Invoice invoice);
        Task DeleteInvoiceAsync(int id);
    }
}
