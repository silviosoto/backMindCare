using API.Models;
using AutoMapper;
using BLL.DTOs;
using Data.Models;
using Domain.DTO;
using Domain.Models;

namespace BLL.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UpdatePsicologoServiciosDTO, PsicologoServicio>();
            CreateMap<HobbiesDTO, Hobbies>();
            CreateMap<AgendaDTO, Agenda>();
            CreateMap<PacienteDTO, Paciente>();
            CreateMap<DatosPersonaleDTO, DatosPersonale>();
            CreateMap<UserDTO, User>();
            CreateMap<PacienteUpdateDTO, Paciente>();
            CreateMap<DatosPersonaleCreateDTO, DatosPersonale>();
            CreateMap<DatosPersonaleUpdateDTO, DatosPersonale>();
            CreateMap<CitaCreateDTO, Cita>();
            CreateMap<SalaCreateDTO, Sala>();
            CreateMap<FacturaDto, Domain.Models.Factura>();
            CreateMap<FacturaDetalleDto, FacturaDetalle>();
            CreateMap<CarritoDeComraCreateDTO, carrito_de_compra>();
            CreateMap<HistoriaClinicaCreateDto, HistoriaClinica>();
            CreateMap<SignosFisicosDTO, SignosFisicos>();
            CreateMap<MentalPersonalDTO, MentalPersonal>();
            CreateMap<HistoriaAcademicaDTO, HistoriaAcademica>();
            CreateMap<RazonesSintomasConductaDTO, RazonesSintomasConducta>();
            CreateMap<DesarrolloPsicosexualDTO, DesarrolloPsicosexual>();
            CreateMap<ExamenEstadoMentalDTO, ExamenEstadoMental>();
            CreateMap<ConceptoPsicologicoDTO, ConceptoPsicologico>();
        }
    }
}
