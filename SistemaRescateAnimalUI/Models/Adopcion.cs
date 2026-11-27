using System;

namespace SistemaRescateAnimal.Models
{
    public class Adopcion
    {
        public int IdAdopcion { get; set; }
        public decimal Monto { get; set; }
        public string IdAnimal { get; set; }
        public int IdAdoptante { get; set; }
        public DateTime FechaAdopcion { get; set; }
        public string Observaciones { get; set; }

        public string Folio { get; set; }
        public string FormaPago { get; set; }
        public string Estado { get; set; } = "Vigente";
    }
}