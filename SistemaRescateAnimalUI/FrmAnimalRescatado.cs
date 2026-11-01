// ============================================================================
// INTEGRANTES - EQUIPO 5:
// - FLORES MONTANO, Carlos Roberto
// - GONZALEZ ALVARADO, Alexa Michelle
// - MALDONADO LLAMAS, Oswaldo Daniel
// ============================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using SistemaRescateAnimal.Models;

namespace SistemaRescateAnimalUI
{
    public partial class FrmAnimalRescatado : FrmBase, IPanelCRUD
    {
        // Instancia principal del modelo para conservar registros en memoria RAM
        private static AnimalRescatado _modeloAnimal = new AnimalRescatado();
        private static int _contadorId = 101;
        private ErrorProvider errorProvider1 = new ErrorProvider();

        // Objeto de nuestra clase de la Pila (Actividad 2.5)
        private AnimalHistorial historialPila = new AnimalHistorial();

        // Controles que agregamos dinámicamente para la interfaz de la Pila
        private GroupBox grpPila = new GroupBox();
        private TextBox txtEstado = new TextBox();
        private Button btnRegistrarEstado = new Button();
        private Button btnDeshacer = new Button();
        private ListBox lstHistorial = new ListBox();
        private Label lblCima = new Label();

        public FrmAnimalRescatado()
        {
            InitializeComponent();
            ConfigurarValidaciones();

            // Al arrancar el formulario creamos la sección de la pila a la derecha y refrescamos los controles
            InicializarControlesPila();
            ActualizarInterfaz();
        }

        private void ConfigurarValidaciones()
        {
            // Eventos KeyPress para evitar que escriban caracteres raros en los textos
            txtNombre.KeyPress += txtTextoSoloLetras_KeyPress;
            txtEspecie.KeyPress += txtTextoSoloLetras_KeyPress;
            numPeso.KeyPress += txtNumeroDecimal_KeyPress;

            // Eventos de validación cuando se pierde el foco de la casilla
            txtNombre.Validating += txtCampoObligatorio_Validating;
            txtEspecie.Validating += txtCampoObligatorio_Validating;
            numPeso.Validating += numPeso_Validating;
        }

        #region ESTRUCTURA Y CONTROLES DE LA PILA (ACTIVIDAD 2.5)

        private void InicializarControlesPila()
        {
            // 1. Reducimos el ancho del selector de fecha a formato corto para que no se extienda horizontalmente
            if (dtpFechaRegistro != null)
            {
                dtpFechaRegistro.Format = DateTimePickerFormat.Short;
                dtpFechaRegistro.Width = 140;
            }

            // 2. Ajustamos la ventana a 920px de ancho para dar margen suficiente
            this.ClientSize = new Size(910, 500);
            if (this.Width < 920) this.Width = 920;

            // 3. Posicionamos el GroupBox a partir de X = 540 libre de cualquier traslape
            grpPila.Text = " Control Histórico (Pila LIFO) ";
            grpPila.Location = new Point(540, 75);
            grpPila.Size = new Size(330, 380);
            this.Controls.Add(grpPila);

            // Texto indicador
            Label lblInstruccion = new Label();
            lblInstruccion.Text = "Estado a registrar:";
            lblInstruccion.Location = new Point(20, 25);
            lblInstruccion.AutoSize = true;
            grpPila.Controls.Add(lblInstruccion);

            // Caja de texto donde ingresamos el nuevo estado
            this.txtEstado.Location = new Point(20, 45);
            this.txtEstado.Size = new Size(290, 22);
            grpPila.Controls.Add(this.txtEstado);

            // Botón para hacer Push (apilar estado)
            this.btnRegistrarEstado.Text = "Registrar Estado";
            this.btnRegistrarEstado.Location = new Point(20, 80);
            this.btnRegistrarEstado.Size = new Size(135, 30);
            this.btnRegistrarEstado.Click += new EventHandler(this.btnRegistrarEstado_Click);
            grpPila.Controls.Add(this.btnRegistrarEstado);

            // Botón para hacer Pop (desapilar o deshacer acción)
            this.btnDeshacer.Text = "Deshacer Último";
            this.btnDeshacer.Location = new Point(175, 80);
            this.btnDeshacer.Size = new Size(135, 30);
            this.btnDeshacer.Click += new EventHandler(this.btnDeshacer_Click);
            grpPila.Controls.Add(this.btnDeshacer);

            // ListBox para ir monitoreando los elementos guardados en la pila
            this.lstHistorial.Location = new Point(20, 125);
            this.lstHistorial.Size = new Size(290, 190);
            grpPila.Controls.Add(this.lstHistorial);

            // Label para mostrar el dato en la cima (Peek)
            this.lblCima.Text = "Cima: (vacía)";
            this.lblCima.Location = new Point(20, 330);
            this.lblCima.AutoSize = true;
            this.lblCima.Font = new Font(this.lblCima.Font, FontStyle.Bold);
            grpPila.Controls.Add(this.lblCima);
        }

