using System;
using System.Security.Cryptography;
using System.Text;

namespace SistemaRescateAnimalUI.Utilidades
{
    public static class Seguridad
    {
        /// <summary>
        /// Convierte texto plano en un Hash SHA256 irreversible.
        /// </summary>
        public static string GenerarSHA256(string textoPlano)
        {
            if (string.IsNullOrEmpty(textoPlano)) return string.Empty;

            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convierte la cadena de texto a un arreglo de bytes
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(textoPlano));

                // Convierte el arreglo de bytes a una cadena de texto hexadecimal
                StringBuilder constructorTexto = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    constructorTexto.Append(bytes[i].ToString("x2"));
                }

                return constructorTexto.ToString();
            }
        }
    }
}