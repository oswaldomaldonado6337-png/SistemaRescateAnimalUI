using SistemaRescateAnimal.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaRescateAnimalUI
{
    public partial class FrmListadoAdopciones : Form
    {
        public FrmListadoAdopciones()
        {
            InitializeComponent();
        }

        private void FrmListadoAdopciones_Load(object sender, EventArgs e)
        {
            // Al abrir la ventana, carga por defecto los datos de MariaDB
            CargarDatosMariaDB();
        }

        private void btnCargarMaria_Click(object sender, EventArgs e)
        {
            CargarDatosMariaDB();
        }

        private void btnCargarMongo_Click(object sender, EventArgs e)
        {
            try
            {
                AnimalDAO _animalDAO = new AnimalDAO();

                // Carga la tabla usando el pipeline $lookup de MongoDB Atlas
                dgvAdopciones.DataSource = _animalDAO.ObtenerAdopcionesConLookupMongo();
                dgvAdopciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                MessageBox.Show("Listado relacional NoSQL ($lookup) cargado correctamente.", "Éxito MongoDB", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en MongoDB: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosMariaDB()
        {
            try
            {
                AnimalDAO _animalDAO = new AnimalDAO();

                // Carga la tabla con el INNER JOIN de MariaDB
                dgvAdopciones.DataSource = _animalDAO.ObtenerAdopcionesConDetalles();
                dgvAdopciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos de MariaDB: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}