/*
 * EQUIPO: 5
 * INTEGRANTES:
 * - FLORES MONTAÑO, Roberto Carlos
 * - GONZALEZ ALVARADO, Alexa Michelle
 * - MALDONADO LLAMAS, Oswaldo Daniel
 * DESCRIPCIÓN: Controlador DAO para consulta dinámica de productos por ID exacto y filtro LIKE.
 */
using MongoDB.Bson;
using MongoDB.Driver;
using MySqlConnector;
using SistemaRescateAnimal.Models;
using System;
using System.Collections.Generic;

namespace SistemaRescateAnimalUI.Data
{
    public class ProductoDAO
    {
        private readonly ConexionMariaDB _conexionMariaDB = new ConexionMariaDB();

        // Buscamos por el Id
        public Producto BuscarPorId(string idProducto)
        {
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();
            string query = "SELECT * FROM productos WHERE IdProducto = @id AND EsActivo = 1;";

            using (MySqlCommand cmd = new MySqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@id", idProducto);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Producto
                        {
                            IdProducto = reader["IdProducto"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Categoria = reader["Categoria"].ToString(),
                            Precio = Convert.ToDecimal(reader["Precio"]),
                            Stock = Convert.ToInt32(reader["Stock"]),
                            EsActivo = Convert.ToBoolean(reader["EsActivo"])
                        };
                    }
                }
            }
            return null;
        }

        // Buscamos por el nombre
        public List<Producto> BuscarPorNombreLike(string filtroNombre)
        {
            List<Producto> lista = new List<Producto>();
            MySqlConnection conexion = _conexionMariaDB.ObtenerConexion();
            string query = "SELECT * FROM productos WHERE Nombre LIKE @filtro AND EsActivo = 1;";

            using (MySqlCommand cmd = new MySqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@filtro", "%" + filtroNombre + "%");
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Producto
                        {
                            IdProducto = reader["IdProducto"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Categoria = reader["Categoria"].ToString(),
                            Precio = Convert.ToDecimal(reader["Precio"]),
                            Stock = Convert.ToInt32(reader["Stock"]),
                            EsActivo = Convert.ToBoolean(reader["EsActivo"])
                        });
                    }
                }
            }
            return lista;
        }

        //buscamos por nombre para mongodb
        public List<Producto> BuscarPorNombreMongo(string filtroNombre)
        {
            List<Producto> lista = new List<Producto>();
            ConexionMongoDB conexionMongo = new ConexionMongoDB();
            var db = conexionMongo.ObtenerBaseDatos();
            var coleccion = db.GetCollection<BsonDocument>("productos");

            var filtro = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Regex("Nombre", new BsonRegularExpression(filtroNombre, "i")),
                Builders<BsonDocument>.Filter.Eq("EsActivo", true)
            );

            var documentos = coleccion.Find(filtro).ToList();
            foreach (var doc in documentos)
            {
                lista.Add(new Producto
                {
                    IdProducto = doc.GetValue("IdProducto", "").AsString,
                    Nombre = doc.GetValue("Nombre", "").AsString,
                    Categoria = doc.GetValue("Categoria", "").AsString,
                    Precio = doc["Precio"].ToDecimal(),
                    Stock = doc["Stock"].ToInt32(),
                    EsActivo = doc.GetValue("EsActivo", true).AsBoolean
                });
            }
            return lista;
        }
    }
}