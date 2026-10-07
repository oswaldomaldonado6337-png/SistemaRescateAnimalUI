/*
 * ASIGNATURA: Programación Orientada a Eventos
 * EQUIPO: 4
 * INTEGRANTES:
 * - FLORES MONTAÑO, Roberto Carlos
 * - GONZALEZ ALVARADO, Alexa Michelle
 * - MALDONADO LLAMAS, Oswaldo Daniel
 */

using System;
using System.Collections.Generic;

namespace SistemaRescateAnimal.Models
{
    public class AnimalRescatado : EntidadBase, IAlmacenamientoCRUD
    {
        private static List<AnimalRescatado> _listaMemoria = new List<AnimalRescatado>();

        public string Nombre { get; set; } = string.Empty;
        public string Especie { get; set; } = string.Empty;
        public double Peso { get; set; }

        private Stack<string> _historialCambios;

        public Stack<string> HistorialCambios
        {
            get { return _historialCambios; }
        }

        private Queue<string> _colaAtencion;

        public Queue<string> ColaAtencion
        {
            get { return _colaAtencion; }
        }

        

        public AnimalRescatado() : base()
        {
            _historialCambios = new Stack<string>();
            _colaAtencion = new Queue<string>();
        }

        public AnimalRescatado(string id, string nombre, string especie, double peso, DateTime fechaRegistro, bool esActivo)
            : base()
        {
            this.Id = id;
            this.FechaRegistro = fechaRegistro;
            this.EsActivo = esActivo;
            this.Nombre = nombre;
            this.Especie = especie;
            this.Peso = peso;

            _historialCambios = new Stack<string>();
            _colaAtencion = new Queue<string>();
        }

        

        public void ApilarEstado(string estado)
        {
            if (!string.IsNullOrEmpty(estado))
            {
                _historialCambios.Push(estado);
            }
        }

        public string DesapilarEstado()
        {
            if (_historialCambios.Count > 0)
            {
                return _historialCambios.Pop();
            }
            return string.Empty;
        }

        public string InspeccionarCima()
        {
            if (_historialCambios.Count > 0)
            {
                return _historialCambios.Peek();
            }
            return "Pila vacía";
        }

        public int ObtenerConteoHistorial()
        {
            return _historialCambios.Count;
        }

        public bool ExisteEstado(string estadoBuscado)
        {
            if (string.IsNullOrEmpty(estadoBuscado)) return false;

            foreach (string estado in _historialCambios)
            {
                if (estado.Equals(estadoBuscado, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public void VaciarHistorial()
        {
            _historialCambios.Clear();
        }

        public List<string> ObtenerCopiaHistorial()
        {
            List<string> copia = new List<string>();
            foreach (string estado in _historialCambios)
            {
                copia.Add(estado);
            }
            return copia;
        }

        

        public void EncolarTurno(string turno)
        {
            if (!string.IsNullOrEmpty(turno))
            {
                _colaAtencion.Enqueue(turno);
            }
        }

        public string AtenderTurno()
        {
            if (_colaAtencion.Count > 0)
            {
                return _colaAtencion.Dequeue();
            }
            return string.Empty;
        }

        public string InspeccionarFrente()
        {
            if (_colaAtencion.Count > 0)
            {
                return _colaAtencion.Peek();
            }
            return "Cola vacía";
        }

        public int ObtenerConteoCola()
        {
            return _colaAtencion.Count;
        }

        public bool ExisteEnCola(string turnoBuscado)
        {
            if (string.IsNullOrEmpty(turnoBuscado)) return false;

            foreach (string turno in _colaAtencion)
            {
                if (turno.Equals(turnoBuscado, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public void VaciarCola()
        {
            _colaAtencion.Clear();
        }

        public string[] ObtenerArregloCola()
        {
            string[] arreglo = new string[_colaAtencion.Count];
            _colaAtencion.CopyTo(arreglo, 0);
            return arreglo;
        }


        public void InsertarRegistro(object objeto)
        {
            if (objeto is AnimalRescatado animal)
            {
                EliminarRegistro(animal.Id);
                _listaMemoria.Add(animal);
            }
        }

        public object ConsultarRegistro(string id)
        {
            foreach (AnimalRescatado animal in _listaMemoria)
            {
                if (animal.Id.Equals(id.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    return animal;
                }
            }
            return null;
        }

        public void ActualizarRegistro(object objeto)
        {
            InsertarRegistro(objeto);
        }

        public void EliminarRegistro(string id)
        {
            for (int i = _listaMemoria.Count - 1; i >= 0; i--)
            {
                if (_listaMemoria[i].Id.Equals(id.Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    _listaMemoria.RemoveAt(i);
                }
            }
        }
    }
}