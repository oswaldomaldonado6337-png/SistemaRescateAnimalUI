using MySqlConnector;
using SistemaRescateAnimal.Models;
using SistemaRescateAnimalUI.Data;
using System;
using System.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

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
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();

            string query = @"SELECT IdAnimal, Nombre 
                     FROM animales 
                     WHERE EsActivo = 1 
                       AND Estado = 'Disponible' 
                       AND CondicionHallazgo = 'Estable'
                     ORDER BY Nombre ASC;";

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

            string queryAdopcion = @"INSERT INTO adopciones (IdAnimal, IdAdoptante, FechaAdopcion, Monto, FormaPago, Estado, Observaciones) 
                             VALUES (@idAnimal, @idAdoptante, @fecha, @monto, @formaPago, @estado, @observaciones)";

            string queryActualizarAnimal = @"UPDATE animales SET Estado = 'Adoptado' WHERE IdAnimal = @idAnimal";

            using (MySqlTransaction transaccion = conexion.BeginTransaction())
            {
                try
                {
                    long idGenerado = 0;
                    using (MySqlCommand cmdAdopcion = new MySqlCommand(queryAdopcion, conexion, transaccion))
                    {
                        cmdAdopcion.Parameters.AddWithValue("@idAnimal", adopcion.IdAnimal);
                        cmdAdopcion.Parameters.AddWithValue("@idAdoptante", adopcion.IdAdoptante);
                        cmdAdopcion.Parameters.AddWithValue("@fecha", adopcion.FechaAdopcion);
                        cmdAdopcion.Parameters.AddWithValue("@monto", adopcion.Monto);
                        cmdAdopcion.Parameters.AddWithValue("@formaPago", string.IsNullOrWhiteSpace(adopcion.FormaPago) ? "Efectivo" : adopcion.FormaPago);
                        cmdAdopcion.Parameters.AddWithValue("@estado", string.IsNullOrWhiteSpace(adopcion.Estado) ? "Vigente" : adopcion.Estado);
                        cmdAdopcion.Parameters.AddWithValue("@observaciones", string.IsNullOrWhiteSpace(adopcion.Observaciones) ? (object)DBNull.Value : adopcion.Observaciones);

                        cmdAdopcion.ExecuteNonQuery();
                        idGenerado = cmdAdopcion.LastInsertedId;
                    }

                    // Generación y guardado del Folio Único
                    string folioUnico = $"ADO-{DateTime.Now:yyyyMMdd}-{idGenerado:D4}";
                    adopcion.Folio = folioUnico;

                    string queryFolio = "UPDATE adopciones SET Folio = @folio WHERE IdAdopcion = @id";
                    using (MySqlCommand cmdFolio = new MySqlCommand(queryFolio, conexion, transaccion))
                    {
                        cmdFolio.Parameters.AddWithValue("@folio", folioUnico);
                        cmdFolio.Parameters.AddWithValue("@id", idGenerado);
                        cmdFolio.ExecuteNonQuery();
                    }

                    using (MySqlCommand cmdActualizar = new MySqlCommand(queryActualizarAnimal, conexion, transaccion))
                    {
                        cmdActualizar.Parameters.AddWithValue("@idAnimal", adopcion.IdAnimal);
                        cmdActualizar.ExecuteNonQuery();
                    }

                    transaccion.Commit();
                    exito = true;
                }
                catch (Exception ex)
                {
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
            { "IdAnimal", adopcion.IdAnimal },
            { "IdAdoptante", adopcion.IdAdoptante },
            { "FechaAdopcion", adopcion.FechaAdopcion },
            { "Monto", (double)adopcion.Monto },
            { "Estado", "Vigente" },
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
        public List<AdopcionDetalle> ObtenerListadoAdopciones()
        {
            List<AdopcionDetalle> lista = new List<AdopcionDetalle>();
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();

            string query = @"
                SELECT 
                    COALESCE(adop.Folio, CONCAT('ADO-', LPAD(adop.IdAdopcion, 4, '0'))) AS Folio,
                    adop.IdAdopcion,
                    adop.IdAnimal,
                    anim.Nombre AS Animal,
                    anim.Especie,
                    TRIM(CONCAT(adte.Nombre, ' ', adte.ApellidoPaterno, ' ', COALESCE(adte.ApellidoMaterno, ''))) AS Adoptante,
                    adop.FechaAdopcion,
                    COALESCE(adop.Monto, 0.00) AS Monto,
                    COALESCE(adop.FormaPago, 'N/A') AS FormaPago,
                    COALESCE(adop.Estado, 'Vigente') AS Estado,
                    COALESCE(adop.Observaciones, '') AS Observaciones
                FROM adopciones adop
                INNER JOIN animales anim ON adop.IdAnimal = anim.IdAnimal
                INNER JOIN adoptantes adte ON adop.IdAdoptante = adte.IdAdoptante
                ORDER BY adop.FechaAdopcion DESC, adop.IdAdopcion DESC;";

            using (MySqlCommand cmd = new MySqlCommand(query, conexion))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lista.Add(new AdopcionDetalle
                    {
                        Folio = reader["Folio"].ToString(),
                        IdAdopcion = Convert.ToInt32(reader["IdAdopcion"]),
                        IdAnimal = reader["IdAnimal"].ToString(),
                        Animal = reader["Animal"].ToString(),
                        Especie = reader["Especie"].ToString(),
                        Adoptante = reader["Adoptante"].ToString(),
                        FechaAdopcion = Convert.ToDateTime(reader["FechaAdopcion"]),
                        Monto = Convert.ToDecimal(reader["Monto"]),
                        FormaPago = reader["FormaPago"].ToString(),
                        Estado = reader["Estado"].ToString(),
                        Observaciones = reader["Observaciones"].ToString()
                    });
                }
            }

            return lista;
        }

        public bool CambiarEstadoAdopcion(int idAdopcion, string idAnimal, string nuevoEstado)
        {
            bool exito = false;
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();

            using (MySqlTransaction transaccion = conexion.BeginTransaction())
            {
                try
                {
                    string queryAdopcion = "UPDATE adopciones SET Estado = @estado WHERE IdAdopcion = @idAdopcion";
                    using (MySqlCommand cmdAdopcion = new MySqlCommand(queryAdopcion, conexion, transaccion))
                    {
                        cmdAdopcion.Parameters.AddWithValue("@estado", nuevoEstado);
                        cmdAdopcion.Parameters.AddWithValue("@idAdopcion", idAdopcion);
                        cmdAdopcion.ExecuteNonQuery();
                    }

                    // Si se cancela la adopción, se regresa al animal a Disponible (y EsActivo = 1)
                    if (nuevoEstado.Equals("Cancelado", StringComparison.OrdinalIgnoreCase))
                    {
                        string queryAnimal = "UPDATE animales SET Estado = 'Disponible', EsActivo = 1 WHERE IdAnimal = @idAnimal";
                        using (MySqlCommand cmdAnimal = new MySqlCommand(queryAnimal, conexion, transaccion))
                        {
                            cmdAnimal.Parameters.AddWithValue("@idAnimal", idAnimal);
                            cmdAnimal.ExecuteNonQuery();
                        }
                    }

                    transaccion.Commit();
                    exito = true;
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                    throw new Exception("Error al actualizar el estado de la adopción: " + ex.Message);
                }
            }

            return exito;
        }

    }
}