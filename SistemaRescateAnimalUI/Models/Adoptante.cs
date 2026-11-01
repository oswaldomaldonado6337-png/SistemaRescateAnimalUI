using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaRescateAnimalUI.Models
{
    internal class Adoptante
    {
        // Su número de folio interno en nuestro refugio
        public int IdAdoptante { get; set; }

        // El nombre de la persona que se va a llevar al animalito a su casa
        public string NombreCompleto { get; set; }

        // Su número de celular o casa para llamarle y ver cómo va la adopción
        public string Telefono { get; set; }

        // Dónde vive actualmente, por si el refugio necesita hacerle una visita de seguimiento
        public string DireccionFisica { get; set; }
    }
}
