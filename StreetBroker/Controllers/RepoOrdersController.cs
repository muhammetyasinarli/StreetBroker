using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StreetBroker.Common;
using StreetBroker.Models;

namespace StreetBroker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepoOrdersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RepoOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/RepoOrders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepoOrder>>> GetRepoOrders()
        {
            return await _context.RepoOrders.ToListAsync();
        }

        // GET: api/RepoOrders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RepoOrder>> GetRepoOrder(long id)
        {
            var repoOrder = await _context.RepoOrders.FindAsync(id);

            if (repoOrder == null)
            {
                return NotFound();
            }

            return repoOrder;
        }

        // PUT: api/RepoOrders/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRepoOrder(long id, RepoOrder repoOrder)
        {
            if (id != repoOrder.Id)
            {
                return BadRequest();
            }

            _context.Entry(repoOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RepoOrderExists(id))
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

        // POST: api/RepoOrders
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<RepoOrder>> PostRepoOrder(RepoOrder repoOrder)
        {
            _context.RepoOrders.Add(repoOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRepoOrder", new { id = repoOrder.Id }, repoOrder);
        }

        // POST: api/RepoOrders/post
        [HttpPost("fast")]
        public async Task<ActionResult<RepoOrder>> PostRepoOrder(decimal amount, 
                                                            DateTime maturity, 
                                                            decimal interestRate,
                                                            long customerId, 
                                                            long dealerId)
        {
            RepoCalculator repoCalculator = new RepoCalculator(amount, maturity, interestRate);
            RepoOrder repoOrder = new RepoOrder()
            {
                Amount = repoCalculator.GetAmount(),
                CustomerId = customerId,
                DealerId = dealerId,
                GrossInterestAmount = repoCalculator.GetGrossInterestAmount(),
                InterestRate = repoCalculator.GetInterestRate(),
                GrossInterestRate = repoCalculator.GetGrossInterestRate(),
                Maturity = repoCalculator.GetMaturityDate(),
                NetInterestAmount = repoCalculator.GetNetInterestAmount(),
                OrderStatus = OrderStatus.Waiting,
                ReturnGrossInterestAmount = repoCalculator.GetReturnGrossAmount(),
                ReturnNetInterestAmount = repoCalculator.GetReturnNetAmount(),
                StartDate = DateTime.Now,
                TaxAmount = repoCalculator.GetTaxAmount()
            };

            _context.RepoOrders.Add(repoOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRepoOrder", new { id = repoOrder.Id }, repoOrder);
        }

        // DELETE: api/RepoOrders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RepoOrder>> DeleteRepoOrder(long id)
        {
            var repoOrder = await _context.RepoOrders.FindAsync(id);
            if (repoOrder == null)
            {
                return NotFound();
            }

            _context.RepoOrders.Remove(repoOrder);
            await _context.SaveChangesAsync();

            return repoOrder;
        }

        private bool RepoOrderExists(long id)
        {
            return _context.RepoOrders.Any(e => e.Id == id);
        }
    }
}
