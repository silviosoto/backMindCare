using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositorys;
using Microsoft.Extensions.Logging;
using AutoMapper; 
using Domain.Models;
using Domain.DTO;
using API.Models;
using Data.Models;
using Data.Contracts;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Azure.Core;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace BLL.HobbiesBLL
{
    public class SalaSevices
    {
        private readonly SalaRepository _salaRepository;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;


        public SalaSevices(SalaRepository salaRepository, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _salaRepository = salaRepository;
            _mapper = mapper;
            _httpClient.DefaultRequestHeaders.Authorization =
           new AuthenticationHeaderValue("Bearer", "02cefa924053d8d676bf7ee47f0cedead3904f3f1347f0678a37efbc8bf46649");
        }
        
        public async Task<Sala> SaveSala(SalaCreateDTO salaCreateDTO)
        {
            try
            {              
                Sala sala = _mapper.Map<Sala>(salaCreateDTO);
                sala.FechaCreacion = DateTime.Now;
           
                await _salaRepository.AddAsync(sala);
                return sala;
            }
            catch (Exception e)
            {
                throw new BLLException(e.Message, e);
            }
        } 

        public async Task CreateSala(SessionRequestDTO request)
        {
            try
            {
                // 1. Crear sala en Daily.co
                string roomName = $"sesion-{Guid.NewGuid():N}";
                var roomExpiration = request.HoraCita.AddMinutes(60);
                roomExpiration = roomExpiration.AddHours(5);

                var roomResponse = await CreateRoomAsync(roomName, roomExpiration);
                var s = await roomResponse.Content.ReadAsStreamAsync();
                if (!roomResponse.IsSuccessStatusCode)
                {
                    throw new BLLException("Error al crear la sala");
                }

                // 2. Leer respuesta de Daily.co de forma segura
                using JsonDocument roomDoc = await JsonDocument.ParseAsync(
                    await roomResponse.Content.ReadAsStreamAsync()
                );
                JsonElement roomData = roomDoc.RootElement;

                if (!roomData.TryGetProperty("url", out JsonElement urlElement))
                {
                    throw new BLLException("Error al crear la sala");
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
                salaCreateDTO.TokenHost = hostToken;
                salaCreateDTO.UrlHuesped = roomUrl;
                salaCreateDTO.TokenHuesped = guestToken;
                salaCreateDTO.fechahora = request.HoraCita;
                salaCreateDTO.IdCita = request.IdCita;

                await SaveSala(salaCreateDTO);
            }
            catch (Exception e)
            {
                throw new BLLException(e.Message, e);
            }
            
        }

        private async Task<HttpResponseMessage> CreateRoomAsync(string roomName, DateTime roomExpiration)
        {
            try
            {
                var requestData = new
                {
                    privacy = "private",
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
