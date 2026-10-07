//INTEGRANTES: 
//Alexa Michelle Gonzalez Alvarado,Maldonado Llamas Oswaldo Daniel, Flores Carlos Roberto
//HISTORIAL CLINICO

using System;
using System.Collections.Generic;

namespace SistemaRescateAnimalUI.Models
{
    public class HistorialClinico
    {
        private List<Vacuna> _listaVacunas;

        public List<Vacuna> ListaVacunas
        {
            get { return _listaVacunas; } 

        }

        //constructor
        public HistorialClinico()
        {
            _listaVacunas = new List<Vacuna>();
        }

        //funciones agregadas

        public void RegistrarElementos (Vacuna vacuna)
        {
            _listaVacunas.Add(vacuna);
        }

        public int ContarElementos()
        {
            return _listaVacunas.Count;
        }

        public Vacuna  BuscarPorId(string idBuscando)
        {
            foreach (Vacuna v in _listaVacunas)
            {
                if (v.Id== idBuscando)
                {
                    return v; //encontrado
                }
            }
            return null; //no encontrado
        }

        public bool ExisteVacuna (string idBuscando)
        {
            foreach (Vacuna v in _listaVacunas)
            {
                if (v.Id== idBuscando)
                {
                    return true; //encontrado
                }
            }
            return false; //no  encontrado
        }

        public void EliminarPorID (string idEliminar)
        {
            for (int i=0; i< _listaVacunas.Count; i++)
            {
                if (_listaVacunas[i].Id== idEliminar)
                {
                    _listaVacunas.RemoveAt(i);
                    return; 
                }
            }
        }

        public List<Vacuna> FiltrarActivas()
        {
            List<Vacuna> listaFiltrada = new List<Vacuna>(); 
            foreach (Vacuna v in _listaVacunas)
            {
                if (v.EsActiva==true)
                {
                    listaFiltrada.Add(v);
                }
            }
            return listaFiltrada;
        }

        public void VaciarLista()
        {
            _listaVacunas.Clear();
        }
    }

}
