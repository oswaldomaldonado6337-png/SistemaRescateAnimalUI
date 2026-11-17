using System;

namespace SistemaRescateAnimal.Models
{
    public class Adopcion
    {
        public int IdAdopcion { get; set; }
        public string IdAnimal { get; set; }
        public int IdAdoptante { get; set; }
        public DateTime FechaAdopcion { get; set; }
        public string Observaciones { get; set; }
    }
}