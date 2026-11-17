using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaRescateAnimalUI.Models
{
    public class Adoptante
    {
        public int IdAdoptante { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Calle { get; set; }
        public string Numero { get; set; }
        public string Colonia { get; set; }
        public string Ciudad { get; set; }
    }
}
