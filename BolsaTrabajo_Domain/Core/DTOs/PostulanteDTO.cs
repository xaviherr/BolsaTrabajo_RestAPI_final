using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolsaTrabajo_Domain.Core.DTOs
{
    public class PostulanteDTO
    {
        public int Dni { get; set; }
        public int? IdLocalidad { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime? Fecha { get; set; }

    }
}
