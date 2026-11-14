/*
- Materia: Programación Orientada a Eventos
- EQUIPO: 4
- INTEGRANTES:
- FLORES MONTAÑO, Roberto Carlos
- GONZALEZ ALVARADO, Alexa Michelle
- MALDONADO LLAMAS, Oswaldo Daniel
 */
using System;
using System.Data;
using MySqlConnector; 

namespace SistemaRescateAnimalUI.Data
{
    public class ConexionMariaDB
    {
        private readonly string cadenaConexion = "Server=127.0.0.1;Port=3307;Database=SistemaRescateAnimalDB;Uid=app_rescate;Pwd=app123;";

        private static MySqlConnection _conexionActiva;

        public MySqlConnection ObtenerConexion()
        {
            try
            {
                if (_conexionActiva == null)
                {
                    _conexionActiva = new MySqlConnection(cadenaConexion);
                }

                if (_conexionActiva.State == ConnectionState.Closed)
                {
                    _conexionActiva.Open();
                }

                return _conexionActiva;
            }

            catch (MySqlException ex)
            {
                throw new Exception("Falla de red o credenciales en MariaDB: " + ex.Message);
            }
        }
    }
}