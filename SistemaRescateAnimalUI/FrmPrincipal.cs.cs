using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaRescateAnimalUI
{
    public partial class FrmPrincipal : Form
    {
        private IPanelCRUD? vistaActiva;

        public FrmPrincipal()
        {
            InitializeComponent();
            // Cuando carga la ventana, abre el formulario de animales de una vez
            this.Load += (s, e) => CargarVistaInicial();
        }

        private void CargarVistaInicial()
        {
            AbrirFormularioEnContenedor(new FrmAnimalRescatado());
        }

        public void AbrirFormularioEnContenedor(Form formHijo)
        {
            // Busca la caja/panel principal para meter la pantalla adentro
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

            // 1. Guarda los cambios de Nombre, Especie, Peso, etc., en memoria
            vistaActiva?.EjecutarActualizar();

            // 2. Abre el cuadro SaveFileDialog para exportar el archivo .txt (Requisito Actividad 3.3)
            if (vistaActiva is FrmAnimalRescatado frm)
            {
                frm.ExportarExpedienteTXT();
            }
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
            // Copia el ID del buscador de arriba al campo de texto del formulario
            if (vistaActiva is Form formActivo)
            {
                var txtIdHijo = formActivo.Controls.Find("txtId", true);
                if (txtIdHijo.Length > 0 && txtIdHijo[0] is TextBox tb)
                {
                    tb.Text = txtIdBusqueda.Text.Trim();
                }
            }
        }

        #region LO DE LA ACTIVIDAD 3.3 (MODAL, NO MODAL Y DIÁLOGOS)

        // Abre el formulario como modal: la ventana de atrás queda congelada hasta que cierres esta
        public void AbrirExpedienteModal()
        {
            using (FrmAnimalRescatado frmModal = new FrmAnimalRescatado())
            {
                frmModal.Text = "Edición de Expediente (Modal)";

                // ShowDialog bloquea todo lo demás mientras esté abierto
                DialogResult resultado = frmModal.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    MessageBox.Show("Se guardaron los cambios correctamente.",
                                    "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Abre el formulario normal: puedes picarle a la ventana de atrás sin problemas
        public void AbrirVisorNoModal()
        {
            FrmAnimalRescatado frmNoModal = new FrmAnimalRescatado();
            frmNoModal.Text = "Visor de Consultas (No Modal)";

            // Show deja usar varias ventanas al mismo tiempo
            frmNoModal.Show();
        }

        // Abre la ventanita para cambiar el color del fondo si el usuario quiere
        private void CambiarColorPanel_Click(object sender, EventArgs e)
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    this.BackColor = colorDialog.Color;
                }
            }
        }

        #endregion
    }
}