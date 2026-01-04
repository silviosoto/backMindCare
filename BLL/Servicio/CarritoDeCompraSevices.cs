using AutoMapper;
using BLL.Contracts;
using BLL.DTOs;
using DAL.Contracts;
using Domain.DTO;
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace BLL.Servicio
{
    public class CarritoDeCompraSevices : ICarroDeCompraService
    {
        private readonly ICarritoDeCompraRepository _carritoDeCompraRepository;
        private readonly ITerapiaService _terapiaServices;
        private readonly IFacturaService _facturaService;
        private readonly IMapper _mapper;
        private readonly ILogger<CarritoDeCompraSevices> _logger;
        private readonly CitasServices _citasServices;
        private readonly SalaSevices _salaSevices;
       

        public CarritoDeCompraSevices(
            ICarritoDeCompraRepository carritoDeCompraRepository,
            IMapper mapper,
            CitasServices citasServices,
            IFacturaService facturaService,
            ITerapiaService terapiaServices,
            SalaSevices salaSevices
            )
        {
            _carritoDeCompraRepository = carritoDeCompraRepository;
            _mapper = mapper;
            _terapiaServices = terapiaServices;
            _citasServices = citasServices;
            _facturaService = facturaService;
            _salaSevices = salaSevices;
        }

        public async Task<carrito_de_compra> ConfirmarCarritoCompra(int idCarrito)
        {
            try
            { 
                if (idCarrito == 0)
                {
                    throw new ArgumentException("El IdCarrito no puede ser cero.");
                }

                var carrito = await _carritoDeCompraRepository.GetAsync(idCarrito);

                if (carrito == null)
                {
                    throw new KeyNotFoundException($"No se encontró un carrito con Id {idCarrito}.");
                }

                if (carrito.Estado == true)
                {
                    throw new KeyNotFoundException($"El carrito :Id {idCarrito}, ya fue comprado");
                }

                //quiere decir que esta comprado el carrito
                carrito.Estado = true;
                await _carritoDeCompraRepository.UpdateCarritoAsync(carrito);
                
                // crear la terapia
                Terapia terapia = new Terapia
                {
                    Idpsicologo = carrito.IdPsicologo,
                    idPaciente = carrito.IdPaciente,
                    Idservicio = carrito.IdServicio,
                    espaquete = carrito.EsPaquete,
                    valor = carrito.ValorServicio,
                    NumeroSesiones = carrito.NumeroSesiones,
                    FechaCreacion = DateTime.Now,
                    IdUsuarioCreacion = (int)carrito.IdUsuarioCreacion
                };

                var terapiaResult = await _terapiaServices.Crear(terapia);


                // crear cita
                CitaCreateDTO citaDTO = new CitaCreateDTO
                {
                    Idpsicologo = carrito.IdPsicologo,
                    Idpaciente = carrito.IdPaciente,
                    IdTerapia = terapia.Id,
                    IdServicio = carrito.IdServicio,
                    ValorServicio = carrito.ValorServicio,
                    Fecha = carrito.Fecha,
                    Hora = carrito.Hora                   
                };

               var cita = await _citasServices.ApartarCita(citaDTO);

                // crear factura
                var factura = new FacturaDto
                {
                    IdPaciente = carrito.IdPaciente,
                    Detalles = new List<FacturaDetalleDto>
                    {
                        new FacturaDetalleDto
                        {
                            IdServicio = carrito.IdServicio,
                            ispackage = carrito.EsPaquete,
                            Cantidad = carrito.NumeroSesiones,
                            ValorUnitario = carrito.ValorServicio,
                            PorcentajeIva = 0.19m,
                            IdTerapia = terapiaResult.Id
                        }
                    }
                };
                
                await _facturaService.CrearFactura(factura);

                // crear sala
                var fecha = cita.Fecha + cita.Hora;
                SessionRequestDTO sessionRequestDTO = new SessionRequestDTO();
                sessionRequestDTO.IdCita = cita.Id;
                sessionRequestDTO.PsicologoId = cita.Idpsicologo;
                sessionRequestDTO.HoraCita = (DateTime)fecha;
                sessionRequestDTO.PacienteId = cita.Idpaciente;

                await _salaSevices.CreateSala(sessionRequestDTO);

                return await Task.FromResult(carrito);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error al confirmar el carrito de compra");
                throw;
            }

        }

        public async Task<carrito_de_compra> Crear(CarritoDeComraCreateDTO carritoDTO, int idUser)
        {
            try
            {
                carrito_de_compra carrito = _mapper.Map<carrito_de_compra>(carritoDTO);
                carrito.FechaCreacion = DateTime.Now;
                carrito.IdUsuarioCreacion = idUser;
                //carrito.Estado = EstadoCarritoCompra.creado;
                carrito.Estado = true;
                
                await _carritoDeCompraRepository.CrearAsync(carrito);
                return await Task.FromResult(carrito);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el carrito de compra");
                throw;
            }
        }
    }
}
