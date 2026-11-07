// ============================================================================
// INTEGRANTES - EQUIPO 5:
// - FLORES MONTANO, Roberto Carlos
// - GONZALEZ ALVARADO, Alexa Michelle
// - MALDONADO LLAMAS, Oswaldo Daniel
// ============================================================================
using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaRescateAnimal.Models;

namespace SistemaRescateAnimalUI
{
    public partial class FrmAnimalRescatado : FrmBase, IPanelCRUD
    {
        private static AnimalRescatado _modeloAnimal = new AnimalRescatado();
        private static int _contadorId = 101;
        private ErrorProvider errorProvider1 = new ErrorProvider();
        private string rutaImagenTemporal = "";

        // Estructura de datos Pila (Actividad 2.5)
        private AnimalHistorial historialPila = new AnimalHistorial();

        // Componentes para la interfaz del historial
        private GroupBox grpPila = new GroupBox();
        private PictureBox pbxFotografia = new PictureBox();
        private Button btnCargarImagen = new Button();
        private TextBox txtEstado = new TextBox();
        private Button btnRegistrarEstado = new Button();
        private Button btnDeshacer = new Button();
        private ListBox lstHistorial = new ListBox();
        private Label lblCima = new Label();

        // Componentes para el procesamiento asíncrono (Actividad 3.4)
        private GroupBox grpConcurrencia = new GroupBox();
        private ProgressBar pgbReporte = new ProgressBar();
        private Button btnGenerarReporte = new Button();
        private Button btnCancelarReporte = new Button();
        private Label lblEstadoReporte = new Label();
        private CancellationTokenSource cts;

        public FrmAnimalRescatado()
        {
            InitializeComponent();
            ConfigurarValidaciones();

            InicializarControlesPila();
            InicializarControlesConcurrencia();
            InicializarControlImagen();
            ActualizarInterfaz();
        }

        private void ConfigurarValidaciones()
        {
            txtNombre.KeyPress += txtTextoSoloLetras_KeyPress;
            txtEspecie.KeyPress += txtTextoSoloLetras_KeyPress;
            numPeso.KeyPress += txtNumeroDecimal_KeyPress;

            txtNombre.Validating += txtCampoObligatorio_Validating;
            txtEspecie.Validating += txtCampoObligatorio_Validating;
            numPeso.Validating += numPeso_Validating;
        }

        #region HISTORIAL Y PILA LIFO (ACTIVIDAD 2.5)

        private void InicializarControlesPila()
        {
            if (dtpFechaRegistro != null)
            {
                dtpFechaRegistro.Format = DateTimePickerFormat.Short;
                dtpFechaRegistro.Width = 140;
            }

            // Ajuste del formulario para dar cabida a Pila, Concurrencia e Imagen
            this.ClientSize = new Size(1120, 540);
            if (this.Width < 1120) this.Width = 1120;

            grpPila.Text = " Control Histórico (Pila LIFO) ";
            grpPila.Location = new Point(540, 75);
            grpPila.Size = new Size(330, 420);
            this.Controls.Add(grpPila);

            Label lblInstruccion = new Label();
            lblInstruccion.Text = "Estado a registrar:";
            lblInstruccion.Location = new Point(20, 25);
            lblInstruccion.AutoSize = true;
            grpPila.Controls.Add(lblInstruccion);

            this.txtEstado.Location = new Point(20, 45);
            this.txtEstado.Size = new Size(290, 22);
            grpPila.Controls.Add(this.txtEstado);

            this.btnRegistrarEstado.Text = "Registrar Estado";
            this.btnRegistrarEstado.Location = new Point(20, 80);
            this.btnRegistrarEstado.Size = new Size(135, 30);
            this.btnRegistrarEstado.Click += new EventHandler(this.btnRegistrarEstado_Click);
            grpPila.Controls.Add(this.btnRegistrarEstado);

            this.btnDeshacer.Text = "Deshacer Último";
            this.btnDeshacer.Location = new Point(175, 80);
            this.btnDeshacer.Size = new Size(135, 30);
            this.btnDeshacer.Click += new EventHandler(this.btnDeshacer_Click);
            grpPila.Controls.Add(this.btnDeshacer);

            this.lstHistorial.Location = new Point(20, 125);
            this.lstHistorial.Size = new Size(290, 230);
            grpPila.Controls.Add(this.lstHistorial);

            this.lblCima.Text = "Cima: (vacía)";
            this.lblCima.Location = new Point(20, 370);
            this.lblCima.AutoSize = true;
            this.lblCima.Font = new Font(this.lblCima.Font, FontStyle.Bold);
            grpPila.Controls.Add(this.lblCima);
        }

