using SistemaRescateAnimal.Datos;
using SistemaRescateAnimal.Models;
using SistemaRescateAnimalUI.Models;
using System;
using System.Windows.Forms;

namespace SistemaRescateAnimalUI
{
    public partial class FrmAdoptantes : Form
    {
        private readonly AdoptanteDAO _adoptanteDAO;

        public FrmAdoptantes()
        {
            InitializeComponent();
            _adoptanteDAO = new AdoptanteDAO();
        }

        private void FrmAdoptantes_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void CargarGrid()
        {
            try
            {
                // Solo si ya agregaste un DataGridView llamado dgvAdoptantes a tu diseño.
                // Si aún no lo agregas, puedes comentar esta línea por ahora.
                // dgvAdoptantes.DataSource = _adoptanteDAO.ObtenerTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellidoPaterno.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtCalle.Text) ||
                string.IsNullOrWhiteSpace(txtNumero.Text) ||
                string.IsNullOrWhiteSpace(txtColonia.Text) ||
                string.IsNullOrWhiteSpace(txtCiudad.Text))
            {
                MessageBox.Show("Faltan campos obligatorios por llenar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Adoptante nuevoAdoptante = new Adoptante
            {
                Nombre = txtNombre.Text.Trim(),
                ApellidoPaterno = txtApellidoPaterno.Text.Trim(),
                ApellidoMaterno = txtApellidoMaterno.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Calle = txtCalle.Text.Trim(),
                Numero = txtNumero.Text.Trim(),
                Colonia = txtColonia.Text.Trim(),
                Ciudad = txtCiudad.Text.Trim()
            };

            try
            {
                if (_adoptanteDAO.RegistrarAdoptante(nuevoAdoptante))
                {
                    MessageBox.Show("Adoptante registrado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormulario();
                    CargarGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellidoPaterno.Clear();
            txtApellidoMaterno.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtCalle.Clear();
            txtNumero.Clear();
            txtColonia.Clear();
            txtCiudad.Clear();
            txtNombre.Focus();
        }
    }
}