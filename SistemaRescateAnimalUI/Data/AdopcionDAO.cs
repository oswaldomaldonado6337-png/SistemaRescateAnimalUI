using MySqlConnector;
using SistemaRescateAnimal.Models;
using SistemaRescateAnimalUI.Data;
using System;
using System.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SistemaRescateAnimal.Datos
{
    public class AdopcionDAO
    {
        private readonly ConexionMariaDB _conexionMariaDB;

        public AdopcionDAO()
        {
            _conexionMariaDB = new ConexionMariaDB();
        }

        public DataTable ObtenerAnimalesParaCombo()
        {
            DataTable dt = new DataTable();
            // corrige el error  anterior de cuando usabamos using
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();

            // usamos el filtro de solo animales disponibles
            string query = "SELECT IdAnimal, Nombre FROM animales WHERE EsActivo = 1";
            using (MySqlCommand cmd = new MySqlCommand(query, conexion))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }

            return dt;
        }

        public DataTable ObtenerAdoptantesParaCombo()
        {
            DataTable dt = new DataTable();
            // corrige el error  anterior de cuando usabamos using
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();

            string query = "SELECT IdAdoptante, CONCAT(Nombre, ' ', ApellidoPaterno) AS NombreCompleto FROM adoptantes";
            using (MySqlCommand cmd = new MySqlCommand(query, conexion))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }

            return dt;
        }

        public bool RegistrarAdopcion(Adopcion adopcion)
        {
            bool exito = false;
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();

            //  Queery guardamos la adopción
            string queryAdopcion = @"INSERT INTO adopciones (IdAnimal, IdAdoptante, FechaAdopcion, Observaciones) 
                             VALUES (@idAnimal, @idAdoptante, @fecha, @observaciones)";

            // Query actualizar estado A no disponible
            string queryActualizarAnimal = @"UPDATE animales SET EsActivo = 0 WHERE IdAnimal = @idAnimal";

            // nos aseguramos de que ambas cosas sucedan al mismo tiempo
            using (MySqlTransaction transaccion = conexion.BeginTransaction())
            {
                try
                {
                    // se ejcuta el insert de animal
                    using (MySqlCommand cmdAdopcion = new MySqlCommand(queryAdopcion, conexion, transaccion))
                    {
                        cmdAdopcion.Parameters.AddWithValue("@idAnimal", adopcion.IdAnimal);
                        cmdAdopcion.Parameters.AddWithValue("@idAdoptante", adopcion.IdAdoptante);
                        cmdAdopcion.Parameters.AddWithValue("@fecha", adopcion.FechaAdopcion);
                        cmdAdopcion.Parameters.AddWithValue("@observaciones", string.IsNullOrWhiteSpace(adopcion.Observaciones) ? (object)DBNull.Value : adopcion.Observaciones);

                        cmdAdopcion.ExecuteNonQuery();
                    }

                    // se actualiza el estado del animal a no disponible
                    using (MySqlCommand cmdActualizar = new MySqlCommand(queryActualizarAnimal, conexion, transaccion))
                    {
                        cmdActualizar.Parameters.AddWithValue("@idAnimal", adopcion.IdAnimal);

                        cmdActualizar.ExecuteNonQuery();
                    }

                    // si llega aqui no hubo erroes y se actualiza la db
                    transaccion.Commit();
                    exito = true;
                }
                catch (Exception ex)
                {
                    // Si por X razon algo explosa no se realiza nada
                    transaccion.Rollback();
                    throw new Exception("Error al registrar adopción y actualizar estado: " + ex.Message);
                }
            }

            return exito;
        }
        public bool RegistrarAdopcionMongo(Adopcion adopcion)
        {
            try
            {
                ConexionMongoDB conexionMongo = new ConexionMongoDB();
                var database = conexionMongo.ObtenerBaseDatos();
                var coleccion = database.GetCollection<BsonDocument>("adopciones");

                var documento = new BsonDocument
        {
            { "IdAdopcion", "ADP-" + DateTime.Now.ToString("yyyyMMddHHmmss") },
            { "IdAnimal", adopcion.IdAnimal },         // Viene de cmbAnimal.SelectedValue
            { "IdAdoptante", adopcion.IdAdoptante },   // Viene de cmbAdoptante.SelectedValue
            { "FechaAdopcion", adopcion.FechaAdopcion },
            { "Observaciones", adopcion.Observaciones ?? "" }
        };

                coleccion.InsertOne(documento);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error DAO MongoDB Inserción Adopción: " + ex.Message);
            }
        }

        public DataTable ObtenerAdopcionesConDetalles()
        {
            DataTable dt = new DataTable();
            // corrige el error  anterior de cuando usabamos using
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();

            string query = @"
                SELECT 
                    adop.IdAdopcion AS 'Folio',
                    anim.Nombre AS 'Mascota Adoptada',
                    CONCAT(adte.Nombre, ' ', adte.ApellidoPaterno) AS 'Adoptante',
                    adop.FechaAdopcion AS 'Fecha',
                    adop.Observaciones AS 'Observaciones'
                FROM adopciones adop
                INNER JOIN animales anim ON adop.IdAnimal = anim.IdAnimal
                INNER JOIN adoptantes adte ON adop.IdAdoptante = adte.IdAdoptante;";

            using (MySqlCommand cmd = new MySqlCommand(query, conexion))
            {
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }

            return dt;
        }
        
    }
}