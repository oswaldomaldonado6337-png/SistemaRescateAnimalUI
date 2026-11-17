using SistemaRescateAnimal.Datos;
using SistemaRescateAnimal.Models;
using System;
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

            Adopcion nuevaAdopcion = new Adopcion
            {
                IdAnimal = cmbAnimal.SelectedValue.ToString(),
                IdAdoptante = Convert.ToInt32(cmbAdoptante.SelectedValue),
                FechaAdopcion = dtpFechaAdopcion.Value,
                Observaciones = txtObservaciones.Text.Trim()
            };

            try
            {
                if (_adopcionDAO.RegistrarAdopcion(nuevaAdopcion))
                {
                    MessageBox.Show("¡Adopción registrada con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarCombos();

                    // Limpiamos los campos automáticamente tras guardar
                    cmbAnimal.SelectedIndex = -1;
                    cmbAdoptante.SelectedIndex = -1;
                    dtpFechaAdopcion.Value = DateTime.Now;
                    txtObservaciones.Clear();
                    cmbAnimal.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}