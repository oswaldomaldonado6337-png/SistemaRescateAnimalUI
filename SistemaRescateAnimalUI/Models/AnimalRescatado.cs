using System;

// AUTOR: MALDONADO LLAMAS, Oswaldo Daniel
// PROYECTO: SistemaRescateAnimal

namespace SistemaRescateAnimal.Models
{
    public class AnimalRescatado
    {
        
        private int _id;
        private string _nombre;
        private string _especie;
        private double _peso;

      
        public AnimalRescatado()
        {
            Id = 1;
            Nombre = "Sin nombre";
            Especie = "Mestizo";
            Peso = 1.0;
        }

        public AnimalRescatado(int id, string nombre, string especie, double peso)
        {
            Id = id;
            Nombre = nombre;
            Especie = especie;
            Peso = peso;
        }


        public int Id
        {
            get { return _id; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("El ID del animal debe ser mayor a cero.");
                }
                _id = value;
            }
        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre del animal no puede estar vacío.");
                }
                _nombre = value.Trim();
            }
        }

        public string Especie
        {
            get { return _especie; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("La especie del animal no puede estar vacía.");
                }
                _especie = value.Trim();
            }
        }

        public double Peso
        {
            get { return _peso; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("El peso del animal debe ser mayor a 0 kg.");
                }
                _peso = value;
            }
        }

        public double CalcularRacionAlimento()
        {
            return (_peso * 1000) * 0.03;
        }

        public double CalcularRacionAlimento(double porcentajePorPeso)
        {
            if (porcentajePorPeso <= 0 || porcentajePorPeso > 10)
            {
                throw new ArgumentException("El porcentaje de ración debe estar entre 0.1% y 10%.");
            }
            return (_peso * 1000) * (porcentajePorPeso / 100.0);
        }


        public override string ToString()
        {
            return "[Animal ID: " + Id + "] Nombre: " + Nombre + " | Especie: " + Especie + " | Peso: " + Peso + " kg";
        }
    }
}