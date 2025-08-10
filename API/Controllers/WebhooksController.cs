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
using System.Text.Json.Serialization;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebhooksController : ControllerBase
    {
        private readonly ILogger<ServicioController> _logger;
        private readonly ServicioService _servicioService;

        public WebhooksController(ServicioService servicioService,
            ILogger<ServicioController> logger)
        {
            _servicioService = servicioService;
            _logger = logger;
        }
         
        [HttpPost("daily")]
        public async Task<IActionResult> HandleWebhook(
            [FromBody] DailyWebhookPayload payload
            )
        {
            // 1. Validar firma (opcional pero recomendado)
            //if (!VerifySignature(signature, payload))
            //{
            //    _logger.LogWarning("Firma inválida");
            //    return Unauthorized();
            //}
            _logger.LogInformation("ENTRO EN LA FUNCION DE RECIVIR LOS EVENTOS");

            try
            {
                // 2. Procesar evento
                switch (payload.EventType)
                {
                    case "participant-joined":
                        await HandleParticipantJoined(payload);
                        break;

                    case "participant-left":
                        await HandleParticipantLeft(payload);
                        break;

                    case "meeting-ended":
                        await HandleMeetingEnded(payload);
                        break;
                }

                return Ok(payload);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
          
        }

        //private bool VerifySignature(string signature, DailyWebhookPayload payload)
        //{
        //    var secret = Environment.GetEnvironmentVariable("DAILY_WEBHOOK_SECRET");
        //    var computedSignature = ComputeSignature(secret, payload);
        //    return computedSignature == signature;

        private async Task HandleParticipantLeft(DailyWebhookPayload payload)
        {
            _logger.LogInformation("Se ha ejecutado el evento de salida:");
            Ok(payload);
        }
        private async Task HandleMeetingEnded(DailyWebhookPayload payload)
        {
            _logger.LogInformation("Se ha ejecutado el evento de Finalizacion");
            Ok(payload);
        }

        private async Task HandleParticipantJoined(DailyWebhookPayload payload)
        {
            _logger.LogInformation("Se ha ejecutado el evento de entrar a la reunion");
            Ok(payload);
        }
    }


    // Modelo para el payload
    public class DailyWebhookPayload
    {
        [JsonPropertyName("event")]
        public string EventType { get; set; }

        [JsonPropertyName("room")]
        public string RoomName { get; set; }

        [JsonPropertyName("participant")]
        public DailyParticipant Participant { get; set; }
    }

    public class DailyParticipant
    {
        [JsonPropertyName("user_id")]
        public string UserId { get; set; } // ¡Usa este campo para identificar usuarios!
    }
}
