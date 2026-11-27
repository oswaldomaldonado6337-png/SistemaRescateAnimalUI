using MongoDB.Bson;
using MongoDB.Driver;
using MySqlConnector;
using SistemaRescateAnimal.Models;
using SistemaRescateAnimalUI.Data;
using System;
using System.Collections.Generic;
using System.Data;

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
                             FechaRescate, LugarHallazgo, CondicionHallazgo, FechaRegistro, EsActivo, RutaImagen, Estado) 
                             VALUES 
                            (@id, @nombre, @especie, @peso, @fechaNac, @ubicacion, 
                             @fechaRescate, @lugar, @condicion, @fechaReg, @activo, @ruta, @estado)";

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
                comando.Parameters.AddWithValue("@ruta", string.IsNullOrWhiteSpace(animal.RutaImagen) ? (object)DBNull.Value : animal.RutaImagen);
                comando.Parameters.AddWithValue("@estado", string.IsNullOrWhiteSpace(animal.Estado) ? "Disponible" : animal.Estado);

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

        public bool ActualizarAnimal(AnimalRescatado animal)
        {
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();

            string query = @"UPDATE animales 
                     SET Nombre = @nombre, 
                         Especie = @especie, 
                         Peso = @peso, 
                         FechaNacimientoEstimada = @fechaNac,
                         UbicacionFisica = @ubicacion,
                         LugarHallazgo = @lugar,
                         CondicionHallazgo = @condicion,
                         FechaRegistro = @fechaReg, 
                         EsActivo = @activo, 
                         RutaImagen = @ruta,
                         Estado = @estado
                     WHERE IdAnimal = @id;";

            using (MySqlCommand comando = new MySqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@id", animal.Id);
                comando.Parameters.AddWithValue("@nombre", animal.Nombre);
                comando.Parameters.AddWithValue("@especie", animal.Especie);
                comando.Parameters.AddWithValue("@peso", animal.Peso);
                comando.Parameters.AddWithValue("@fechaNac", animal.FechaNacimientoEstimada);
                comando.Parameters.AddWithValue("@ubicacion", animal.UbicacionFisica);
                comando.Parameters.AddWithValue("@lugar", animal.LugarHallazgo);
                comando.Parameters.AddWithValue("@condicion", animal.CondicionHallazgo);
                comando.Parameters.AddWithValue("@fechaReg", animal.FechaRegistro);
                comando.Parameters.AddWithValue("@activo", animal.EsActivo);
                comando.Parameters.AddWithValue("@ruta", string.IsNullOrWhiteSpace(animal.RutaImagen) ? (object)DBNull.Value : animal.RutaImagen);
                comando.Parameters.AddWithValue("@estado", string.IsNullOrWhiteSpace(animal.Estado) ? "Disponible" : animal.Estado);

                try
                {
                    return comando.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error DAO Actualización MariaDB: " + ex.Message);
                }
            }
        }

        public AnimalRescatado ObtenerPorId(string id)
        {
            AnimalRescatado animal = null;
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();

            string query = "SELECT * FROM animales WHERE IdAnimal = @id AND EsActivo = 1;";

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
                            animal.Peso = reader["Peso"] != DBNull.Value ? Convert.ToDouble(reader["Peso"]) : 0.0;
                            animal.FechaNacimientoEstimada = reader["FechaNacimientoEstimada"] != DBNull.Value ? Convert.ToDateTime(reader["FechaNacimientoEstimada"]) : DateTime.Today;
                            animal.UbicacionFisica = reader["UbicacionFisica"] != DBNull.Value ? reader["UbicacionFisica"].ToString() : "";
                            animal.FechaRescate = reader["FechaRescate"] != DBNull.Value ? Convert.ToDateTime(reader["FechaRescate"]) : DateTime.Now;
                            animal.LugarHallazgo = reader["LugarHallazgo"] != DBNull.Value ? reader["LugarHallazgo"].ToString() : "";
                            animal.CondicionHallazgo = reader["CondicionHallazgo"] != DBNull.Value ? reader["CondicionHallazgo"].ToString() : "Estable";
                            animal.FechaRegistro = reader["FechaRegistro"] != DBNull.Value ? Convert.ToDateTime(reader["FechaRegistro"]) : DateTime.Now;
                            animal.EsActivo = Convert.ToBoolean(reader["EsActivo"]);
                            animal.RutaImagen = reader["RutaImagen"] != DBNull.Value ? reader["RutaImagen"].ToString() : "";
                            animal.Estado = reader["Estado"] != DBNull.Value ? reader["Estado"].ToString() : "Disponible";
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

        public bool RegistrarAnimalMongo(AnimalRescatado animal)
        {
            try
            {
                ConexionMongoDB conexionMongo = new ConexionMongoDB();
                var database = conexionMongo.ObtenerBaseDatos();
                var coleccion = database.GetCollection<BsonDocument>("animales");

                var documento = new BsonDocument
        {
            { "IdAnimal", animal.Id },
            { "Nombre", animal.Nombre },
            { "Especie", animal.Especie },
            { "Peso", animal.Peso },
            { "FechaNacimientoEstimada", animal.FechaNacimientoEstimada },
            { "UbicacionFisica", animal.UbicacionFisica ?? "Refugio Central" },
            { "FechaRescate", animal.FechaRescate },
            { "LugarHallazgo", animal.LugarHallazgo ?? "No especificado" },
            { "CondicionHallazgo", animal.CondicionHallazgo ?? "Estable" },
            { "FechaRegistro", animal.FechaRegistro },
            { "EsActivo", animal.EsActivo },
            { "RutaImagen", animal.RutaImagen ?? "" }
        };

                coleccion.InsertOne(documento);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error DAO MongoDB Inserción Animal: " + ex.Message);
            }
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
        public string ObtenerSiguienteIdNumerico()
        {
            int siguienteId = 101; // este es el valor inicial si la tabla esta vacia
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();

            // Aqui buscamos el numero mas alto entre los registros Numericos  
            string query = "SELECT MAX(CAST(IdAnimal AS UNSIGNED)) FROM animales WHERE IdAnimal REGEXP '^[0-9]+$'";

            using (MySqlCommand comando = new MySqlCommand(query, conexion))
            {
                try
                {
                    object resultado = comando.ExecuteScalar();
                    if (resultado != null && resultado != DBNull.Value)
                    {
                        siguienteId = Convert.ToInt32(resultado) + 1;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al calcular el siguiente ID: " + ex.Message);
                }
            }

            return siguienteId.ToString();
        }
        

        
        public bool ActualizarAnimalMongo(AnimalRescatado animal)
        {
            try
            {
                ConexionMongoDB conexionMongo = new ConexionMongoDB();
                var database = conexionMongo.ObtenerBaseDatos();
                var coleccion = database.GetCollection<BsonDocument>("animales");

                var filtro = Builders<BsonDocument>.Filter.Eq("IdAnimal", animal.Id);

                var actualizacion = Builders<BsonDocument>.Update
                    .Set("Nombre", animal.Nombre)
                    .Set("Especie", animal.Especie)
                    .Set("Peso", animal.Peso)
                    .Set("FechaRegistro", animal.FechaRegistro)
                    .Set("EsActivo", animal.EsActivo)
                    .Set("RutaImagen", animal.RutaImagen ?? "");

                var resultado = coleccion.UpdateOne(filtro, actualizacion);
                return resultado.MatchedCount > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error DAO Actualización MongoDB: " + ex.Message);
            }
        }


      
        public bool BorradoLogicoMariaDB(string idAnimal)
        {
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();
            string query = "UPDATE animales SET EsActivo = 0 WHERE IdAnimal = @id;";

            using (MySqlCommand comando = new MySqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@id", idAnimal);
                try
                {
                    return comando.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error DAO Borrado Lógico MariaDB: " + ex.Message);
                }
            }
        }

        
        public bool BorradoLogicoMongoDB(string idAnimal)
        {
            try
            {
                ConexionMongoDB conexionMongo = new ConexionMongoDB();
                var database = conexionMongo.ObtenerBaseDatos();
                var coleccion = database.GetCollection<BsonDocument>("animales");

                var filtro = Builders<BsonDocument>.Filter.Eq("IdAnimal", idAnimal);
                var actualizacion = Builders<BsonDocument>.Update.Set("EsActivo", false);

                var resultado = coleccion.UpdateOne(filtro, actualizacion);
                return resultado.MatchedCount > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error DAO Borrado Lógico MongoDB: " + ex.Message);
            }
        }

        
        public bool BorradoFisicoMariaDB(string idAnimal)
        {
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();
            string query = "DELETE FROM animales WHERE IdAnimal = @id;";

            using (MySqlCommand comando = new MySqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@id", idAnimal);
                try
                {
                    return comando.ExecuteNonQuery() > 0;
                }
                catch (MySqlException ex) when (ex.Number == 1451)
                {
                    throw new Exception("No se puede eliminar físicamente este animal porque tiene adopciones o registros vinculados (Integridad Referencial). Use Borrado Lógico en su lugar.");
                }
                catch (Exception ex)
                {
                    throw new Exception("Error DAO Borrado Físico MariaDB: " + ex.Message);
                }
            }
        }

        public bool BorradoFisicoMongoDB(string idAnimal)
        {
            try
            {
                ConexionMongoDB conexionMongo = new ConexionMongoDB();
                var database = conexionMongo.ObtenerBaseDatos();
                var coleccion = database.GetCollection<BsonDocument>("animales");

                var filtro = Builders<BsonDocument>.Filter.Eq("IdAnimal", idAnimal);
                var resultado = coleccion.DeleteOne(filtro);
                return resultado.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Error DAO Borrado Físico MongoDB: " + ex.Message);
            }
        }
        public string ObtenerPrimeraJaulaLibre()
        {
            HashSet<string> ocupadas = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();

            string query = @"SELECT UbicacionFisica FROM animales 
                             WHERE EsActivo = 1 AND Estado != 'Adoptado' AND UbicacionFisica IS NOT NULL;";

            using (MySqlCommand cmd = new MySqlCommand(query, conexion))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ocupadas.Add(reader["UbicacionFisica"].ToString().Trim());
                }
            }

            for (int i = 1; i <= 15; i++)
            {
                string jaula = $"Jaula {i:D2}";
                if (!ocupadas.Contains(jaula)) return jaula;
            }
            return "Sin jaulas libres";
        }

        public DataTable ObtenerAnimalesActivos()
        {
            DataTable dt = new DataTable();
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();

            string query = @"SELECT IdAnimal AS 'ID', Nombre, Especie, Peso, 
                             FechaNacimientoEstimada AS 'Nacimiento Est.', 
                             UbicacionFisica AS 'Jaula', LugarHallazgo AS 'Lugar Hallazgo', 
                             CondicionHallazgo AS 'Condición', Estado, FechaRegistro AS 'Registro'
                             FROM animales WHERE EsActivo = 1 ORDER BY FechaRegistro DESC;";

            using (MySqlCommand cmd = new MySqlCommand(query, conexion))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                dt.Load(reader);
            }
            return dt;
        }
        public bool DarDeAltaMedica(string idAnimal)
        {
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();
            string query = @"UPDATE animales 
                     SET CondicionHallazgo = 'Estable', 
                         Estado = 'Disponible' 
                     WHERE IdAnimal = @id AND EsActivo = 1;";

            using (MySqlCommand cmd = new MySqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@id", idAnimal);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}