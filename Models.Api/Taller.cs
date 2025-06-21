using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Flotas.Models
{
    public class Taller
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public int CapacidadMaxima { get; set; }

        public ICollection<Mantenimiento> Mantenimientos { get; set; }
    }
}
