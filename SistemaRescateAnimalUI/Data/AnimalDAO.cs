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
    }
}