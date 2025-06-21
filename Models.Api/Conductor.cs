using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Flotas.Models
{
    public class Conductor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Licencia { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}