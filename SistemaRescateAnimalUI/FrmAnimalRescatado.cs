/* ============================================================================
 * ASIGNATURA: Interacción Hombre-Computadora
 * ACTIVIDAD 3.3: Diálogos y Ventanas Modales
 * INTEGRANTES:
 *    - FLORES MONTANO, Carlos Roberto
 *    - GONZALEZ ALVARADO, Alexa Michelle
 *    - MALDONADO LLAMAS, Oswaldo Daniel
 * ============================================================================ */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using SistemaRescateAnimal.Models;

namespace SistemaRescateAnimalUI
{
    public partial class FrmAnimalRescatado : FrmBase, IPanelCRUD
    {
        // Instancia estática del modelo en memoria RAM
        private static AnimalRescatado _modeloAnimal = new AnimalRescatado();

        // ErrorProvider local para alertas de error
        private ErrorProvider errorProvider1 = new ErrorProvider();

        public FrmAnimalRescatado()
        {
            InitializeComponent();
            ConfigurarValidaciones();
        }

        private void ConfigurarValidaciones()
        {
            // Filtros de teclado (KeyPress)
            txtNombre.KeyPress += txtTextoSoloLetras_KeyPress;
            txtEspecie.KeyPress += txtTextoSoloLetras_KeyPress;
            numPeso.KeyPress += txtNumeroDecimal_KeyPress;

            // Validaciones de enfoque (Validating)
            txtNombre.Validating += txtCampoObligatorio_Validating;
            txtEspecie.Validating += txtCampoObligatorio_Validating;
            numPeso.Validating += numPeso_Validating;
        }

        #region EVENTOS KEYPRESS

        private void txtTextoSoloLetras_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }

