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
    public class MunicipioController : ControllerBase
    {
        private readonly DbmindCareContext _context;

        public MunicipioController(DbmindCareContext context)
        {
            _context = context;
        }

        // GET: api/Municipio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Municipio>>> GetMunicipios()
        {
            return await _context.Municipios.ToListAsync();
        }

        // GET: api/Municipio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Municipio>> GetMunicipio(int id)
        {
            var municipio = await _context.Municipios.FindAsync(id);

            if (municipio == null)
            {
                return NotFound();
            }

            return municipio;
        }

        [HttpGet("departamento/{idDepartamento}")]
        public async Task<ActionResult<IEnumerable<Municipio>>> GetMunicipioPorDepartamento(int idDepartamento)
        {
            var municipio = await _context.Municipios.Where(x => x.DepartamentoId == idDepartamento).ToListAsync();

            if (municipio == null)
            {
                return NotFound();
            }

            return municipio;
        }

        // PUT: api/Municipio/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMunicipio(int id, Municipio municipio)
        {
            if (id != municipio.Id)
            {
                return BadRequest();
            }

            _context.Entry(municipio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MunicipioExists(id))
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

        // POST: api/Municipio
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Municipio>> PostMunicipio(Municipio municipio)
        {
            _context.Municipios.Add(municipio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMunicipio", new { id = municipio.Id }, municipio);
        }

        // DELETE: api/Municipio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMunicipio(int id)
        {
            var municipio = await _context.Municipios.FindAsync(id);
            if (municipio == null)
            {
                return NotFound();
            }

            _context.Municipios.Remove(municipio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MunicipioExists(int id)
        {
            return _context.Municipios.Any(e => e.Id == id);
        }
    }
}
