using System;
using System.Windows.Forms;

namespace SistemaRescateAnimalUI
{
    public partial class FrmPrincipal : Form
    {
        private IPanelCRUD? vistaActiva;

        public FrmPrincipal()
        {
            InitializeComponent();
            this.Load += (s, e) => CargarVistaInicial();
        }

        private void CargarVistaInicial()
        {
            AbrirFormularioEnContenedor(new FrmAnimalRescatado());
        }

        public void AbrirFormularioEnContenedor(Form formHijo)
        {
            Control contenedor = this.Controls.Find("pnlContenedorVistas", true).Length > 0
                ? this.Controls.Find("pnlContenedorVistas", true)[0]
                : this;

            if (contenedor.Controls.Count > 0)
                contenedor.Controls.Clear();

            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;

            contenedor.Controls.Add(formHijo);
            contenedor.Tag = formHijo;
            formHijo.Show();

            if (formHijo is IPanelCRUD panelCrud)
            {
                vistaActiva = panelCrud;
            }
        }

        private void btnMasterGuardar_Click(object sender, EventArgs e)
        {
            // Pasa el ID escrito arriba al formulario activo antes de guardar
            SincronizarIdConVista();
            vistaActiva?.EjecutarGuardar();
        }

        private void btnMasterBuscar_Click(object sender, EventArgs e)
        {
            if (vistaActiva != null)
            {
                vistaActiva.EjecutarBuscar(txtIdBusqueda.Text.Trim(), errorProvider1);
            }
        }

        private void btnMasterActualizar_Click(object sender, EventArgs e)
        {
            SincronizarIdConVista();
            vistaActiva?.EjecutarActualizar();
        }

        private void btnMasterEliminar_Click(object sender, EventArgs e)
        {
            if (vistaActiva != null)
            {
                SincronizarIdConVista();
                vistaActiva.EjecutarEliminar(statusStrip1);
            }
        }

        private void SincronizarIdConVista()
        {
            // Sincroniza la caja superior 'ID' con el control heredado 'txtId' del formulario activo
            if (vistaActiva is Form formActivo)
            {
                var txtIdHijo = formActivo.Controls.Find("txtId", true);
                if (txtIdHijo.Length > 0 && txtIdHijo[0] is TextBox tb)
                {
                    tb.Text = txtIdBusqueda.Text.Trim();
                }
            }
        }
    }
}