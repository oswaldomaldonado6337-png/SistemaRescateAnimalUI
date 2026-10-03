using System;
using System.Windows.Forms;
using SistemaRescateAnimal.Models;

namespace SistemaRescateAnimalUI
{
    public partial class FrmAnimalRescatado : FrmBase, IPanelCRUD
    {
        // Instancia estática o compartida del modelo para conservar los datos en memoria RAM
        private static AnimalRescatado _modeloAnimal = new AnimalRescatado();

        public FrmAnimalRescatado()
        {
            InitializeComponent();
        }

        public void EjecutarGuardar()
        {
            try
            {
                // Toma el ID de la caja local o lo solicita
                string idFinal = string.IsNullOrWhiteSpace(txtId.Text) ? "101" : txtId.Text;

                AnimalRescatado animal = new AnimalRescatado
                {
                    Id = idFinal,
                    Nombre = txtNombre.Text,
                    Especie = txtEspecie.Text,
                    Peso = double.TryParse(numPeso.Text, out double p) ? p : 0.0,
                    FechaRegistro = dtpFechaRegistro.Value,
                    EsActivo = chkEsActivo.Checked
                };

                _modeloAnimal.InsertarRegistro(animal);
                MessageBox.Show($"Animal '{animal.Nombre}' guardado correctamente con ID: {animal.Id}", "Sistema de Rescate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void EjecutarBuscar(string id, ErrorProvider alerta)
        {
            alerta.Clear();

            if (string.IsNullOrWhiteSpace(id))
            {
                alerta.SetError(txtId, "Ingrese un ID válido para buscar.");
                return;
            }

            var resultado = _modeloAnimal.ConsultarRegistro(id) as AnimalRescatado;

            if (resultado != null)
            {
                // Asignar el ID encontrado al control de texto
                txtId.Text = resultado.Id;
                txtNombre.Text = resultado.Nombre;
                txtEspecie.Text = resultado.Especie;
                numPeso.Text = resultado.Peso.ToString();
                dtpFechaRegistro.Value = resultado.FechaRegistro;
                chkEsActivo.Checked = resultado.EsActivo;

                MessageBox.Show($"Registro encontrado: {resultado.Nombre}", "Búsqueda exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No se encontró ningún animal registrado con el ID: {id}", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void EjecutarActualizar()
        {
            try
            {
                AnimalRescatado animal = new AnimalRescatado
                {
                    Id = txtId.Text,
                    Nombre = txtNombre.Text,
                    Especie = txtEspecie.Text,
                    Peso = double.TryParse(numPeso.Text, out double p) ? p : 0.0,
                    FechaRegistro = dtpFechaRegistro.Value,
                    EsActivo = chkEsActivo.Checked
                };

                _modeloAnimal.ActualizarRegistro(animal);
                MessageBox.Show("Registro actualizado correctamente.", "Sistema de Rescate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar: {ex.Message}", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void EjecutarEliminar(StatusStrip barraEstado)
        {
            try
            {
                string idAEliminar = txtId.Text;

                if (string.IsNullOrWhiteSpace(idAEliminar))
                {
                    MessageBox.Show("Seleccione o busque un registro primero para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _modeloAnimal.EliminarRegistro(idAEliminar);

                // Solución al crash de la barra de estado: validar existencia de ítems
                if (barraEstado != null)
                {
                    if (barraEstado.Items.Count == 0)
                    {
                        barraEstado.Items.Add("Listo");
                    }
                    barraEstado.Items[0].Text = $"Registro con ID {idAEliminar} ha sido eliminado.";
                }

                MessageBox.Show($"Registro con ID {idAEliminar} eliminado correctamente.", "Sistema de Rescate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LimpiarFormulario()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtEspecie.Text = string.Empty;
            numPeso.Text = "0";
            chkEsActivo.Checked = false;
            dtpFechaRegistro.Value = DateTime.Now;
        }
    }
}