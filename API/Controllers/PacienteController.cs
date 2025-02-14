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
using BLL.HobbiesBLL;
using Domain.DTO;
using BLL.Servicio;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Azure.Core;
using Data.Models;
using System.Security.Claims;
using API.Models.DTOs;
using System.Text.Json;
using BLL.PsicologoBll;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly PacienteService _pacienteService;
        private readonly ILogger<PacienteController> _logger;
        private readonly IJwtAuthManager _jwtAuthManager;
        private readonly IRepository<DatosPersonale> _repositorydPersonales;

        public PacienteController(PacienteService pacienteService,
            ILogger<PacienteController> logger,
            IRepository<DatosPersonale> repositorydPersonales,
            IJwtAuthManager jwtAuthManager)
        {
            _pacienteService = pacienteService;
            _logger = logger;
            _jwtAuthManager = jwtAuthManager;
            _repositorydPersonales = repositorydPersonales;
        }
   
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var paciente = await _pacienteService.GetPacientByUser(id);
                var base64Image = "";

                if (paciente.DatosPersonale.ImagePerfil != null) { 
                    var filePath = Path.Combine("wwwroot/uploads", paciente.DatosPersonale.ImagePerfil);

                    // Leer los bytes de la imagen
                    var imageBytes = System.IO.File.ReadAllBytes(filePath);
                    base64Image = Convert.ToBase64String(imageBytes);
                }

                if (paciente == null)
                {
                    return NotFound();
                }

                var responsePaciente = new
                {
                    paciente,
                    ImageBase64 = base64Image ?? null // Imagen codificada en base64
                };
                return Ok(responsePaciente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            } 

        }

        [HttpPut("image/{id}")]
        public async Task<IActionResult> UploadProfileImage(int id, [FromForm] IFormFile? image)
        {
            try
            {
                if (image == null || image.Length == 0)
                {
                    return BadRequest("No image was uploaded.");
                }
                string FileName = image.FileName;

                // Guardar la imagen en el servidor
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", FileName);


                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                await _pacienteService.saveImage(id, FileName);
                return Ok(new { Message = "Image uploaded successfully!", ImagePath = $"/images/{image.FileName}" });

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }

        [HttpPost()]
        public async Task<ActionResult> Insert(PacienteDTO pacienteDTO)
        {
            try
            {
                var paciente = await _pacienteService.Insert(pacienteDTO);

                var claims = new[]
{
                new Claim(ClaimTypes.Name, paciente.DatosPersonale.Email),
                    new Claim(ClaimTypes.Role, "Paciente")
                };
                var user = paciente.DatosPersonale.User;
                var jwtResult = _jwtAuthManager.GenerateTokens(paciente.DatosPersonale.Email, claims, DateTime.Now);
                //SetRefreshTokenInCookie(jwtResult.RefreshToken.TokenString);

                return Ok(new LoginResult
                {
                    UserId = user.Id,
                    UserName = user.Username,
                    Profile = "Paciente",
                    AccessToken = jwtResult.AccessToken,
                    RefreshToken = jwtResult.RefreshToken.TokenString
                });
           
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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePaciente(int id, PacienteUpdateDTO pacienteUpdateDTO)
        {
            try
            {

                var result = await _pacienteService.Update(id, pacienteUpdateDTO);
                
                return NoContent();
  
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        
    }
}
