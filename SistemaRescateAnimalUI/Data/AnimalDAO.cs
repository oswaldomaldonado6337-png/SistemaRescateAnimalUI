using MongoDB.Bson;
using MongoDB.Driver;
using MySqlConnector;
using SistemaRescateAnimal.Models;
using SistemaRescateAnimalUI.Data;
using System;
using System.Collections.Generic;

namespace SistemaRescateAnimal.Datos
{
    public class AnimalDAO
    {
        // Uso mi nueva clase para centralizar la conexión
        private readonly ConexionMariaDB _conexionMariaDB;

        public AnimalDAO()
        {
            _conexionMariaDB = new ConexionMariaDB();
        }

        public bool RegistrarAnimal(AnimalRescatado animal)
        {
            bool exito = false;


            // Pido la conexión sin el 'using' para no destruir mi Singleton
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();

            string query = @"INSERT INTO animales 
                            (IdAnimal, Nombre, Especie, Peso, FechaNacimientoEstimada, UbicacionFisica, 
                             FechaRescate, LugarHallazgo, CondicionHallazgo, FechaRegistro, EsActivo, RutaImagen) 
                             VALUES 
                            (@id, @nombre, @especie, @peso, @fechaNac, @ubicacion, 
                             @fechaRescate, @lugar, @condicion, @fechaReg, @activo, @ruta)";

            // El 'using' se queda solo en el comando para limpiar la consulta
            using (MySqlCommand comando = new MySqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@id", animal.Id);
                comando.Parameters.AddWithValue("@nombre", animal.Nombre);
                comando.Parameters.AddWithValue("@especie", animal.Especie);
                comando.Parameters.AddWithValue("@peso", animal.Peso);
                comando.Parameters.AddWithValue("@fechaNac", animal.FechaNacimientoEstimada);
                comando.Parameters.AddWithValue("@ubicacion", animal.UbicacionFisica);
                comando.Parameters.AddWithValue("@fechaRescate", animal.FechaRescate);
                comando.Parameters.AddWithValue("@lugar", animal.LugarHallazgo);
                comando.Parameters.AddWithValue("@condicion", animal.CondicionHallazgo);
                comando.Parameters.AddWithValue("@fechaReg", animal.FechaRegistro);
                comando.Parameters.AddWithValue("@activo", animal.EsActivo);
                comando.Parameters.AddWithValue("@ruta", animal.RutaImagen);

                try
                {
                    int filas = comando.ExecuteNonQuery();
                    exito = filas > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error DAO Inserción: " + ex.Message);
                }
            }

            return exito;
        }
        public AnimalRescatado ObtenerPorId(string id)
        {
            AnimalRescatado animal = null;
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();

            string query = "SELECT * FROM animales WHERE IdAnimal = @id";

            using (MySqlCommand comando = new MySqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@id", id);
                try
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            animal = new AnimalRescatado();
                            animal.Id = reader["IdAnimal"].ToString();
                            animal.Nombre = reader["Nombre"].ToString();
                            animal.Especie = reader["Especie"].ToString();
                            animal.Peso = Convert.ToDouble(reader["Peso"]);
                            animal.FechaNacimientoEstimada = Convert.ToDateTime(reader["FechaNacimientoEstimada"]);
                            animal.UbicacionFisica = reader["UbicacionFisica"].ToString();
                            animal.FechaRescate = Convert.ToDateTime(reader["FechaRescate"]);
                            animal.LugarHallazgo = reader["LugarHallazgo"].ToString();
                            animal.CondicionHallazgo = reader["CondicionHallazgo"].ToString();
                            animal.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                            animal.EsActivo = Convert.ToBoolean(reader["EsActivo"]);
                            animal.RutaImagen = reader["RutaImagen"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error DAO al buscar: " + ex.Message);
                }
            }
            return animal;
        }

