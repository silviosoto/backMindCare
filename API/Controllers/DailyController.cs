using Azure.Core;
using BLL.Servicio;
using Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;

namespace API.Controllers
{ 
    [Authorize]
    [ApiController]
    [Route("api/daily")]
    public class DailyController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<DailyController> _logger;
        private readonly SalaSevices _saasSevices;
        public DailyController(
            SalaSevices salaSevices,
            IHttpClientFactory httpClientFactory,
            ILogger<DailyController> logger)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "02cefa924053d8d676bf7ee47f0cedead3904f3f1347f0678a37efbc8bf46649");
            _logger = logger;
            _saasSevices = salaSevices;
        }

        [HttpPost("create-room")]
        public async Task<IActionResult> CreateSession([FromBody] SessionRequestDTO request)
        {
            try
            {
                // 1. Crear sala
                string roomName = $"sesion-{Guid.NewGuid():N}";
                var roomExpiration = request.HoraCita.AddMinutes(60);
                roomExpiration = roomExpiration.AddHours(5);

                var roomResponse = await CreateRoomAsync(roomName, roomExpiration);
                var s = await roomResponse.Content.ReadAsStreamAsync();
                if (!roomResponse.IsSuccessStatusCode)
                {
                    _logger.LogError("Daily.co API error: {StatusCode}", roomResponse.StatusCode);
                    return StatusCode(500, "Error al crear la sala");
                }

                // 2. Leer respuesta de Daily.co de forma segura
                using JsonDocument roomDoc = await JsonDocument.ParseAsync(
                    await roomResponse.Content.ReadAsStreamAsync()
                );

                JsonElement roomData = roomDoc.RootElement;

                if (!roomData.TryGetProperty("url", out JsonElement urlElement))
                {
                    _logger.LogError("Daily.co response missing 'url' property");
                    return StatusCode(500, "Respuesta inválida de Daily.co");
                }

                string roomUrl = urlElement.GetString();


                // 3. Generar tokens
                //solo se puede entrar 5 min antes de la reunion por temas de costos
                string hostToken = await GenerateTokenAsync(roomName, isOwner: true, request.PsicologoId,
                    expiration: roomExpiration,
                    notBefore: request.HoraCita.AddMinutes(-5));
                string guestToken = await GenerateTokenAsync(roomName, isOwner: false, request.PacienteId,
                    expiration: roomExpiration,
                    notBefore: request.HoraCita.AddMinutes(-5));

                SalaCreateDTO salaCreateDTO = new SalaCreateDTO();
                salaCreateDTO.UrlHost = roomUrl;
                salaCreateDTO.UrlHuesped = hostToken;
                salaCreateDTO.fechahora = request.HoraCita;
                salaCreateDTO.IdCita = request.IdCita;
                await _saasSevices.SaveSala(salaCreateDTO);

                return Ok(new
                {
                    HostUrl = $"{roomUrl}?t={hostToken}",
                    GuestUrl = $"{roomUrl}?t={guestToken}",
                    ScheduledVideoCall = request.HoraCita,
                    ExpiresAt = DateTime.UtcNow.AddHours(1).ToString("o")
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en CreateSession");
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

        private async Task<HttpResponseMessage> CreateRoomAsync(string roomName, DateTime roomExpiration)
        {
            try
            {
                var requestData = new
                {
                    name = roomName,
                    properties = new
                    {
                        enable_knocking = false,
                        exp = new DateTimeOffset(roomExpiration).ToUnixTimeSeconds()
                    }
                };

                var s = new DateTimeOffset(roomExpiration).ToUnixTimeSeconds();

                var respuesta = await _httpClient.PostAsJsonAsync(
                    "https://api.daily.co/v1/rooms",
                    requestData
                );

                return respuesta;

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Error en la solicitud: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error inesperado: {e.Message}");
            }

            return null;

        }

        private async Task<string> GenerateTokenAsync(string roomName, bool isOwner, int userId, DateTime expiration,
                    DateTime? notBefore = null)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "https://api.daily.co/v1/meeting-tokens",
                new
                {
                    properties = new
                    {
                        room_name = roomName,
                        is_owner = isOwner,
                        user_id = userId,
                        exp = new DateTimeOffset(expiration).ToUnixTimeSeconds(),
                        nbf = new DateTimeOffset(notBefore.Value).ToUnixTimeSeconds()
                    }
                }
            );
            var _response = response.Content.ReadAsStringAsync();

            using JsonDocument tokenDoc = await JsonDocument.ParseAsync(
                await response.Content.ReadAsStreamAsync()
            );
            if (!tokenDoc.RootElement.TryGetProperty("token", out JsonElement tokenElement))
            {
                throw new KeyNotFoundException("Token no encontrado en la respuesta");
            }
            return tokenElement.GetString();
        }

    }

}