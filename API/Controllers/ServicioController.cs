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
    public class ServicioController : ControllerBase
    {
        private readonly DbmindCareContext _context;

        public ServicioController(DbmindCareContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Servicio>>> GetServicio()
        {
            return await _context.Servicios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Servicio>> GetServicio(int id)
        {
            var Servicios = await _context.Servicios.FindAsync(id);

            if (Servicios == null)
            {
                return NotFound();
            }

            return Servicios;
        }

    }
}
