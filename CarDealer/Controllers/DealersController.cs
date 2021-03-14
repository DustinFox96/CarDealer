using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarDealer.Data;
using CarDealer.Models;

namespace CarDealer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealersController : ControllerBase
    {
        private readonly CarDealerDBContext _context;

        public DealersController(CarDealerDBContext context)
        {
            _context = context;
        }

        // PUT: api/Dealers/Decrement/5
        [HttpPut("Decrement/{id}")]
        public async Task<IActionResult> DecrementCarCount(int id)
        {
            var dealer = await _context.Dealer.FindAsync(id);

                dealer.CarCount--;

            return await PutDealer(dealer.Id, dealer);
        }

        // PUT: api/Dealers/Increment/5
        [HttpPut("Increment/{id}")]
        public async Task<IActionResult> IncrementCarCount(int id)
        {
            var dealer = await _context.Dealer.FindAsync(id);

            dealer.CarCount++;

               return await PutDealer(dealer.Id, dealer);
            

        }

        // GET: api/Dealers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dealer>>> GetDealer()
        {
            return await _context.Dealer.ToListAsync();
        }

        // GET: api/Dealers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dealer>> GetDealer(int id)
        {
            var dealer = await _context.Dealer.FindAsync(id);

            if (dealer == null)
            {
                return NotFound();
            }

            return dealer;
        }

        // PUT: api/Dealers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDealer(int id, Dealer dealer)
        {
            if (id != dealer.Id)
            {
                return BadRequest();
            }

            _context.Entry(dealer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DealerExists(id))
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

        // POST: api/Dealers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Dealer>> PostDealer(Dealer dealer)
        {
            _context.Dealer.Add(dealer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDealer", new { id = dealer.Id }, dealer);
        }

        // DELETE: api/Dealers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dealer>> DeleteDealer(int id)
        {
            var dealer = await _context.Dealer.FindAsync(id);
            if (dealer == null)
            {
                return NotFound();
            }

            _context.Dealer.Remove(dealer);
            await _context.SaveChangesAsync();

            return dealer;
        }

        private bool DealerExists(int id)
        {
            return _context.Dealer.Any(e => e.Id == id);
        }
    }
}
