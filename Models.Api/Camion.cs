using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Flotas.Models
{
    public class Camion
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }
        public string Placa { get; set; }
        public int KilometrajeActual { get; set; }
        public string Estado { get; set; }

        public ICollection<Mantenimiento>? Mantenimientos { get; set; }
    }
}