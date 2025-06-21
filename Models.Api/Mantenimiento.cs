using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Flotas.Models
{
    public class Mantenimiento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }

        [ForeignKey("Taller")]
        public int TallerId { get; set; }
        public Taller Taller { get; set; }

        [ForeignKey("Camion")]
        public int CamionId { get; set; }
        public Camion Camion { get; set; }

        public bool Realizado { get; set; }
    }
}