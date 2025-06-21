using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Flotas.Models
{
    public class SensorLog
    {
        public int Id { get; set; }
        public int CamionId { get; set; }
        public DateTime Fecha { get; set; }
        public int Kilometraje { get; set; }
        public string EstadoMotor { get; set; }
    }
}
