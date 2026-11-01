using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaRescateAnimalUI.Models
{
    internal class Usuario
    {
        // El número único para identificar a cada usuario en el sistema (como su número de empleado)
        public int IdUsuario { get; set; }

        // El nombre con el que la persona va a iniciar sesión
        public string NombreUsuario { get; set; }

        // La clave para entrar (por ahora en texto, pero luego podríamos protegerla)
        public string Contrasena { get; set; }

        // Aquí definimos si es "Administrador" o "Voluntario" para saber a qué pantallas dejarlo entrar
        public string Rol { get; set; }
    }
}