        public List<AnimalRescatado> ObtenerTodos()
        {
            List<AnimalRescatado> lista = new List<AnimalRescatado>();

            // Traigo la conexión (reutilizando el hilo ya abierto)
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();
            string query = "SELECT * FROM animales WHERE EsActivo = 1";

            using (MySqlCommand comando = new MySqlCommand(query, conexion))
            {
                try
                {
                    using (MySqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AnimalRescatado animal = new AnimalRescatado();
                            animal.Id = reader["IdAnimal"].ToString();
                            animal.Nombre = reader["Nombre"].ToString();
                            animal.Especie = reader["Especie"].ToString();
                            animal.Peso = Convert.ToDouble(reader["Peso"]);
                            animal.FechaNacimientoEstimada = Convert.ToDateTime(reader["FechaNacimientoEstimada"]);
                            animal.UbicacionFisica = reader["UbicacionFisica"].ToString();
                            animal.FechaRescate = Convert.ToDateTime(reader["FechaRescate"]);
                            animal.LugarHallazgo = reader["LugarHallazgo"].ToString();
                            animal.CondicionHallazgo = reader["CondicionHallazgo"].ToString();
                            animal.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                            animal.EsActivo = Convert.ToBoolean(reader["EsActivo"]);
                            animal.RutaImagen = reader["RutaImagen"].ToString();

                            lista.Add(animal);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error DAO Lectura: " + ex.Message);
                }
            }

            return lista;
        }

        public System.Data.DataTable ObtenerAdopcionesConDetalles()
        {
            System.Data.DataTable dtAdopciones = new System.Data.DataTable();

            // Obtener la conexión usando tu Singleton
            MySqlConnector.MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();

            string query = @"
                SELECT 
                adop.IdAdopcion AS 'Folio Adopción',
                anim.Nombre AS 'Nombre del Animal',
                anim.Especie AS 'Especie',
                CONCAT(adte.Nombre, ' ', adte.ApellidoPaterno) AS 'Adoptante',
                adop.FechaAdopcion AS 'Fecha de Adopción',
                adop.Observaciones AS 'Observaciones'
                FROM adopciones adop
                INNER JOIN animales anim ON adop.IdAnimal = anim.IdAnimal
                INNER JOIN adoptantes adte ON adop.IdAdoptante = adte.IdAdoptante;";

            using (MySqlConnector.MySqlCommand cmd = new MySqlConnector.MySqlCommand(query, conexion))
            {
                try
                {
                    using (MySqlConnector.MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        dtAdopciones.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al consultar el INNER JOIN: " + ex.Message);
                }
            }

            return dtAdopciones;
        }

        public System.Data.DataTable ObtenerAdopcionesConLookupMongo()
        {
            System.Data.DataTable dtAdopciones = new System.Data.DataTable();
            dtAdopciones.Columns.Add("Folio Adopción");
            dtAdopciones.Columns.Add("Nombre del Animal");
            dtAdopciones.Columns.Add("Fecha de Adopción");
            dtAdopciones.Columns.Add("Observaciones");

            try
            {
                // 1. Usamos TU clase de conexión exacta
                ConexionMongoDB conexionMongo = new ConexionMongoDB();
                var database = conexionMongo.ObtenerBaseDatos();

                // Conectamos a la colección (Asegúrate de que en Atlas se llame "adopciones" en minúscula)
                var adopcionesCollection = database.GetCollection<BsonDocument>("adopciones");

                // 2. El Pipeline de Agregación con $lookup
                var pipeline = new BsonDocument[]
                {
            new BsonDocument("$lookup", new BsonDocument
            {
                { "from", "animales" },
                { "localField", "IdAnimal" },     // Llave en adopciones
                { "foreignField", "IdAnimal" },   // Llave en animales
                { "as", "AnimalDetalles" }
            }),
            new BsonDocument("$unwind", "$AnimalDetalles"),
            new BsonDocument("$project", new BsonDocument
            {
                { "_id", 0 }, // Ocultamos el Object ID alfanumérico feo de Mongo
                { "IdAdopcion", 1 },
                { "NombreAnimal", "$AnimalDetalles.Nombre" },
                { "FechaAdopcion", 1 },
                { "Observaciones", 1 }
            })
                };

                // 3. Ejecutamos la consulta en Atlas
                var resultados = adopcionesCollection.Aggregate<BsonDocument>(pipeline).ToList();

                // 4. Llenamos el DataTable
                foreach (var doc in resultados)
                {
                    dtAdopciones.Rows.Add(
                        doc.GetValue("IdAdopcion", "N/A").ToString(),
                        doc.GetValue("NombreAnimal", "N/A").ToString(),
                        doc.GetValue("FechaAdopcion", "N/A").ToString(),
                        doc.GetValue("Observaciones", "N/A").ToString()
                    );
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Error en $lookup de MongoDB: " + ex.Message);
            }

            return dtAdopciones;
        }
    }
}