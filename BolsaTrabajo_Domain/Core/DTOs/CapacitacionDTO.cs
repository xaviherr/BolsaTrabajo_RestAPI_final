using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaTrabajo_Domain.Core.DTOs
{
   public class CapacitacionDTO
    {
       // public int IdCapacitacion { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
    }
}
