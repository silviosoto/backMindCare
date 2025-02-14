using API.Models;
using AutoMapper;
using Data.Models;
using Domain.DTO;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //CreateMap<PsicologoServicioDTO, PsicologoServicio>()
            //    .ForMember(dest => dest.IdPsicologo, opt => opt.MapFrom(src => src.IdPsicologo))
            //    .ForMember(dest => dest.IdServicio, opt => opt.MapFrom(src => src.IdServicio))
            //    .ForMember(dest => dest.Valor, opt => opt.MapFrom(src => src.Valor));
        }
    }
}
