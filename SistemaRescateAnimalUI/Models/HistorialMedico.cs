using System;

namespace SistemaRescateAnimal.Models
{
    public class HistorialMedico
    {
        public int IdConsulta { get; set; }
        // Se usa string porque en Maria db el IdAnimal es varchar(50)
        //tengo poco tiempo ahora mismo, si ves esto y tienes tiempo trata de  corregir este detalle
        public string IdAnimal { get; set; }
        public int IdUsuarioVeterinario { get; set; }
        public DateTime FechaConsulta { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamiento { get; set; }
    }
}