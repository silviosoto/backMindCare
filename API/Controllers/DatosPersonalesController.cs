using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatosPersonalesController : ControllerBase
    {
        private readonly DbmindCareContext _context;

        public DatosPersonalesController(DbmindCareContext context)
        {
            _context = context;
        }

        // GET: api/DatosPersonales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DatosPersonale>>> GetDatosPersonales()
        {
            return await _context.DatosPersonales.ToListAsync();
        }

        // GET: api/DatosPersonales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DatosPersonale>> GetDatosPersonale(int id)
        {
            var datosPersonale = await _context.DatosPersonales.FindAsync(id);

            if (datosPersonale == null)
            {
                return NotFound();
            }

            return datosPersonale;
        }

        // PUT: api/DatosPersonales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDatosPersonale(int id, DatosPersonale datosPersonale)
        {
            if (id != datosPersonale.Id)
            {
                return BadRequest();
            }

            _context.Entry(datosPersonale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DatosPersonaleExists(id))
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

        // POST: api/DatosPersonales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DatosPersonale>> PostDatosPersonale(DatosPersonale datosPersonale)
        {
            _context.DatosPersonales.Add(datosPersonale);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDatosPersonale", new { id = datosPersonale.Id }, datosPersonale);
        }

        // DELETE: api/DatosPersonales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDatosPersonale(int id)
        {
            var datosPersonale = await _context.DatosPersonales.FindAsync(id);
            if (datosPersonale == null)
            {
                return NotFound();
            }

            _context.DatosPersonales.Remove(datosPersonale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DatosPersonaleExists(int id)
        {
            return _context.DatosPersonales.Any(e => e.Id == id);
        }
    }
}
