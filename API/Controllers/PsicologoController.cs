using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using API.Models.DTOs;
using System.Text.Json;
using NuGet.Protocol;
using API.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PsicologoController : ControllerBase
    {
        private readonly DbmindCareContext _context;
        private readonly IAzureStorageService _azureStorageService;

        public PsicologoController(DbmindCareContext context, IAzureStorageService azureStorageService)
        {
            _context = context;
            _azureStorageService = azureStorageService;
        }

        // GET: api/Psicologoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Psicologo>>> GetPsicologos()
        {
            return await _context.Psicologos.ToListAsync();
        }

        // GET: api/Psicologoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Psicologo>> GetPsicologo(int id)
        {
            var psicologo = await _context.Psicologos.FindAsync(id);

            if (psicologo == null)
            {
                return NotFound();
            }

            return psicologo;
        }

        // PUT: api/Psicologoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPsicologo(int id, Psicologo psicologo)
        {
            if (id != psicologo.Id)
            {
                return BadRequest();
            }

            _context.Entry(psicologo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PsicologoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Psicologoes
      
        [Consumes("Multipart/form-data")]
        [HttpPost]
        public async Task<ActionResult<Psicologo>> PostPsicologo([FromForm] PsicologoCreateDTO psicologoDto,
            [FromForm] string psicologoIdiomas,
            [FromForm] string psicologoServicios,
            [FromForm] string IdDatosPersonalesNavigation
            )
        {
            try
            {
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                List<PsicologoIdioma>? _psicologoIdiomas = JsonSerializer.Deserialize<List<PsicologoIdioma>>(psicologoIdiomas, options);
                List<PsicologoServicio>? _psicologoServicios = JsonSerializer.Deserialize<List<PsicologoServicio>>(psicologoServicios, options);
                DatosPersonale? _IdDatosPersonalesNavigation = JsonSerializer.Deserialize<DatosPersonale>(IdDatosPersonalesNavigation, options);

                string FileName = psicologoDto.file.FileName;
                const long MaxFileSize = 5 * 1024 * 1024; // 5 MB

                if (string.IsNullOrEmpty(FileName))
                {
                    return BadRequest();
                }

                if (psicologoDto.file.Length > MaxFileSize)
                {
                    return BadRequest(new { error = "El archivo ha exedido el limite ." });
                }

                if (!psicologoDto.file.FileName.EndsWith(".pdf"))
                {
                    return BadRequest(new { error = "Solo se permiten documentos PDF." });
                }


                //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", FileName);

                //using (var stream = new FileStream(path, FileMode.Create))
                //{
                //    await psicologoDto.file.CopyToAsync(stream);
                //}


                string numeroid = _IdDatosPersonalesNavigation.NumeroId;
                DatosPersonale datosPersonale = await _context.DatosPersonales.FirstOrDefaultAsync(x => x.NumeroId == numeroid);
                if (datosPersonale != null)
                {
                    return BadRequest(new { error = "El usuario ya se encuentra registrado" });
                }

                Psicologo psicologo = new();
                psicologo.Descripcion = psicologoDto.Descripcion;
                psicologo.Estado = psicologoDto.Estado;
                psicologo.Validado = psicologoDto.Validado;
                psicologo.PsicologoIdiomas = _psicologoIdiomas;
                psicologo.IdDatosPersonales = psicologoDto.IdDatosPersonales;
                psicologo.Experiencia = psicologoDto.Experiencia;
                psicologo.sugerencias = psicologoDto.sugerencias;
                psicologo.IdDatosPersonalesNavigation = _IdDatosPersonalesNavigation;
                psicologo.PsicologoServicios = _psicologoServicios;
                psicologo.File_cv = FileName;

                _context.Psicologos.Add(psicologo);
                await _context.SaveChangesAsync();
                // subir archivo a Azure
                string result = await _azureStorageService.UploadAsync(psicologoDto.file, psicologoDto.file.FileName);

                return CreatedAtAction("GetPsicologo", new { id = psicologo.Id }, psicologo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        // DELETE: api/Psicologoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePsicologo(int id)
        {
            var psicologo = await _context.Psicologos.FindAsync(id);
            if (psicologo == null)
            {
                return NotFound();
            }

            _context.Psicologos.Remove(psicologo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PsicologoExists(int id)
        {
            return _context.Psicologos.Any(e => e.Id == id);
        }
    }
}
