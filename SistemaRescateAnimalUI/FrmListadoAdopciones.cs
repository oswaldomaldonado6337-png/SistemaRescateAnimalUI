using SistemaRescateAnimal.Datos;
using SistemaRescateAnimal.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SistemaRescateAnimalUI
{
    public partial class FrmListadoAdopciones : Form
    {
        private readonly AdopcionDAO _adopcionDAO;
        private List<AdopcionDetalle> _listaCompletaAdopciones;

        public FrmListadoAdopciones()
        {
            InitializeComponent();
            _adopcionDAO = new AdopcionDAO();
            _listaCompletaAdopciones = new List<AdopcionDetalle>();
        }

        private void FrmListadoAdopciones_Load(object sender, EventArgs e)
        {
            InicializarFiltros();
            CargarDatosDesdeBD();
        }

        private void InicializarFiltros()
        {
            cmbFiltroEstado.Items.Clear();
            cmbFiltroEstado.Items.AddRange(new object[] { "Todos", "Vigente", "Finalizado", "Cancelado" });
            cmbFiltroEstado.SelectedIndex = 0;

            chkFiltrarFecha.Checked = false;
            dtpFecha.Enabled = false;
            dtpFecha.Value = DateTime.Today;
        }

        private void CargarDatosDesdeBD()
        {
            try
            {
                _listaCompletaAdopciones = _adopcionDAO.ObtenerListadoAdopciones();
                AplicarFiltros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el listado de adopciones:\n" + ex.Message,
                    "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AplicarFiltros()
        {
            if (_listaCompletaAdopciones == null) return;

            IEnumerable<AdopcionDetalle> consulta = _listaCompletaAdopciones;

            //  Filtramos por Folio, Animal o Adoptante
            string textoBusqueda = txtBuscar.Text.Trim();
            if (!string.IsNullOrEmpty(textoBusqueda))
            {
                consulta = consulta.Where(a =>
                    (a.Folio != null && a.Folio.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (a.Animal != null && a.Animal.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0) ||
                    (a.Adoptante != null && a.Adoptante.IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0));
            }

            // Filtro por Estado
            if (cmbFiltroEstado.SelectedItem != null)
            {
                string estadoSeleccionado = cmbFiltroEstado.SelectedItem.ToString();
                if (estadoSeleccionado != "Todos")
                {
                    consulta = consulta.Where(a =>
                        a.Estado != null && a.Estado.Equals(estadoSeleccionado, StringComparison.OrdinalIgnoreCase));
                }
            }

            // Filtro por Fecha exacta
            if (chkFiltrarFecha.Checked)
            {
                DateTime fechaSeleccionada = dtpFecha.Value.Date;
                consulta = consulta.Where(a => a.FechaAdopcion.Date == fechaSeleccionada);
            }

            dgvAdopciones.DataSource = null;
            dgvAdopciones.DataSource = consulta.ToList();
            FormatearColumnasGrid();
        }

        private void FormatearColumnasGrid()
        {
            if (dgvAdopciones.Columns.Count == 0) return;

            if (dgvAdopciones.Columns["IdAnimal"] != null)
                dgvAdopciones.Columns["IdAnimal"].Visible = false;

            if (dgvAdopciones.Columns["IdAdopcion"] != null)
            {
                dgvAdopciones.Columns["IdAdopcion"].HeaderText = "ID";
                dgvAdopciones.Columns["IdAdopcion"].Width = 45;
            }

            if (dgvAdopciones.Columns["FechaAdopcion"] != null)
            {
                dgvAdopciones.Columns["FechaAdopcion"].HeaderText = "Fecha";
                dgvAdopciones.Columns["FechaAdopcion"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }

            if (dgvAdopciones.Columns["Monto"] != null)
            {
                dgvAdopciones.Columns["Monto"].HeaderText = "Monto / Donación";
                dgvAdopciones.Columns["Monto"].DefaultCellStyle.Format = "C2";
                dgvAdopciones.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvAdopciones.Columns["FormaPago"] != null)
                dgvAdopciones.Columns["FormaPago"].HeaderText = "Forma de Pago";

            foreach (DataGridViewRow fila in dgvAdopciones.Rows)
            {
                string estado = fila.Cells["Estado"].Value?.ToString();
                if (estado == "Cancelado")
                {
                    fila.DefaultCellStyle.ForeColor = Color.Firebrick;
                }
                else if (estado == "Finalizado")
                {
                    fila.DefaultCellStyle.ForeColor = Color.DarkGreen;
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void cmbFiltroEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            AplicarFiltros();
        }

        private void chkFiltrarFecha_CheckedChanged(object sender, EventArgs e)
        {
            dtpFecha.Enabled = chkFiltrarFecha.Checked;
            AplicarFiltros();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (chkFiltrarFecha.Checked)
            {
                AplicarFiltros();
            }
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            cmbFiltroEstado.SelectedIndex = 0;
            chkFiltrarFecha.Checked = false;
            dtpFecha.Value = DateTime.Today;
            AplicarFiltros();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarDatosDesdeBD();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            ProcesarCambioEstado("Finalizado");
        }

        private void btnCancelarAdopcion_Click(object sender, EventArgs e)
        {
            ProcesarCambioEstado("Cancelado");
        }

        private void ProcesarCambioEstado(string nuevoEstado)
        {
            if (dgvAdopciones.CurrentRow == null || !(dgvAdopciones.CurrentRow.DataBoundItem is AdopcionDetalle seleccion))
            {
                MessageBox.Show("Por favor, selecciona primero una adopción de la tabla.",
                    "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (seleccion.Estado.Equals(nuevoEstado, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show($"La adopción con folio {seleccion.Folio} ya se encuentra en estado '{nuevoEstado}'.",
                    "Sin cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (seleccion.Estado.Equals("Cancelado", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("No se puede modificar una adopción que ya fue cancelada, ya que el animal regresó a disponibilidad.",
                    "Operación no permitida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mensajeConfirmacion = nuevoEstado == "Cancelado"
                ? $"¿Estás seguro de CANCELAR la adopción {seleccion.Folio}?\n\nEl animal '{seleccion.Animal}' volverá automáticamente a estado 'Disponible' para futuras adopciones."
                : $"¿Confirmas marcar como FINALIZADA la adopción {seleccion.Folio} ({seleccion.Animal} - {seleccion.Adoptante})?";

            DialogResult respuesta = MessageBox.Show(mensajeConfirmacion, "Confirmar cambio de estado",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes) return;

            try
            {
                bool actualizado = _adopcionDAO.CambiarEstadoAdopcion(seleccion.IdAdopcion, seleccion.IdAnimal, nuevoEstado);
                if (actualizado)
                {
                    MessageBox.Show($"Estado actualizado a '{nuevoEstado}' correctamente.",
                        "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarDatosDesdeBD();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al actualizar el estado:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}