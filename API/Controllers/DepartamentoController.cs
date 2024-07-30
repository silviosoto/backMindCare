using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using NuGet.Protocol.Core.Types;
using Data.Repository;
using Data.Contracts;
using Domain.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IRepository<Departamento> _repository;
        private readonly ILogger<DepartamentoController> _logger;

        public DepartamentoController(IRepository<Departamento> repository, ILogger<DepartamentoController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET: api/Departamento
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamentos()
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

        // GET: api/Departamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> GetDepartamento(int id)
        {
            var departamento = await _repository.GetByIdAsync(id);
           
            if (departamento == null)
            {
                return NotFound();
            }

            return departamento;
        }

        // PUT: api/Departamento/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartamento(int id, Departamento departamento)
        {
            if (id != departamento.Id)
            {
                return BadRequest();
            }

            _repository.UpdateAsync(departamento);

            return NoContent();
        }

        // POST: api/Departamento
        [HttpPost]
        public async Task<ActionResult<Departamento>> PostDepartamento(Departamento departamento)
        {
            await _repository.AddAsync(departamento);

            return CreatedAtAction("GetDepartamento", new { id = departamento.Id }, departamento);
        }

        // DELETE: api/Departamento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamento(int id)
        {
            var departamento = await _repository.GetByIdAsync(id);
            if (departamento == null)
            {
                return NotFound();
            }
            await _repository.SoftDeleteAsync(departamento.Id);
      
            return NoContent();
        }
    }
}
