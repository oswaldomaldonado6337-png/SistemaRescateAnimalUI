using MySqlConnector;
using SistemaRescateAnimal.Models;
using SistemaRescateAnimalUI.Data; 
using SistemaRescateAnimalUI.Models;
using System;
using System.Data;

namespace SistemaRescateAnimal.Datos
{
    public class AdoptanteDAO
    {
        private readonly ConexionMariaDB _conexionMariaDB;

        public AdoptanteDAO()
        {
            _conexionMariaDB = new ConexionMariaDB();
        }

        public bool RegistrarAdoptante(Adoptante adoptante)
        {
            bool exito = false;
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();

            // Consulta los 9 campos de la tabla que tenemos en mariadb
            string query = @"INSERT INTO adoptantes 
                             (Nombre, ApellidoPaterno, ApellidoMaterno, Telefono, Correo, Calle, Numero, Colonia, Ciudad) 
                             VALUES 
                             (@nombre, @apellidoP, @apellidoM, @telefono, @correo, @calle, @numero, @colonia, @ciudad)";

            using (MySqlCommand comando = new MySqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@nombre", adoptante.Nombre);
                comando.Parameters.AddWithValue("@apellidoP", adoptante.ApellidoPaterno);
                // Si el apellido materno viene vacío, mandamos un NULL a la db
                comando.Parameters.AddWithValue("@apellidoM", string.IsNullOrWhiteSpace(adoptante.ApellidoMaterno) ? (object)DBNull.Value : adoptante.ApellidoMaterno);
                comando.Parameters.AddWithValue("@telefono", adoptante.Telefono);
                // Si el correo viene vacío, mandamos un NULL a la db
                comando.Parameters.AddWithValue("@correo", string.IsNullOrWhiteSpace(adoptante.Correo) ? (object)DBNull.Value : adoptante.Correo);
                comando.Parameters.AddWithValue("@calle", adoptante.Calle);
                comando.Parameters.AddWithValue("@numero", adoptante.Numero);
                comando.Parameters.AddWithValue("@colonia", adoptante.Colonia);
                comando.Parameters.AddWithValue("@ciudad", adoptante.Ciudad);

                try
                {
                    int filas = comando.ExecuteNonQuery();
                    exito = filas > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al registrar adoptante: " + ex.Message);
                }
            }
            return exito;
        }

        public DataTable ObtenerTodos()
        {
            DataTable dt = new DataTable();
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();

            string query = @"SELECT 
                                IdAdoptante AS 'ID', 
                                Nombre, 
                                ApellidoPaterno AS 'Apellido Pat.', 
                                ApellidoMaterno AS 'Apellido Mat.', 
                                Telefono, 
                                Correo, 
                                Calle, 
                                Numero, 
                                Colonia, 
                                Ciudad 
                             FROM adoptantes";

            using (MySqlCommand comando = new MySqlCommand(query, conexion))
            {
                try
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener adoptantes: " + ex.Message);
                }
            }
            return dt;
        }
    }
}