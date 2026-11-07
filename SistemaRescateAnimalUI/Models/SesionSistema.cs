using System;

namespace SistemaRescateAnimalUI.Models
{
    public static class SesionSistema
    {
        // Uso estas variables estáticas para saber quién está logueado desde cualquier ventana, 
        // así me evito estar pasando datos por los constructores de los formularios.
        public static string UsuarioActivo { get; set; }
        public static string RolActivo { get; set; }
        public static DateTime HoraInicioSesion { get; set; }
    }
}