        private void btnRegistrarEstado_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEstado.Text))
            {
                return;
            }

            historialPila.Push(txtEstado.Text.Trim());
            txtEstado.Clear();
            ActualizarInterfaz();
        }

        private void btnDeshacer_Click(object? sender, EventArgs e)
        {
            historialPila.Pop();
            ActualizarInterfaz();
        }

        private void ActualizarInterfaz()
        {
            lstHistorial.Items.Clear();

            List<string> lista = historialPila.VolcarArreglo();
            foreach (string item in lista)
            {
                lstHistorial.Items.Add(item);
            }

            if (historialPila.Count() == 0)
            {
                btnDeshacer.Enabled = false;
                lblCima.Text = "Cima: (vacía)";
            }
            else
            {
                btnDeshacer.Enabled = true;
                lblCima.Text = "Cima: " + historialPila.Peek();
            }
        }

        #endregion

        #region MULTIMEDIA Y MANEJO DE ARCHIVOS (ACTIVIDAD 3.6)

        private void InicializarControlImagen()
        {
            // Posicionamiento del PictureBox y el botón Cargar a la derecha de la Pila
            this.pbxFotografia.Location = new Point(895, 85);
            this.pbxFotografia.Size = new Size(195, 185);
            this.pbxFotografia.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pbxFotografia.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(this.pbxFotografia);

            this.btnCargarImagen.Text = "Cargar Imagen";
            this.btnCargarImagen.Location = new Point(895, 280);
            this.btnCargarImagen.Size = new Size(195, 32);
            this.btnCargarImagen.Click += new EventHandler(this.btnCargarImagen_Click);
            this.Controls.Add(this.btnCargarImagen);
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Archivos de imagen (.jpg, .png)|*.jpg;*.png";
                dialog.Title = "Seleccionar fotografía del animal";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    rutaImagenTemporal = dialog.FileName;
                    pbxFotografia.Image = Image.FromFile(rutaImagenTemporal);
                }
            }
        }

        #endregion

        #region PROCESAMIENTO ASÍNCRONO E HILOS (ACTIVIDAD 3.4)

        private void InicializarControlesConcurrencia()
        {
            grpConcurrencia.Text = " Procesamiento Asíncrono (Task / Concurrencia) ";
            grpConcurrencia.Location = new Point(20, 350);
            grpConcurrencia.Size = new Size(500, 145);
            this.Controls.Add(grpConcurrencia);

            btnGenerarReporte.Text = "Procesar Reporte Async";
            btnGenerarReporte.Location = new Point(15, 25);
            btnGenerarReporte.Size = new Size(180, 30);
            btnGenerarReporte.Click += async (s, e) => await IniciarProcesoAsincronoAsync();
            grpConcurrencia.Controls.Add(btnGenerarReporte);

            btnCancelarReporte.Text = "Cancelar";
            btnCancelarReporte.Location = new Point(205, 25);
            btnCancelarReporte.Size = new Size(100, 30);
            btnCancelarReporte.Enabled = false;
            btnCancelarReporte.Click += (s, e) => CancelarProcesoHilo();
            grpConcurrencia.Controls.Add(btnCancelarReporte);

            pgbReporte.Location = new Point(15, 65);
            pgbReporte.Size = new Size(465, 23);
            pgbReporte.Minimum = 0;
            pgbReporte.Maximum = 100;
            grpConcurrencia.Controls.Add(pgbReporte);

            lblEstadoReporte.Text = "Estado: En espera de iniciar proceso.";
            lblEstadoReporte.Location = new Point(15, 100);
            lblEstadoReporte.AutoSize = true;
            grpConcurrencia.Controls.Add(lblEstadoReporte);
        }

        private async Task IniciarProcesoAsincronoAsync()
        {
            cts = new CancellationTokenSource();
            btnGenerarReporte.Enabled = false;
            btnCancelarReporte.Enabled = true;
            pgbReporte.Value = 0;
            lblEstadoReporte.Text = "Estado: Procesando datos en hilo secundario (Task.Run)...";

            bool cancelado = false;

            try
            {
                await Task.Run(() =>
                {
                    for (int i = 1; i <= 100; i++)
                    {
                        if (cts.Token.IsCancellationRequested)
                        {
                            cancelado = true;
                            break;
                        }

                        Thread.Sleep(40);
                        int progreso = i;

                        if (this.IsDisposed || !this.IsHandleCreated)
                        {
                            return;
                        }

                        try
                        {
                            this.Invoke(new Action(() =>
                            {
                                if (!pgbReporte.IsDisposed)
                                {
                                    pgbReporte.Value = progreso;
                                }
                            }));
                        }
                        catch (ObjectDisposedException)
                        {
                            return;
                        }
                    }
                });

                if (cancelado)
                {
                    if (!this.IsDisposed)
                    {
                        lblEstadoReporte.Text = "Estado: Proceso cancelado por el usuario.";
                        pgbReporte.Value = 0;
                    }
                }
                else if (!this.IsDisposed)
                {
                    lblEstadoReporte.Text = "Estado: ¡Reporte generado exitosamente!";
                }
            }
            catch (Exception ex)
            {
                if (!this.IsDisposed)
                {
                    lblEstadoReporte.Text = $"Estado: Error en hilo - {ex.Message}";
                }
            }
            finally
            {
                if (!this.IsDisposed)
                {
                    btnGenerarReporte.Enabled = true;
                    btnCancelarReporte.Enabled = false;
                }
                cts.Dispose();
            }
        }

        private void CancelarProcesoHilo()
        {
            if (cts != null && !cts.IsCancellationRequested)
            {
                cts.Cancel();
            }
        }

        #endregion

        #region VALIDACIONES DE ENTRADA

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

        #region OPERACIONES CRUD Y PERSISTENCIA

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
                MessageBox.Show("No se puede guardar. Existen datos incompletos o inválidos.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idFinal = string.IsNullOrWhiteSpace(txtIdBusqueda.Text) ? _contadorId.ToString() : txtIdBusqueda.Text;
            string nombreArchivoFinal = "";

            // Copia física de la imagen usando System.IO con manejo de excepciones
            if (!string.IsNullOrEmpty(rutaImagenTemporal))
            {
                try
                {
                    string rutaBase = AppDomain.CurrentDomain.BaseDirectory;
                    string carpetaDestino = Path.Combine(rutaBase, "ImagenesDatos");

                    if (!Directory.Exists(carpetaDestino))
                    {
                        Directory.CreateDirectory(carpetaDestino);
                    }

                    string extension = Path.GetExtension(rutaImagenTemporal);
                    nombreArchivoFinal = Guid.NewGuid().ToString() + extension;
                    string rutaFinalCompleta = Path.Combine(carpetaDestino, nombreArchivoFinal);

                    File.Copy(rutaImagenTemporal, rutaFinalCompleta, true);
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show($"El archivo de origen no fue encontrado: {ex.Message}", "Error de archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show($"Acceso denegado para escribir en el directorio: {ex.Message}", "Error de permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (IOException ex)
                {
                    MessageBox.Show($"Error de entrada/salida al copiar la imagen: {ex.Message}", "Error de E/S", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error no esperado al procesar imagen: {ex.Message}", "Error de sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            try
            {
                AnimalRescatado animal = new AnimalRescatado
                {
                    Id = idFinal,
                    Nombre = txtNombre.Text.Trim(),
                    Especie = txtEspecie.Text.Trim(),
                    Peso = double.TryParse(numPeso.Text, out double p) ? p : 0.0,
                    FechaRegistro = dtpFechaRegistro.Value,
                    EsActivo = chkEsActivo.Checked,
                    RutaImagen = nombreArchivoFinal
                };

                _modeloAnimal.InsertarRegistro(animal);
                txtIdBusqueda.Text = idFinal;

                if (idFinal == _contadorId.ToString()) _contadorId++;

                MessageBox.Show($"Animal '{animal.Nombre}' guardado correctamente con ID: {animal.Id}", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                errorProvider1.Clear();
                LimpiarFormulario();

                if (pbxFotografia != null)
                {
                    pbxFotografia.Image = null;
                }
                rutaImagenTemporal = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar el registro: {ex.Message}", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                LimpiarFormulario();
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