using System;

namespace SistemaRescateAnimal.Models
{
    public class AdopcionDetalle
    {
        public string Folio { get; set; }
        public int IdAdopcion { get; set; }
        public string IdAnimal { get; set; }
        public string Animal { get; set; }
        public string Especie { get; set; }
        public string Adoptante { get; set; }
        public DateTime FechaAdopcion { get; set; }
        public decimal Monto { get; set; }
        public string FormaPago { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
    }
}