using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Flotas.Models
{
    public class AlertaMantenimiento
    {
        public int Id { get; set; }
        public int CamionId { get; set; }
        public string Mensaje { get; set; }
        public DateTime FechaGenerada { get; set; }
    }
}
