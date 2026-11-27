using SistemaRescateAnimal.Datos;
using SistemaRescateAnimal.Models;
using System;
using System.Diagnostics;
using System.Windows.Forms;


namespace SistemaRescateAnimalUI
{
    public partial class FrmRegistroAdopcion : Form
    {
        private readonly AdopcionDAO _adopcionDAO;

        public FrmRegistroAdopcion()
        {
            InitializeComponent();
            _adopcionDAO = new AdopcionDAO();
        }

        private void FrmRegistroAdopcion_Load(object sender, EventArgs e)
        {
            CargarCombos();
        }

        private void CargarCombos()
        {
            try
            {
                // Combo de Animales (Solo traerá los "Disponibles" gracias al DAO)
                cmbAnimal.DataSource = _adopcionDAO.ObtenerAnimalesParaCombo();
                cmbAnimal.DisplayMember = "Nombre";
                cmbAnimal.ValueMember = "IdAnimal";
                cmbAnimal.SelectedIndex = -1; // Deja el combo en blanco

                // Combo de Adoptantes
                cmbAdoptante.DataSource = _adopcionDAO.ObtenerAdoptantesParaCombo();
                cmbAdoptante.DisplayMember = "NombreCompleto";
                cmbAdoptante.ValueMember = "IdAdoptante";
                cmbAdoptante.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las listas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cmbAnimal.SelectedIndex == -1 || cmbAdoptante.SelectedIndex == -1)
            {
                MessageBox.Show("Es obligatorio seleccionar un animal y un adoptante.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbFormaPago.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una forma de pago o aportación.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreAnimalSeleccionado = cmbAnimal.Text;
            string nombreAdoptanteSeleccionado = cmbAdoptante.Text;

            Adopcion nuevaAdopcion = new Adopcion
            {
                IdAnimal = cmbAnimal.SelectedValue.ToString(),
                IdAdoptante = Convert.ToInt32(cmbAdoptante.SelectedValue),
                FechaAdopcion = dtpFechaAdopcion.Value,
                Monto = numDonacion.Value,
                FormaPago = cmbFormaPago.Text,
                Estado = "Vigente",
                Observaciones = txtObservaciones.Text.Trim()
            };

            try
            {
                if (_adopcionDAO.RegistrarAdopcion(nuevaAdopcion) && _adopcionDAO.RegistrarAdopcionMongo(nuevaAdopcion))
                {
                    MessageBox.Show($"¡Adopción registrada con éxito!\nFolio Único: {nuevaAdopcion.Folio}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    GenerarCertificadoAdopcion(nuevaAdopcion, nombreAnimalSeleccionado, nombreAdoptanteSeleccionado);

                    CargarCombos();

                    cmbAnimal.SelectedIndex = -1;
                    cmbAdoptante.SelectedIndex = -1;
                    cmbFormaPago.SelectedIndex = -1;
                    dtpFechaAdopcion.Value = DateTime.Now;
                    numDonacion.Value = 0;
                    txtObservaciones.Clear();
                    cmbAnimal.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarCertificadoAdopcion(Adopcion adopcion, string nombreAnimal, string nombreAdoptante)
        {
            try
            {
                string carpeta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Certificados");
                if (!Directory.Exists(carpeta)) Directory.CreateDirectory(carpeta);

                string rutaArchivo = Path.Combine(carpeta, $"Certificado_{adopcion.Folio}.html");
                string html = $@"
                <html>
                <head><meta charset='utf-8'><title>Certificado {adopcion.Folio}</title></head>
                <body style='font-family: Arial, sans-serif; padding: 40px; background: #f4f6f9;'>
                    <div style='max-width: 700px; margin: auto; background: white; padding: 35px; border: 3px solid #2e7d32; border-radius: 10px;'>
                        <h1 style='color: #2e7d32; text-align: center;'>CERTIFICADO OFICIAL DE ADOPCIÓN</h1>
                        <p style='text-align: center; font-size: 18px;'><strong>Folio Único:</strong> {adopcion.Folio}</p>
                        <hr/>
                        <p><strong>Fecha y Hora:</strong> {adopcion.FechaAdopcion:dd/MM/yyyy HH:mm}</p>
                        <p><strong>Adoptante Responsable:</strong> {nombreAdoptante}</p>
                        <p><strong>Ejemplar Adoptado:</strong> {nombreAnimal}</p>
                        <p><strong>Donación Voluntaria:</strong> {adopcion.Monto:C2} ({adopcion.FormaPago})</p>
                        <p><strong>Observaciones:</strong> {(string.IsNullOrWhiteSpace(adopcion.Observaciones) ? "Ninguna" : adopcion.Observaciones)}</p>
                        <br/><br/>
                        <p style='text-align: center; color: #555;'>Sistema de Rescate Animal — Comprometidos con el bienestar animal (ODS 15)</p>
                    </div>
                </body>
                </html>";

                File.WriteAllText(rutaArchivo, html);
                Process.Start(new ProcessStartInfo(rutaArchivo) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Adopción guardada, pero no se pudo abrir el certificado: " + ex.Message);
            }
        }

        private void cmbAnimal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }
}