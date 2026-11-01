using System;

namespace SistemaRescateAnimal.Models
{
    public abstract class EntidadBase
    {
        public string Id { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public bool EsActivo { get; set; } = true;
    }
}