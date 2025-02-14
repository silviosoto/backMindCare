using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using NuGet.Protocol.Core.Types;
using BLL.PsicologoBll;
using API.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;
using Data.Contracts;
using Domain.DTO; 

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PsicologoController : ControllerBase
    {
        private readonly PsicologoService _psicologoServices;
        private readonly IRepository<DatosPersonale> _repositorydPersonales;

        public PsicologoController( PsicologoService psicologoServices,
            IRepository<DatosPersonale> repositorydPersonales)   
        {
            _psicologoServices = psicologoServices;
            _repositorydPersonales = repositorydPersonales;
        }
         
        [HttpGet()]
        public async Task<ActionResult> ListPsicologos(int? pageNumber)
        {
            int pageSize = 10;
            var psicologo = await _psicologoServices.GetPaginatedEntities(pageNumber ?? 1, pageSize);

            if (psicologo == null)
            {
                return NotFound();
            }

            return Ok(psicologo);
        }

        [HttpGet("all")]
        public async Task<IActionResult> ListPsicologosPagination(int pageNumber)
        {
            int pageSize = 10;
            var psicologo = await _psicologoServices.GetPsicologos(pageNumber, pageSize);

            if (psicologo == null)
            {
                return NotFound();
            }

            return Ok(psicologo);
        }

        // GET: api/Psicologoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPsicologo(int id)
        {
            //var psicologo = await _psicologoServices.GetPsicologoByUser(id);

            var psicologo = await _psicologoServices.GetPsicologoById(id);
            
            if (psicologo == null)
            {
                return NotFound();
            }
            var filePath = Path.Combine("wwwroot/uploads", psicologo.ImagePerfil);

            //if (!System.IO.File.Exists(filePath))
            //{
            //    return NotFound(new { Message = "Image not found." });
            //}

            // Leer los bytes de la imagen
            var imageBytes = System.IO.File.ReadAllBytes(filePath);
            var base64Image = Convert.ToBase64String(imageBytes);

            

            var responsePsicologo = new
            {
                psicologo,
                ImageBase64 = base64Image// Imagen codificada en base64
            };
            
            return Ok(responsePsicologo);
        }

        [AllowAnonymous]
        [HttpPost("InsertService")]
        public async Task<ActionResult> InsertService(PsicologoServicioDTO psicologoServicioDTO)
        {

            try
            {
                var psicologo = await _psicologoServices.InsertService(psicologoServicioDTO);

                if (psicologo == null)
                {
                    return NotFound();
                }

                return Ok(psicologo);

            }
            catch(BLLException ex)
            {
                return BadRequest(new { Message = ex.Message, Details = ex.InnerException?.Message });
            }
            catch(Exception ex)
            {
               return  BadRequest(ex.Message);  
            }

        }

        [AllowAnonymous]
        [HttpGet("getServicioPorPsicologo/{userId}/{pageNumber}")]
        public async Task<ActionResult> getServicioPorPsiclogo(int userId, int pageNumber)
        {
            try
            {
                var psicologo = await _psicologoServices.GetServicios(userId, pageNumber);

                if (psicologo == null)
                {
                    return NotFound();
                }

                return Ok(psicologo);

            }catch (Exception ex) { 
                return BadRequest(ex.Message);  
            }

        }

        [HttpGet("getServicioPorPsicologo/{idPsicologo}")]
        public async Task<ActionResult> getServicioPorPsiclogo(int idPsicologo)
        {
            try
            {
                var psicologo = await _psicologoServices.GetServicios(idPsicologo);

                if (psicologo == null)
                {
                    return NotFound();
                }

                return Ok(psicologo);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("eliminarServicioPsicologo/{psicologoServicioId}")]
        public async Task<ActionResult> DeleteServicioPsicologo(int psicologoServicioId)
        {
            try
            {
                var deleted = await _psicologoServices.DeletePsicologoServicio(psicologoServicioId);

                if (deleted == false)
                {
                    return NotFound();
                }

                return Ok(new { message = "Resource deleted successfully" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("UpdatePsicologoServicio/{id}")]
        public async Task<IActionResult>UpdatePsicologoservicios(int id, [FromBody] UpdatePsicologoServiciosDTO updatePsicologoServiciosDTO)
        {
            try
            {
                var result = await _psicologoServices.UpdatePsicologoServicio( id, updatePsicologoServiciosDTO);

                if (result == false)
                {
                    return NotFound();
                }
                return Ok(new { Message = "registro guardado con exito" });

            }catch (Exception ex)
            {
                return BadRequest();
            }

        }


        [AllowAnonymous]
        [Consumes("Multipart/form-data")]
        [HttpPost("updatePsicology")]
        public async Task<ActionResult<Psicologo>> UpdatePsicology([FromForm] PsicologoCreateDTO psicologoDto,
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

                string? FileName = psicologoDto.file?.FileName;
                const long MaxFileSize = 5 * 1024 * 1024; // 5 MB

                //if (!string.IsNullOrEmpty(FileName))
                //{
                //    if (psicologoDto.file.Length > MaxFileSize)
                //    {
                //        return BadRequest(new { error = "El archivo ha exedido el limite ." });
                //    }

                //    if (!psicologoDto.file.FileName.EndsWith(".pdf"))
                //    {
                //        return BadRequest(new { error = "Solo se permiten documentos PDF." });
                //    }
                //}

                string? FileNameImageProfile = psicologoDto.image?.FileName;
                const long MaxFileSizeImageProfile = 51200; // 5 MB
                var filePath = Path.Combine("wwwroot/uploads", FileNameImageProfile);

                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                if (!string.IsNullOrEmpty(FileNameImageProfile))
                {
                    if (psicologoDto.image.Length > MaxFileSize)
                    {
                        return BadRequest(new { error = "El archivo ha exedido el limite ." });
                    }

                    if (!(psicologoDto.image.FileName.EndsWith(".png") 
                            || psicologoDto.image.FileName.EndsWith(".jpg")))
                    {
                        return BadRequest(new { error = "Solo se permiten documentos png or jpg" });
                    }
                }

                //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", FileName);

                //using (var stream = new FileStream(path, FileMode.Create))
                //{
                //    await psicologoDto.file.CopyToAsync(stream);
                //}

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", FileNameImageProfile);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await psicologoDto.image.CopyToAsync(stream);
                }

                _IdDatosPersonalesNavigation.FechaCreacion = DateTime.Now;
                string numeroid = _IdDatosPersonalesNavigation.NumeroId;

                bool exists = await _repositorydPersonales.ExistsAsync(c => c.NumeroId == numeroid);

                if (!exists)
                {
                    return BadRequest(new { error = "El usuario no se encuentra registrado" });
                }

                Psicologo psicologo = await _psicologoServices.GetPsicologoById(psicologoDto.Id);
                var imagePerfilDB = Path.Combine("wwwroot/uploads", psicologo.ImagePerfil);

                if (System.IO.File.Exists(imagePerfilDB))
                {
                    System.IO.File.Delete(imagePerfilDB);
                }

                //Psicologo psicologo = new();
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
                psicologo.FechaCreacion = DateTime.Now;
                psicologo.ImagePerfil = FileNameImageProfile;
                _psicologoServices.UpdatePsicologo(psicologo);

                //_psicologoServices.AddPsicologo(psicologo);
                // subir archivo a Azure
                //string result = await _azureStorageService.UploadAsync(psicologoDto.file, psicologoDto.file.FileName);

                return CreatedAtAction("GetPsicologo", new { id = psicologo.Id }, psicologo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [AllowAnonymous]
        [Consumes("Multipart/form-data")]
        [HttpPost("registerPsicology")]
        public async Task<ActionResult<Psicologo>> registerPsicology([FromForm] PsicologoCreateDTO psicologoDto,
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
                _IdDatosPersonalesNavigation.FechaCreacion = DateTime.Now;
                string numeroid = _IdDatosPersonalesNavigation.NumeroId;

                bool exists = await _repositorydPersonales.ExistsAsync(c => c.NumeroId == numeroid);

                if (exists)
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
                psicologo.FechaCreacion = DateTime.Now;

                _psicologoServices.AddPsicologo(psicologo);
                // subir archivo a Azure
                //string result = await _azureStorageService.UploadAsync(psicologoDto.file, psicologoDto.file.FileName);

                return CreatedAtAction("GetPsicologo", new { id = psicologo.Id }, psicologo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
