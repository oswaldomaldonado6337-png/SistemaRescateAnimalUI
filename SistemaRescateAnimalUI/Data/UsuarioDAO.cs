using System;
using MySqlConnector;

namespace SistemaRescateAnimalUI.Datos
{
    public class UsuarioDAO
    {
        private readonly ConexionBD _conexionBD;

        public UsuarioDAO()
        {
            _conexionBD = new ConexionBD();
        }

        public bool ValidarCredenciales(string correoUsuario, string passwordHash, out string nombreCompleto, out string rol)
        {
            nombreCompleto = string.Empty;
            rol = string.Empty;
            bool esValido = false;

            using (MySqlConnection conexion = _conexionBD.ObtenerConexion())
            {
                // Ajustado a los nombres exactos de tus columnas
                string query = "SELECT Nombre, ApellidoPaterno, Rol FROM usuarios WHERE Correo = @correo AND ContrasenaHash = @password AND Activo = 1";

                using (MySqlCommand comando = new MySqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@correo", correoUsuario);
                    comando.Parameters.AddWithValue("@password", passwordHash);

                    try
                    {
                        conexion.Open();
                        using (MySqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Concatenamos el nombre y apellido
                                nombreCompleto = reader["Nombre"].ToString() + " " + reader["ApellidoPaterno"].ToString();
                                rol = reader["Rol"].ToString();
                                esValido = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al conectar con la base de datos: " + ex.Message);
                    }
                }
            }
            return esValido;
        }
    }
}