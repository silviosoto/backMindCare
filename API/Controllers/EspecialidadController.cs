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

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
 
        private readonly IRepository<Especialidad> _repository;
        private readonly ILogger<EspecialidadController> _logger;

        public EspecialidadController(IRepository<Especialidad> repository,
                ILogger<EspecialidadController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET: api/Especialidad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Especialidad>>> GetEspecialidads()
        {
            try
            {
                var items = await _repository.GetAllAsync();
                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all items.");
                // Puedes personalizar la respuesta de error como sea necesario
                return StatusCode(500, "Internal server error.");
            }

        }

        // GET: api/Especialidad/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Especialidad>> GetEspecialidad(int id)
        {
            var especialidad = await _repository.GetByIdAsync(id);

            if (especialidad == null)
            {
                return NotFound();
            }

            return especialidad;
        }

        // PUT: api/Especialidad/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecialidad(int id, Especialidad especialidad)
        {
            try
            {
                if (id != especialidad.Id)
                {
                    return BadRequest();
                }

                _repository.UpdateAsync(especialidad);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all items.");
                return StatusCode(500, "Internal server error.");
            }

        }

        // POST: api/Especialidad
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Especialidad>> PostEspecialidad(Especialidad especialidad)
        {

            try
            {
                await _repository.AddAsync(especialidad);
                return CreatedAtAction("GetEspecialidad", new { id = especialidad.Id }, especialidad);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all items.");
                return StatusCode(500, "Internal server error.");
            }
        }

        // DELETE: api/Especialidad/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecialidad(int id)
        {
            try
            {
                var Especialidad = await _repository.GetByIdAsync(id);
                if (Especialidad == null)
                {
                    return NotFound();
                }
                await _repository.SoftDeleteAsync(Especialidad.Id);

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
