//INTEGRANTES: 
//Alexa Michelle Gonzalez Alvarado,Maldonado Llamas Oswaldo Daniel, Flores Carlos Roberto
//VACUNAS

using System;


namespace SistemaRescateAnimalUI.Models
{
   public class Vacuna
    {
        public string Id { get; set; }
        public string Nombre { get; set; } 
        public DateTime FechaAplicacion { get; set; }
        public bool EsActiva { get; set; }
    }
}