        private void txtNumeroDecimal_KeyPress(object? sender, KeyPressEventArgs e)
        {
            TextBox? txt = sender as TextBox;

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                if (e.KeyChar == '.' && txt != null && !txt.Text.Contains('.'))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                    SystemSounds.Beep.Play();
                }
            }
        }

        #endregion

        #region EVENTOS VALIDATING

        private void txtCampoObligatorio_Validating(object? sender, CancelEventArgs e)
        {
            TextBox? txt = sender as TextBox;

            if (txt != null && string.IsNullOrWhiteSpace(txt.Text))
            {
                e.Cancel = false;
                errorProvider1.SetError(txt, "Este campo es obligatorio.");
            }
            else if (txt != null)
            {
                errorProvider1.SetError(txt, "");
            }
        }

        private void numPeso_Validating(object? sender, CancelEventArgs e)
        {
            TextBox? txt = sender as TextBox;

            if (txt != null && (!double.TryParse(txt.Text, out double p) || p <= 0))
            {
                e.Cancel = false;
                errorProvider1.SetError(txt, "Ingrese un peso mayor a 0.");
            }
            else if (txt != null)
            {
                errorProvider1.SetError(txt, "");
            }
        }

        #endregion

        #region OPERACIONES CRUD Y GUARDADO

        public void EjecutarGuardar()
        {
            bool tieneErrores = string.IsNullOrWhiteSpace(txtNombre.Text) ||
                                string.IsNullOrWhiteSpace(txtEspecie.Text) ||
                                !double.TryParse(numPeso.Text, out double pVal) || pVal <= 0;

            if (string.IsNullOrWhiteSpace(txtNombre.Text)) errorProvider1.SetError(txtNombre, "Campo obligatorio.");
            if (string.IsNullOrWhiteSpace(txtEspecie.Text)) errorProvider1.SetError(txtEspecie, "Campo obligatorio.");
            if (!double.TryParse(numPeso.Text, out double pCheck) || pCheck <= 0) errorProvider1.SetError(numPeso, "Ingrese peso mayor a 0.");

            if (tieneErrores)
            {
                MessageBox.Show("No se puede guardar. Existen datos incompletos o inválidos marcados en la pantalla.",
                                "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string idFinal = string.IsNullOrWhiteSpace(txtId.Text) ? "101" : txtId.Text;

                AnimalRescatado animal = new AnimalRescatado
                {
                    Id = idFinal,
                    Nombre = txtNombre.Text.Trim(),
                    Especie = txtEspecie.Text.Trim(),
                    Peso = double.TryParse(numPeso.Text, out double p) ? p : 0.0,
                    FechaRegistro = dtpFechaRegistro.Value,
                    EsActivo = chkEsActivo.Checked
                };

                _modeloAnimal.InsertarRegistro(animal);

                // Asignamos el ID directamente al control para que no quede vacío si queremos eliminar de inmediato
                txtId.Text = idFinal;

                MessageBox.Show($"Animal '{animal.Nombre}' guardado correctamente con ID: {animal.Id}",
                                "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                errorProvider1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void EjecutarBuscar(string id, ErrorProvider alerta)
        {
            // Posicionar el icono del ErrorProvider a la izquierda
            errorProvider1.SetIconAlignment(txtId, ErrorIconAlignment.MiddleLeft);
            errorProvider1.SetIconPadding(txtId, 5);

            if (alerta != null)
            {
                alerta.SetIconAlignment(txtId, ErrorIconAlignment.MiddleLeft);
                alerta.SetIconPadding(txtId, 5);
                alerta.Clear();
            }
            errorProvider1.SetError(txtId, "");

            // 1. Validar que no esté vacío
            if (string.IsNullOrWhiteSpace(id))
            {
                string msjVacio = "Ingrese un ID válido para buscar.";
                errorProvider1.SetError(txtId, msjVacio);
                if (alerta != null) alerta.SetError(txtId, msjVacio);
                MessageBox.Show(msjVacio, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validar caracteres especiales
            foreach (char c in id)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    string msjSimbolo = "El ID no debe contener símbolos o caracteres especiales (% , & , *).";
                    errorProvider1.SetError(txtId, msjSimbolo);
                    if (alerta != null) alerta.SetError(txtId, msjSimbolo);

                    LimpiarFormulario();
                    txtId.Text = id;

                    MessageBox.Show(msjSimbolo, "Error de Validación de ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // 3. Consultar en el modelo
            var resultado = _modeloAnimal.ConsultarRegistro(id) as AnimalRescatado;

            if (resultado != null)
            {
                txtId.Text = resultado.Id;
                txtNombre.Text = resultado.Nombre;
                txtEspecie.Text = resultado.Especie;
                numPeso.Text = resultado.Peso.ToString();
                dtpFechaRegistro.Value = resultado.FechaRegistro;
                chkEsActivo.Checked = resultado.EsActivo;

                errorProvider1.Clear();
                if (alerta != null) alerta.Clear();

                MessageBox.Show($"Registro encontrado: {resultado.Nombre}", "Búsqueda exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                LimpiarFormulario();
                txtId.Text = id;
                MessageBox.Show($"No existe ningún registro guardado con el ID: '{id}'.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void EjecutarActualizar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtEspecie.Text))
            {
                MessageBox.Show("Corrija los errores antes de actualizar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                AnimalRescatado animal = new AnimalRescatado
                {
                    Id = txtId.Text,
                    Nombre = txtNombre.Text.Trim(),
                    Especie = txtEspecie.Text.Trim(),
                    Peso = double.TryParse(numPeso.Text, out double p) ? p : 0.0,
                    FechaRegistro = dtpFechaRegistro.Value,
                    EsActivo = chkEsActivo.Checked
                };

                _modeloAnimal.ActualizarRegistro(animal);
                MessageBox.Show("Registro actualizado correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                // Pregunta obligatoria con MessageBox.Show y evaluación de DialogResult (Requisito A3.3)
                DialogResult respuesta = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar el registro con ID '{idAEliminar}'?",
                    "Confirmación de Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                // Si selecciona No, aborta inmediatamente el proceso sin borrar nada
                if (respuesta == DialogResult.No)
                {
                    return;
                }

                _modeloAnimal.EliminarRegistro(idAEliminar);

                if (barraEstado != null)
                {
                    if (barraEstado.Items.Count == 0)
                    {
                        barraEstado.Items.Add("Listo");
                    }
                    barraEstado.Items[0].Text = $"Registro {idAEliminar} eliminado.";
                }

                MessageBox.Show($"Registro con ID {idAEliminar} eliminado.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Exportación de datos utilizando SaveFileDialog con filtros (Requisito A3.3)
        public void ExportarExpedienteTXT()
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Primero busque o cargue un registro para exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Guardar Expediente de Animal Rescatado";
                saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog.FileName = $"Expediente_{txtId.Text}.txt";

                // Evaluamos que el usuario haya hecho clic en Guardar
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string datos = $"EXPEDIENTE DE ANIMAL RESCATADO\n" +
                                   $"-----------------------------\n" +
                                   $"ID: {txtId.Text}\n" +
                                   $"Nombre: {txtNombre.Text}\n" +
                                   $"Especie: {txtEspecie.Text}\n" +
                                   $"Peso: {numPeso.Text} kg\n" +
                                   $"Fecha: {dtpFechaRegistro.Value:dd/MM/yyyy}\n" +
                                   $"Estado: {(chkEsActivo.Checked ? "Activo" : "Inactivo")}";

                    System.IO.File.WriteAllText(saveFileDialog.FileName, datos);
                    MessageBox.Show("Expediente exportado correctamente a TXT.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
            errorProvider1.Clear();
        }

        #endregion

        #region EVENTO LOAD
        private void FrmAnimalRescatado_Load(object sender, EventArgs e)
        {
        }
        #endregion
    }
}