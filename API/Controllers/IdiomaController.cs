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
    public class IdiomaController : ControllerBase
    {
        private readonly DbmindCareContext _context;

        public IdiomaController(DbmindCareContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Idioma>>> GetServicio()
        {
            return await _context.Idiomas.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Idioma>> GetServicio(int id)
        {
            var Idioma = await _context.Idiomas.FindAsync(id);

            if (Idioma == null)
            {
                return NotFound();
            }

            return Idioma;
        }

    }
}
