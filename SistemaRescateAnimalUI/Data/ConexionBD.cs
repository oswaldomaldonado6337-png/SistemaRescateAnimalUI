using System;
using MySqlConnector;
namespace SistemaRescateAnimalUI.Datos
{
    public class ConexionBD
    {
        private readonly string cadenaConexion = "Server=127.0.0.1;Port=3307;Database=SistemaRescateAnimalDB;Uid=app_rescate;Pwd=app123;";

        public MySqlConnection ObtenerConexion()
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(cadenaConexion);
                return conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al intentar conectar con la base de datos: " + ex.Message);
            }
        }
    }
}