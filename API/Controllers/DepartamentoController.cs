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
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {
        private readonly IRepository<Departamento> _repository;
        private readonly ILogger<DepartamentoController> _logger;

        public DepartamentoController(IRepository<Departamento> repository,
            ILogger<DepartamentoController> logger)
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
                 return StatusCode(500, "Internal server error.");
            }
        }

        // GET: api/Departamento/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> GetDepartamento(int id)
        {
            try
            {
                var departamento = await _repository.GetByIdAsync(id);

                if (departamento == null)
                {
                    return NotFound();
                }

                return departamento;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all items.");
                return StatusCode(500, "Internal server error.");
            }

        }

        // PUT: api/Departamento/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartamento(int id, Departamento departamento)
        {
            try {
               
                if (id != departamento.Id)
                {
                    return BadRequest();
                }

                _repository.UpdateAsync(departamento);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all items.");
                return StatusCode(500, "Internal server error.");
            }

        }

        // POST: api/Departamento
        [HttpPost]
        public async Task<ActionResult<Departamento>> PostDepartamento(Departamento departamento)
        {
            try
            {
                await _repository.AddAsync(departamento);
                return CreatedAtAction("GetDepartamento", new { id = departamento.Id }, departamento);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all items.");
                return StatusCode(500, "Internal server error.");
            }
        }

        // DELETE: api/Departamento/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartamento(int id)
        {
            try
            {
                var departamento = await _repository.GetByIdAsync(id);
                if (departamento == null)
                {
                    return NotFound();
                }
                await _repository.SoftDeleteAsync(departamento.Id);

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
