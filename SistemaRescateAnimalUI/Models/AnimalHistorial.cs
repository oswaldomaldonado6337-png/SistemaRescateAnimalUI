using System;
using System.Collections.Generic;

namespace SistemaRescateAnimalUI
{
    public class AnimalHistorial
    {
        // Encapsulamiento
        private Stack<string> _historialEstados = new Stack<string>();

        public Stack<string> HistorialEstados
        {
            get { return _historialEstados; }
        }

        // Métodos de control
        public void Push(string estado)
        {
            _historialEstados.Push(estado);
        }

        public string Pop()
        {
            if (_historialEstados.Count > 0)
            {
                return _historialEstados.Pop();
            }
            return null;
        }

        public string Peek()
        {
            if (_historialEstados.Count > 0)
            {
                return _historialEstados.Peek();
            }
            return null;
        }

        public int Count()
        {
            return _historialEstados.Count;
        }

        public bool ExisteEstados(string estadoBuscar)
        {
            foreach (string estado in _historialEstados)
            {
                if (estado == estadoBuscar)
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            _historialEstados.Clear();
        }

        public List<string> VolcarArreglo()
        {
            List<string> listaCopia = new List<string>();
            foreach (string estado in _historialEstados)
            {
                listaCopia.Add(estado);
            }
            return listaCopia;
        }
    }
}