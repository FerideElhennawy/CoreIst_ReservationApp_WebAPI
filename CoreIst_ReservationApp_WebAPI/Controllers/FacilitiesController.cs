using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreIst_ReservationApp_WebAPI.Data;
using CoreIst_ReservationApp_WebAPI.Models;

namespace CoreIst_ReservationApp_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitiesController : ControllerBase
    {
        private readonly CoreIst_ReservationApp_WebAPIContext _context;

        public FacilitiesController(CoreIst_ReservationApp_WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/Facilities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facility>>> GetRoom()
        {
          if (_context.Facility == null)
          {
              return NotFound();
          }
            return await _context.Facility.Include(s => s.Instruments).ToListAsync();
        }

        // GET: api/Facilities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Facility>> GetFacility(int id)
        {
          if (_context.Facility == null)
          {
              return NotFound();
          }
            var facility = await _context.Facility.Include(s => s.Instruments).Where(s=>s.Id==id ).FirstAsync();

            if (facility == null)
            {
                return NotFound();
            }

            return facility;
        }

        // PUT: api/Facilities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacility(int id, Facility facility)
        {
            if (id != facility.Id)
            {
                return BadRequest();
            }

            _context.Entry(facility).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacilityExists(id))
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

        // POST: api/Facilities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Facility>> PostFacility(Facility facility)
        {
          if (_context.Facility == null)
          {
              return Problem("Entity set 'CoreIst_ReservationApp_WebAPIContext.Room'  is null.");
          }
            _context.Facility.Add(facility);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacility", new { id = facility.Id }, facility);
        }

        // DELETE: api/Facilities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacility(int id)
        {
            if (_context.Facility == null)
            {
                return NotFound();
            }
            var facility = await _context.Facility.FindAsync(id);
            if (facility == null)
            {
                return NotFound();
            }

            _context.Facility.Remove(facility);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacilityExists(int id)
        {
            return (_context.Facility?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
