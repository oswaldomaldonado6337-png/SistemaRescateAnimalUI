using System;
using System.Text;
using System.Collections.Generic;

namespace SistemaRescateAnimalUI.Models
{
    public static class UsuariosSistema
    {
        // Quemo los usuarios directamente en memoria para cumplir con la regla de no usar SQL.
        public static List<Usuario> ListaUsuarios = new List<Usuario>
        {
            new Usuario { NombreUsuario = "admin", Contrasena = "Admin123", NombreCompleto = "Juan Administrador", Rol = "Administrador" },
            new Usuario { NombreUsuario = "operador", Contrasena = "Oper123", NombreCompleto = "Pedro Operador", Rol = "Operador" },
            new Usuario { NombreUsuario = "invitado", Contrasena = "Maria Invitada", NombreCompleto = "Maria Invitada", Rol = "Invitado" }
        };
    }
}