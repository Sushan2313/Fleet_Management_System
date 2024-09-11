using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using FM.Repositories;
using FM.Modles;

namespace FM.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly FMContext _context;

        public InvoiceService(FMContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesAsync()
        {
            return await _context.Invoices.ToListAsync();
        }

        public async Task<Invoice> GetInvoiceByIdAsync(int id)
        {
            return await _context.Invoices.FindAsync(id);
        }

        public async Task<Invoice> CreateInvoiceAsync(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }

        public async Task UpdateInvoiceAsync(int id, Invoice invoice)
        {
            if (id != invoice.InvoiceId)
            {
                throw new ArgumentException("ID mismatch");
            }

            _context.Entry(invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(id))
                {
                    throw new KeyNotFoundException("Invoice not found");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task DeleteInvoiceAsync(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                throw new KeyNotFoundException("Invoice not found");
            }

            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.InvoiceId == id);
        }
    }
}
