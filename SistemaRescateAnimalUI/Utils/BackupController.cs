/*
- Materia: Programación Orientada a Eventos
- EQUIPO: 4
- INTEGRANTES:
- FLORES MONTAÑO, Roberto Carlos
- GONZALEZ ALVARADO, Alexa Michelle
- MALDONADO LLAMAS, Oswaldo Daniel
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using System.Windows.Forms;
using SistemaRescateAnimal.Models; 

namespace SistemaRescateAnimalUI.Utils
{
    public class BackupController
    {
        // Genera la ruta  bin\Debug\Backups\
        private readonly string rutaRespaldo = Path.Combine(Application.StartupPath, "Backups");

        public BackupController()
        {
            if (!Directory.Exists(rutaRespaldo))
            {
                Directory.CreateDirectory(rutaRespaldo);
            }
        }

        public void ExportarJSON(List<AnimalRescatado> lista, string nombreArchivo = "RespaldoAnimales.json")
        {
            string rutaCompleta = Path.Combine(rutaRespaldo, nombreArchivo);

            // WriteIndented = true asegura que el JSON sea legible (sangrías)
            var opciones = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(lista, opciones);

            File.WriteAllText(rutaCompleta, jsonString);
            MessageBox.Show($"Respaldo JSON creado en:\n{rutaCompleta}", "Exportación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ExportarXML(List<AnimalRescatado> lista, string nombreArchivo = "RespaldoAnimales.xml")
        {
            string rutaCompleta = Path.Combine(rutaRespaldo, nombreArchivo);
            XmlSerializer serializer = new XmlSerializer(typeof(List<AnimalRescatado>));

            using (StreamWriter writer = new StreamWriter(rutaCompleta))
            {
                serializer.Serialize(writer, lista);
            }
            MessageBox.Show($"Respaldo XML creado en:\n{rutaCompleta}", "Exportación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public List<AnimalRescatado> ImportarJSON(string rutaArchivo)
        {
            try
            {
                string jsonString = File.ReadAllText(rutaArchivo);
                return JsonSerializer.Deserialize<List<AnimalRescatado>>(jsonString);
            }
            catch (JsonException ex)
            {
                MessageBox.Show("El archivo JSON está corrupto o no cumple el esquema esperado.\n\n" + ex.Message, "Error de Formato JSON", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<AnimalRescatado> ImportarXML(string rutaArchivo)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<AnimalRescatado>));
                using (StreamReader reader = new StreamReader(rutaArchivo))
                {
                    return (List<AnimalRescatado>)serializer.Deserialize(reader);
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("El archivo XML está dañado o tiene una estructura inválida.\n\n" + ex.InnerException?.Message, "Error de Formato XML", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}