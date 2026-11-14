/*
- Materia: Programación Orientada a Eventos
- EQUIPO: 4
- INTEGRANTES:
- FLORES MONTAÑO, Roberto Carlos
- GONZALEZ ALVARADO, Alexa Michelle
- MALDONADO LLAMAS, Oswaldo Daniel
 */
using System;
using MongoDB.Driver;

namespace SistemaRescateAnimalUI.Data
{
    public class ConexionMongoDB
    {
        // Esta es la cadena que saqué de Atlas con mi usuario admin y contraseña
        private readonly string cadenaConexion = "mongodb+srv://admin:Admin123@cluster0.hifhouk.mongodb.net/";
        private readonly string nombreBaseDatos = "SistemaRescateAnimalDB_NoSQL";

        // Dejo el cliente estático para que no se duplique en memoria con cada consulta (requisito de la profe/rúbrica)
        private static MongoClient _clienteActivo;

        public IMongoDatabase ObtenerBaseDatos()
        {
            try
            {
                // Solo creo la conexión si es la primera vez que se llama, si ya existe, reutilizo el hilo
                if (_clienteActivo == null)
                {
                    _clienteActivo = new MongoClient(cadenaConexion);
                }

                return _clienteActivo.GetDatabase(nombreBaseDatos);
            }
            catch (MongoException ex)
            {
                // Aquí capturo específicamente errores de Mongo para aislar fallas de red
                throw new Exception("Falla de red o conexión en MongoDB Atlas: " + ex.Message);
            }
        }
    }
}