        // Clic en Registrar Estado: inserta el texto en la cima de la pila
        private void btnRegistrarEstado_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEstado.Text))
            {
                return;
            }

            // Llamamos al método Push del modelo
            historialPila.Push(txtEstado.Text.Trim());
            txtEstado.Clear();
            ActualizarInterfaz();
        }

        // Clic en Deshacer Último: retira el elemento más reciente
        private void btnDeshacer_Click(object? sender, EventArgs e)
        {
            // Llamamos al método Pop del modelo
            historialPila.Pop();
            ActualizarInterfaz();
        }

        // Método auxiliar para actualizar la lista visual y validar el estado del botón Deshacer
        private void ActualizarInterfaz()
        {
            lstHistorial.Items.Clear();

            // Volcamos la pila a una lista copia para vaciar los datos en el ListBox sin modificar la pila original
            List<string> lista = historialPila.VolcarArreglo();
            foreach (string item in lista)
            {
                lstHistorial.Items.Add(item);
            }

            // Cumplimiento del punto 4: si no hay elementos en la pila, desactivamos el botón para evitar excepciones
            if (historialPila.Count() == 0)
            {
                btnDeshacer.Enabled = false;
                lblCima.Text = "Cima: (vacía)";
            }
            else
            {
                btnDeshacer.Enabled = true;
                // Usamos Peek() para leer el elemento superior sin sacarlo
                lblCima.Text = "Cima: " + historialPila.Peek();
            }
        }

        #endregion

        #region FILTROS DE TECLADO Y VALIDACIONES

        private void txtTextoSoloLetras_KeyPress(object? sender, KeyPressEventArgs e)
        {
            // Bloqueamos teclas que no sean letras, espacio o teclas de control (como borrar)
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
                SystemSounds.Beep.Play();
            }
        }

        private void txtNumeroDecimal_KeyPress(object? sender, KeyPressEventArgs e)
        {
            TextBox? txt = sender as TextBox;

            // Solo permitimos dígitos y un solo punto decimal
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

        #region FUNCIONES CRUD DEL FORMULARIO

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
                string idFinal = string.IsNullOrWhiteSpace(txtIdBusqueda.Text) ? _contadorId.ToString() : txtIdBusqueda.Text;

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
                txtIdBusqueda.Text = idFinal;

                if (idFinal == _contadorId.ToString())
                {
                    _contadorId++;
                }

                MessageBox.Show($"Animal '{animal.Nombre}' guardado correctamente con ID: {animal.Id}",
                                "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                errorProvider1.Clear();
                LimpiarFormulario(); // <--- LIMPIEZA AUTOMÁTICA AGREGADA
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void EjecutarBuscar(string id, ErrorProvider alerta)
        {
            errorProvider1.SetIconAlignment(txtIdBusqueda, ErrorIconAlignment.MiddleLeft);
            errorProvider1.SetIconPadding(txtIdBusqueda, 5);

            if (alerta != null)
            {
                alerta.SetIconAlignment(txtIdBusqueda, ErrorIconAlignment.MiddleLeft);
                alerta.SetIconPadding(txtIdBusqueda, 5);
                alerta.Clear();
            }
            errorProvider1.SetError(txtIdBusqueda, "");

            if (string.IsNullOrWhiteSpace(id))
            {
                string msjVacio = "Ingrese un ID válido para buscar.";
                errorProvider1.SetError(txtIdBusqueda, msjVacio);
                if (alerta != null) alerta.SetError(txtIdBusqueda, msjVacio);
                MessageBox.Show(msjVacio, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (char c in id)
            {
                if (!char.IsLetterOrDigit(c))
                {
                    string msjSimbolo = "El ID no debe contener símbolos o caracteres especiales (% , & , *).";
                    errorProvider1.SetError(txtIdBusqueda, msjSimbolo);
                    if (alerta != null) alerta.SetError(txtIdBusqueda, msjSimbolo);

                    LimpiarFormulario();
                    txtIdBusqueda.Text = id;

                    MessageBox.Show(msjSimbolo, "Error de Validación de ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var resultado = _modeloAnimal.ConsultarRegistro(id) as AnimalRescatado;

            if (resultado != null)
            {
                txtIdBusqueda.Text = resultado.Id;
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
                txtIdBusqueda.Text = id;
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
                    Id = txtIdBusqueda.Text,
                    Nombre = txtNombre.Text.Trim(),
                    Especie = txtEspecie.Text.Trim(),
                    Peso = double.TryParse(numPeso.Text, out double p) ? p : 0.0,
                    FechaRegistro = dtpFechaRegistro.Value,
                    EsActivo = chkEsActivo.Checked
                };

                _modeloAnimal.ActualizarRegistro(animal);
                MessageBox.Show("Registro actualizado correctamente.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario(); // También agregamos limpieza aquí por comodidad
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
                string idAEliminar = txtIdBusqueda.Text;

                if (string.IsNullOrWhiteSpace(idAEliminar))
                {
                    MessageBox.Show("Seleccione o busque un registro primero para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult respuesta = MessageBox.Show(
                    $"¿Está seguro de que desea eliminar el registro con ID '{idAEliminar}'?",
                    "Confirmación de Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

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

        public void ExportarExpedienteTXT()
        {
            if (string.IsNullOrWhiteSpace(txtIdBusqueda.Text))
            {
                MessageBox.Show("Primero busque o cargue un registro para exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Guardar Expediente de Animal Rescatado";
                saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                saveFileDialog.FileName = $"Expediente_{txtIdBusqueda.Text}.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string datos = $"EXPEDIENTE DE ANIMAL RESCATADO\n" +
                                   $"-----------------------------\n" +
                                   $"ID: {txtIdBusqueda.Text}\n" +
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
            txtIdBusqueda.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtEspecie.Text = string.Empty;
            numPeso.Text = "0";
            chkEsActivo.Checked = false;
            dtpFechaRegistro.Value = DateTime.Now;
            errorProvider1.Clear();
        }

        #endregion

        private void FrmAnimalRescatado_Load(object sender, EventArgs e)
        {
        }

        private void btnMasterGuardar_Click(object sender, EventArgs e)
        {
            EjecutarGuardar();
        }

        private void btnMasterBuscar_Click(object sender, EventArgs e)
        {
            EjecutarBuscar(txtIdBusqueda.Text, errorProvider1);
        }

        private void btnMasterActualizar_Click(object sender, EventArgs e)
        {
            EjecutarActualizar();
        }

        private void btnMasterEliminar_Click(object sender, EventArgs e)
        {
            EjecutarEliminar(null);
        }
    }
}