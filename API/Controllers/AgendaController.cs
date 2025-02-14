using API.Models;
using BLL.HobbiesBLL;
using BLL.PsicologoBll;
using BLL.Servicio;
using Data.Contracts;
using Domain.DTO;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : Controller
    {
        private readonly AgendaSevices _agendaSevices;
        private readonly ILogger<ServicioController> _logger;
        public AgendaController(AgendaSevices agendaSevices, ILogger<ServicioController> logger)
        {
            _agendaSevices = agendaSevices;
            _logger = logger;
        }

        [HttpPost()]
        public async Task<ActionResult> Insert(AgendaDTO agendaDTO)
        {
            try
            {
                var agenda = await _agendaSevices.Insert(agendaDTO);
                return CreatedAtAction(nameof(Insert), new { id = agenda.Id }, agenda);
            }
            catch (BLLException ex)
            {
                return BadRequest(new { Message = ex.Message, Details = ex.InnerException?.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetAgendaByPsicologo")]
        public async Task<ActionResult<IEnumerable<AgendaResponseDTO>>> GetAgendaByPsicologo([FromQuery] AgendaByPsicologoDTO agendaByPsicologoDTO)
        {
            try
            {
                return await _agendaSevices.GetAgendaByPsicologo(agendaByPsicologoDTO);
            }
            catch (BLLException ex)
            {
                return BadRequest(new { Message = ex.Message, Details = ex.InnerException?.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var obj = await _agendaSevices.GetHobbieById(id);
                if (obj == null)
                {
                    return NotFound();
                }
                await _agendaSevices.SoftDeleteAsync(obj.Id);

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
