using System.Collections.Generic;
using System.Threading.Tasks;

using FM.Modles;

namespace FM.Services
{
    public interface IInvoiceDetailService
    {
        Task<IEnumerable<InvoiceDetail>> GetInvoiceDetailsAsync();
        Task<InvoiceDetail> GetInvoiceDetailByIdAsync(int id);
        Task<InvoiceDetail> CreateInvoiceDetailAsync(InvoiceDetail invoiceDetail);
        Task UpdateInvoiceDetailAsync(int id, InvoiceDetail invoiceDetail);
        Task DeleteInvoiceDetailAsync(int id);
    }
}
