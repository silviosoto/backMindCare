using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using Data.Contracts;
using Domain.Models;
using System.Linq.Expressions;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipioController : ControllerBase
    {
        private readonly IRepository<Municipio> _repository;
        private readonly ILogger<MunicipioController> _logger;

        public MunicipioController(IRepository<Municipio> repository,
            ILogger<MunicipioController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET: api/Municipio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Municipio>>> GetMunicipios()
        {
            try
            {
                var items = await _repository.GetAllAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all items.");
                return StatusCode(500, "Internal server error.");
            }
        }

        // GET: api/Municipio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Municipio>> GetMunicipio(int id)
        {
            try
            {
                var Municipio = await _repository.GetByIdAsync(id);

                if (Municipio == null)
                {
                    return NotFound();
                }

                return Municipio;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all items.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("departamento/{idDepartamento}")]
        public async Task<ActionResult<IEnumerable<Municipio>>> GetMunicipioPorDepartamento(int idDepartamento)
        {
            try
            {
                //var municipio = await _context.Municipios.Where(x => x.DepartamentoId == idDepartamento).ToListAsync();
                Expression<Func<Municipio, bool>> filter = c => c.DepartamentoId == idDepartamento;
                var municipio = await _repository.FindAsync(filter);
                if (municipio == null)
                {
                    return NotFound();
                }

                return municipio.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all items.");
                return StatusCode(500, "Internal server error.");
            }

        }

        // PUT: api/Municipio/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMunicipio(int id, Municipio municipio)
        {
            try
            {

                if (id != municipio.Id)
                {
                    return BadRequest();
                }
                _repository.UpdateAsync(municipio);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all items.");
                return StatusCode(500, "Internal server error.");
            }
        }

        // POST: api/Municipio
        [HttpPost]
        public async Task<ActionResult<Municipio>> PostMunicipio(Municipio municipio)
        {
            try
            {
                await _repository.AddAsync(municipio);
                return CreatedAtAction("Getmunicipio", new { id = municipio.Id }, municipio);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all items.");
                return StatusCode(500, "Internal server error.");
            }
        }

        // DELETE: api/Municipio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMunicipio(int id)
        {
            try
            {
                var municipio = await _repository.GetByIdAsync(id);
                if (municipio == null)
                {
                    return NotFound();
                }
                await _repository.SoftDeleteAsync(municipio.Id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all items.");
                return StatusCode(500, "Internal server error.");
            }
        }

    }
}
