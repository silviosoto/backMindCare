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
using BLL.PsicologoBll;
using BLL.Servicio;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly ILogger<ServicioController> _logger;
        private readonly ServicioService _servicioService;

        public ServicioController(ServicioService servicioService,
            ILogger<ServicioController> logger)
        {
            _servicioService = servicioService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servicio>>> GetServicio()
        {
            try
            {
                var items = await _servicioService.GetAllServicio();
                return Ok(items);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all items.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Servicio>> GetServicio(int id)
        {
            try
            {
                var Servicio = await _servicioService.GetServicioById(id);

                if (Servicio == null)
                {
                    return NotFound();
                }

                return Servicio;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all items.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("SearchCoincenceServiceName/{nombre}")]
        public async Task<ActionResult<IEnumerable<Servicio>>> SearchCoincenceServiceName(string nombre)
        {
            try
            {
                var Servicio = await _servicioService.SearchCoincenceServiceName(nombre);

                if (Servicio == null)
                {
                    return NotFound();
                }

                return Ok(Servicio);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting all items.");
                return StatusCode(500, "Internal server error.");
            }
        }

    }
}
