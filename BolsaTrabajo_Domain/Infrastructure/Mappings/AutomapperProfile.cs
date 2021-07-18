using AutoMapper;
using BolsaTrabajo_Domain.Core.DTOs;
using BolsaTrabajo_Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaTrabajo_Domain.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {

        public AutomapperProfile() {
            CreateMap<PostulanteDTO, Postulante>();
            CreateMap<Postulante, PostulanteDTO>();

            CreateMap<CapacitacionDTO, Capacitacion>();
            CreateMap<Capacitacion, CapacitacionDTO>();


        }
    }
}
