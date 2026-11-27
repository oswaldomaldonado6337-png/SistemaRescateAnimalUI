using SistemaRescateAnimal.Datos;
using SistemaRescateAnimal.Models;
using System;
using System.Data;
using System.Windows.Forms;

namespace SistemaRescateAnimalUI
{
    public partial class FrmHistorialMedico : Form
    {
        private readonly HistorialMedicoDAO _historialDAO;

        public FrmHistorialMedico()
        {
            InitializeComponent();
            _historialDAO = new HistorialMedicoDAO();
        }

        private void FrmHistorialMedico_Load(object sender, EventArgs e)
        {
            CargarComboAnimales();
            CargarGrid();
        }

        private void CargarComboAnimales()
        {
            try
            {
                DataTable dtAnimales = _historialDAO.ObtenerAnimalesParaCombo();
                cmbAnimal.DataSource = dtAnimales;
                // DisplayMember es lo que el usuario ve (el nombre)
                cmbAnimal.DisplayMember = "Nombre";
                // ValueMember es lo que guardamos en la base de datos (el IdAnimal oculto)
                cmbAnimal.ValueMember = "IdAnimal";
                // Dejamos el combo en blanco inicialmente
                cmbAnimal.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar lista de animales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrid()
        {
            try
            {
                dgvHistorial.DataSource = _historialDAO.ObtenerHistorialConDetalles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación para DropDownList y campos vacíos
            if (cmbAnimal.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtEnfermedad.Text) ||
                string.IsNullOrWhiteSpace(txtTratamiento.Text))
            {
                MessageBox.Show("Por favor, selecciona un animal y llena el diagnóstico y tratamiento.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idAnimalSeleccionado = cmbAnimal.SelectedValue.ToString();
            bool darDeAlta = chkDarDeAlta.Checked;

            HistorialMedico nuevaConsulta = new HistorialMedico
            {
                IdAnimal = idAnimalSeleccionado,
                IdUsuarioVeterinario = 1,
                FechaConsulta = dtpFechaActualizacion.Value,
                Diagnostico = txtEnfermedad.Text.Trim(),
                Tratamiento = txtTratamiento.Text.Trim()
            };

            try
            {
                if (_historialDAO.RegistrarConsulta(nuevaConsulta))
                {
                    if (darDeAlta)
                    {
                        AnimalDAO animalDAO = new AnimalDAO();
                        animalDAO.DarDeAltaMedica(idAnimalSeleccionado);
                        MessageBox.Show("Consulta médica registrada y animal dado de alta médica (Estable / Disponible).",
                                        "Alta Médica Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Consulta médica registrada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    chkDarDeAlta.Checked = false;
                    LimpiarFormulario();
                    CargarGrid(); // Refresca el DGV con la nueva consulta
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
            cmbAnimal.SelectedIndex = -1;
            dtpFechaActualizacion.Value = DateTime.Now;
            txtEnfermedad.Clear();
            txtTratamiento.Clear();
            cmbAnimal.Focus();
        }
    }
}