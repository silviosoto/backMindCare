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
    public class HobbiesController : Controller
    {
        private readonly HobbiesSevices _hobbiesSevices;
        private readonly ILogger<ServicioController> _logger;
        public HobbiesController(HobbiesSevices hobbiesSevices, ILogger<ServicioController> logger)
        {
            _hobbiesSevices = hobbiesSevices;
            _logger = logger;
        }

        [HttpPost()]
        public async Task<ActionResult> Insert(HobbiesDTO hobbiesDTO)
        {
            try
            {
               var hoobies =   await _hobbiesSevices.Insert(hobbiesDTO);
                return CreatedAtAction(nameof(Insert), new { id = hoobies.Id }, hoobies);
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
        public async Task<IActionResult> DeleteHobbie(int id)
        {
            try
            {
                var Hobbie = await _hobbiesSevices.GetHobbieById(id);
                if (Hobbie == null)
                {
                    return NotFound();
                }
                await _hobbiesSevices.SoftDeleteAsync(Hobbie.Id);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all items.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hobbies>>> GetHobbies()
        {
            try
            {
                var items = await _hobbiesSevices.GetAll();
                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all items.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHobbie(int id, HobbiesDTO hobbiesDTO)
        {
            try
            {
                await _hobbiesSevices.Update(id, hobbiesDTO);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all items.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("ByUser/{idUser}")]
        public async Task<ActionResult<IEnumerable<Hobbies>>> GetHobbies(int idUser)
        {
            try
            {
                var items = await _hobbiesSevices.GethobbiesByUser(idUser);
                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all items.");
                return StatusCode(500, "Internal server error.");
            }
        }

    }
}
