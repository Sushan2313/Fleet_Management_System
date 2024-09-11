using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using FM.Repositories;
using FM.Modles;
using Microsoft.AspNetCore.Cors;

namespace Fleet_Sam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   

    public class InvoiceDetailsController : ControllerBase
    {
        private readonly FMContext _context;

        public InvoiceDetailsController(FMContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceDetail>>> GetInvoiceDetails()
        {
            return await _context.InvoiceDetails.ToListAsync();
        }

        // GET: api/InvoiceDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceDetail>> GetInvoiceDetail(int id)
        {
            var invoiceDetail = await _context.InvoiceDetails.FindAsync(id);

            if (invoiceDetail == null)
            {
                return NotFound();
            }

            return invoiceDetail;
        }

        // POST: api/InvoiceDetails
        [HttpPost]
        public async Task<ActionResult<InvoiceDetail>> PostInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            _context.InvoiceDetails.Add(invoiceDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInvoiceDetail), new { id = invoiceDetail.IdetailId }, invoiceDetail);
        }

        // PUT: api/InvoiceDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceDetail(int id, InvoiceDetail invoiceDetail)
        {
            if (id != invoiceDetail.IdetailId)
            {
                return BadRequest();
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
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/InvoiceDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceDetail(int id)
        {
            var invoiceDetail = await _context.InvoiceDetails.FindAsync(id);
            if (invoiceDetail == null)
            {
                return NotFound();
            }

            _context.InvoiceDetails.Remove(invoiceDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceDetailExists(int id)
        {
            return _context.InvoiceDetails.Any(e => e.IdetailId == id);
        }
    }
}
