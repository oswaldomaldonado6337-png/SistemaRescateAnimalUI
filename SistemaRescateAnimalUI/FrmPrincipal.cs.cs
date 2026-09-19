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
        }

        public void AbrirFormularioEnContenedor(Form formHijo)
        {
            if (pnlContenedorVistas.Controls.Count > 0)
                pnlContenedorVistas.Controls.RemoveAt(0);

            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;

            pnlContenedorVistas.Controls.Add(formHijo);
            pnlContenedorVistas.Tag = formHijo;
            formHijo.Show();

            if (formHijo is IPanelCRUD panelCrud)
            {
                vistaActiva = panelCrud;
            }
        }

        private void btnMasterGuardar_Click(object sender, EventArgs e)
        {
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
            vistaActiva?.EjecutarActualizar();
        }

        private void btnMasterEliminar_Click(object sender, EventArgs e)
        {
            if (vistaActiva != null)
            {
                vistaActiva.EjecutarEliminar(statusStrip1);
            }
        }
    }
}