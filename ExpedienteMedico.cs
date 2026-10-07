using System;
// AUTOR: MALDONADO LLAMAS, Oswaldo Daniel
// PROYECTO: SistemaRescateAnimal

namespace SistemaRescateAnimal.Models
{
    public class ExpedienteMedico
    {
        private int _id;
        private string _historial;
        private double _costoTratamiento;
        private bool _estaVacunado;

        public ExpedienteMedico()
        {
            Id = 1;
            Historial = "Sin historial";
            CostoTratamiento = 0;
            EstaVacunado = false;
        }
        public ExpedienteMedico(int id, string historial, double costoTratamiento, bool estaVacunado)
        {
            Id = id; 
            Historial = historial;
            CostoTratamiento = costoTratamiento;
            EstaVacunado = estaVacunado;
        }

        public int Id { get { return _id; }
            set {
                if(value <= 0) {  throw new ArgumentException("El ID debe ser mayor que cero"); }
                _id = value; } }
        public String Historial
        {
            get { return _historial; }
            set
            {
                if (string.IsNullOrWhiteSpace(value)) { throw new ArgumentException("El historial no puede estar vacío"); }
                _historial = value;
            }
        }
        public double CostoTratamiento
        {
            get { return _costoTratamiento; }
            set
            {
                if (value < 0) { throw new ArgumentException("El costo del tratamiento no puede ser negativo"); }
                _costoTratamiento = value;
            }
        }
        public bool EstaVacunado { get { return _estaVacunado; } set { _estaVacunado = value; } }
        public double AplicarDescuento()
        {
            double costoTratamiento = _costoTratamiento * 0.90;
            return costoTratamiento ;
        }
        public double AplicarDescuento(double porcentajeDescuento)
        {
            if (porcentajeDescuento < 0 || porcentajeDescuento > 100)
            {
                throw new ArgumentException("El porcentaje de descuento debe estar entre 0 y 100");
            }
            double costoTratamiento = _costoTratamiento * (1 - porcentajeDescuento / 100);
            return costoTratamiento;
        }
        public override string ToString()
        {
            string estadoVacuna = EstaVacunado ? "Sí" : "No";
            return "[Expediente ID: " + Id + "] Historial: " + Historial + " | Costo: $" + CostoTratamiento + " | Vacunado: " + estadoVacuna;
        }


    }
}
