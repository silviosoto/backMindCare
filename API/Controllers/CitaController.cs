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
    public class CitaController : Controller
    {
        private readonly CitasServices _citasSevices;
        private readonly ILogger<CitaController> _logger;
        public CitaController(CitasServices citasSevices, ILogger<CitaController> logger)
        {
            _citasSevices = citasSevices;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitaDTO>>> GetHobbies([FromQuery] int idPsicologo, [FromQuery] DateTime fecha)
        {
            try
            {
                var items = await _citasSevices.GetAppointmentsAvailableByPsicologoAndDate(idPsicologo, fecha);
                return Ok(items);
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Cita>> GetAppointment(int id)
        {
            try
            {
                return await _citasSevices.GetAppointment(id);
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

        [HttpPost()]
        public async Task<ActionResult> CreateAppointment(CitaCreateDTO citaCreateDTO)
        {
            try
            {
                var cita = await _citasSevices.ApartarCita(citaCreateDTO);
                return CreatedAtAction(nameof(GetAppointment), new { id = cita.Id }, cita);
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

        [HttpGet("GetAppointmentByPatient")]
        public async Task<ActionResult<CitaDetalleDTO>> GetAppointmentByPatient([FromQuery]int page, [FromQuery] int idPaciente, [FromQuery] int pageSize = 10)
        {
            try
            {
                var response = await _citasSevices.GetAppointmentByPatient(idPaciente, page, pageSize);
                
                return Ok(response);
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

        [HttpGet("cancelar/{idCita}")]
        public async Task<ActionResult<Boolean>> CanaceAppointment(int idCita)
        {
            try
            {
                var citaCancelada = await _citasSevices.CancelAppointment(idCita);
                return Ok(citaCancelada);
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

        [HttpGet("confirmar/{idCita}")]
        public async Task<ActionResult<Boolean>> ConfirmAppointment(int idCita)
        {
            try
            {
                var cita = await _citasSevices.ConfirmAppointment(idCita);
                return Ok(cita);
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

    }
}
