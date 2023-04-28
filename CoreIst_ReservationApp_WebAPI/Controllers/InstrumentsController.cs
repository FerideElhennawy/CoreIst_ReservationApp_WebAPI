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
    public class InstrumentsController : ControllerBase
    {
        private readonly CoreIst_ReservationApp_WebAPIContext _context;

        public InstrumentsController(CoreIst_ReservationApp_WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/Instruments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instrument>>> GetInstrument()
        {
          if (_context.Instrument == null)
          {
              return NotFound();
          }
            return await _context.Instrument.ToListAsync();
        }

        // GET: api/Instruments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Instrument>> GetInstrument(int id)
        {
          if (_context.Instrument == null)
          {
              return NotFound();
          }
            var instrument = await _context.Instrument.FindAsync(id);

            if (instrument == null)
            {
                return NotFound();
            }

            return instrument;
        }

        // PUT: api/Instruments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstrument(int id, Instrument instrument)
        {
            if (id != instrument.Id)
            {
                return BadRequest();
            }

            _context.Entry(instrument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstrumentExists(id))
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

        // POST: api/Instruments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Instrument>> PostInstrument(Instrument instrument)
        {
          if (_context.Instrument == null)
          {
              return Problem("Entity set 'CoreIst_ReservationApp_WebAPIContext.Instrument'  is null.");
          }
            _context.Instrument.Add(instrument);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstrument", new { id = instrument.Id }, instrument);
        }

        // DELETE: api/Instruments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstrument(int id)
        {
            if (_context.Instrument == null)
            {
                return NotFound();
            }
            var instrument = await _context.Instrument.FindAsync(id);
            if (instrument == null)
            {
                return NotFound();
            }

            _context.Instrument.Remove(instrument);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstrumentExists(int id)
        {
            return (_context.Instrument?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
