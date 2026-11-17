using MySqlConnector;
using SistemaRescateAnimal.Models;
using SistemaRescateAnimalUI.Data;
using System;
using System.Data;

namespace SistemaRescateAnimal.Datos
{
    public class HistorialMedicoDAO
    {
        private readonly ConexionMariaDB _conexionMariaDB;

        public HistorialMedicoDAO()
        {
            _conexionMariaDB = new ConexionMariaDB();
        }

        // Este método llena el ComboBox cmbAnimal
        public DataTable ObtenerAnimalesParaCombo()
        {
            DataTable dt = new DataTable();

            // CORRECTO: Pedimos la conexión sin 'using' para no destruirla
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();

            string query = "SELECT IdAnimal, Nombre FROM animales";
            using (MySqlCommand cmd = new MySqlCommand(query, conexion))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }

            return dt;
        }

        /*
        -  EQUIPO: 5
        -  INTEGRANTES:
        -  FLORES MONTAÑO, Roberto Carlos
        -  GONZALEZ ALVARADO, Alexa Michelle
        -  MALDONADO LLAMAS, Oswaldo Daniel
        -  DESCRIPCIÓN: Obtiene el historial médico resolviendo las llaves foráneas 
        -  mediante INNER JOIN para cumplir con la rúbrica de NO mostrar IDs puros.
         */
        public DataTable ObtenerHistorialConDetalles()
        {
            DataTable dt = new DataTable();

            // corrige el error  anterior de cuando usabamos using
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();

            string query = @"
                SELECT 
                    hm.IdConsulta AS 'Folio',
                    anim.Nombre AS 'Paciente (Animal)',
                    CONCAT(u.Nombre, ' ', u.ApellidoPaterno) AS 'Atendió (Veterinario)',
                    hm.FechaConsulta AS 'Fecha de Atención',
                    hm.Diagnostico AS 'Enfermedad / Diagnóstico',
                    hm.Tratamiento AS 'Tratamiento y Cuidados'
                FROM historialmedico hm
                INNER JOIN animales anim ON hm.IdAnimal = anim.IdAnimal
                INNER JOIN usuarios u ON hm.IdUsuarioVeterinario = u.IdUsuario;";

            using (MySqlCommand cmd = new MySqlCommand(query, conexion))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }

            return dt;
        }

        public bool RegistrarConsulta(HistorialMedico historial)
        {
            bool exito = false;

            // corrige el error  anterior de cuando usabamos using
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();

            string query = @"INSERT INTO historialmedico 
                             (IdAnimal, IdUsuarioVeterinario, FechaConsulta, Diagnostico, Tratamiento) 
                             VALUES 
                             (@idAnimal, @idVet, @fecha, @diagnostico, @tratamiento)";

            using (MySqlCommand cmd = new MySqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@idAnimal", historial.IdAnimal);
                cmd.Parameters.AddWithValue("@idVet", historial.IdUsuarioVeterinario);
                cmd.Parameters.AddWithValue("@fecha", historial.FechaConsulta);
                cmd.Parameters.AddWithValue("@diagnostico", historial.Diagnostico);
                cmd.Parameters.AddWithValue("@tratamiento", historial.Tratamiento);

                try
                {
                    int filas = cmd.ExecuteNonQuery();
                    exito = filas > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al registrar consulta: " + ex.Message);
                }
            }

            return exito;
        }
    }
}