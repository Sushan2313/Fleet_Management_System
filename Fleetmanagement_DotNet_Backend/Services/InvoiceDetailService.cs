using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using FM.Repositories;
using FM.Modles;

namespace FM.Services
{
    public class InvoiceDetailService : IInvoiceDetailService
    {
        private readonly FMContext _context;

        public InvoiceDetailService(FMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InvoiceDetail>> GetInvoiceDetailsAsync()
        {
            return await _context.InvoiceDetails.ToListAsync();
        }

        public async Task<InvoiceDetail> GetInvoiceDetailByIdAsync(int id)
        {
            return await _context.InvoiceDetails.FindAsync(id);
        }

        public async Task<InvoiceDetail> CreateInvoiceDetailAsync(InvoiceDetail invoiceDetail)
        {
            _context.InvoiceDetails.Add(invoiceDetail);
            await _context.SaveChangesAsync();
            return invoiceDetail;
        }

        public async Task UpdateInvoiceDetailAsync(int id, InvoiceDetail invoiceDetail)
        {
            if (id != invoiceDetail.IdetailId)
            {
                throw new ArgumentException("ID mismatch");
            }

            _context.Entry(invoiceDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceDetailExists(id))
                {
                    throw new KeyNotFoundException("InvoiceDetail not found");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task DeleteInvoiceDetailAsync(int id)
        {
            var invoiceDetail = await _context.InvoiceDetails.FindAsync(id);
            if (invoiceDetail == null)
            {
                throw new KeyNotFoundException("InvoiceDetail not found");
            }

            _context.InvoiceDetails.Remove(invoiceDetail);
            await _context.SaveChangesAsync();
        }

        private bool InvoiceDetailExists(int id)
        {
            return _context.InvoiceDetails.Any(e => e.IdetailId == id);
        }
    }
}
