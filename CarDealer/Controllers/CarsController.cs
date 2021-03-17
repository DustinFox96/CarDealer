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
    public class CarsController : ControllerBase
    {
        private readonly CarDealerDBContext _context;

        public CarsController(CarDealerDBContext context)
        {
            _context = context;
        }

        //PUT: api/Cars/Sold/5
        [HttpPut("Sold/{id}")]
        public async Task<IActionResult> SetStatusToSold(int id, Car car)
        {
            if (car == null){
                return NotFound();
            }
            car.Status = "SOLD";
            car.Profit = (car.SalePrice - car.Cost);
            return await PutCar(car.Id, car);
        }

        //PUT: api/Cars/ForSale/5
        [HttpPut("ForSale/{id}")]
        public async Task<IActionResult> SetStatusToForSale(int id, Car car)
        {
            if(car == null)
            {
                return BadRequest();
            }
            car.Status = "FORSALE";
            return await PutCar(car.Id, car);
        }

        //PUT: api/Cars/Received/5
        [HttpPut("Received/{id}")]
        public async Task<IActionResult> SetStatusToReceived(int id, Car car)
        {

            if (car == null)
            {
                return BadRequest();
            }
            car.Status = "RECEIVED";

            var dealer = await _context.Dealer.FindAsync(id);
            dealer.CarCount++;
            await _context.SaveChangesAsync();
            
            return await PutCar(car.Id, car);

        }
            




                
            


            
          



        // GET: api/Cars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCar()
        {
            return await _context.Car.ToListAsync();
        }

        // GET: api/Cars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _context.Car.FindAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/Cars/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            _context.Entry(car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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



        // POST: api/Cars
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(int id, Car car)
        {
            _context.Car.Add(car);
            car.Status = "RECEIVED";
            var dealer = await _context.Dealer.FindAsync(id);
            dealer.CarCount++;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCar", new { id = car.Id }, car);
        }

        // DELETE: api/Cars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Car>> DeleteCar(int id)
        {
            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Car.Remove(car);
            await _context.SaveChangesAsync();

            return car;
        }

        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.Id == id);
        }
    }
}
