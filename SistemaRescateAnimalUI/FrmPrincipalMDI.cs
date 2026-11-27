using System;
using System.Windows.Forms;
using SistemaRescateAnimalUI.Models;

namespace SistemaRescateAnimalUI
{
    public partial class FrmPrincipalMDI : Form
    {
        public FrmPrincipalMDI()
        {
            InitializeComponent();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        // ============================================================================
        // EVENTOS DEL MENÚ VENTANA (LAYOUTS MDI)
        // ============================================================================
        private void cascadaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mosaicoVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mosaicoHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void cascadaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void mosaicoVerticalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void mosaicoHorizontalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        // ============================================================================
        // MÉTODO GENÉRICO PARA INSTANCIA ÚNICA (EVITA VENTANAS DUPLICADAS)
        // ============================================================================
        private void AbrirFormularioUnico<T>() where T : Form, new()
        {
            foreach (Form hijo in this.MdiChildren)
            {
                if (hijo is T)
                {
                    if (hijo.WindowState == FormWindowState.Minimized)
                        hijo.WindowState = FormWindowState.Normal;

                    hijo.Activate();
                    return;
                }
            }

            T nuevoFormulario = new T();
            nuevoFormulario.MdiParent = this;
            nuevoFormulario.Show();
        }

        // ============================================================================
        // EVENTOS DE APERTURA DE MÓDULOS
        // ============================================================================
        private void gestiónDeAnimalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioUnico<FrmAnimalRescatado>();
        }

        private void listadoDeAdopcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioUnico<FrmListadoAdopciones>();
        }

        private void listadoDeAdopcionesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioUnico<FrmListadoAdopciones>();
        }

        private void registrarAdopciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioUnico<FrmRegistroAdopcion>();
        }

        private void registroDeAdoptantesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioUnico<FrmAdoptantes>();
        }

        private void historialMedicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioUnico<FrmHistorialMedico>();
        }

        private void módulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        // ============================================================================
        // EVENTO DE ARRANQUE (CARGA DE SESIÓN Y SEGURIDAD POR ROLES)
        // ============================================================================
        private void FrmPrincipalMDI_Load(object sender, EventArgs e)
        {
            // 1. Cargamos datos de la sesión estática en el StatusStrip
            lblUsuario.Text = "Usuario: " + SesionSistema.UsuarioActivo;
            lblRol.Text = "Perfil: " + SesionSistema.RolActivo;
            lblHora.Text = "Conexión: " + SesionSistema.HoraInicioSesion.ToString("HH:mm:ss");

            // 2. Evaluamos el rol del usuario autenticado para restringir accesos 
            if (SesionSistema.RolActivo == "Voluntario")
            {
                // El Voluntario (Usuario Base) tiene restringido el historial médico y el módulo de ventas
                historialMedicoToolStripMenuItem.Visible = false;
                ventasToolStripMenuItem.Visible = false;
            }
        }

        private void carritoDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVentas frm = new FrmVentas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show(
                "¿Deseas cerrar la sesión actual?",
                "Cerrar Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resp == DialogResult.Yes)
            {
                // Cierra cualquier ventana abierta
                foreach (Form hijo in this.MdiChildren)
                {
                    hijo.Close();
                }

                // Limpia los datos de sesión 
                SesionSistema.UsuarioActivo = string.Empty;
                SesionSistema.RolActivo = string.Empty;

                // Oculta todo y vuelve al inicio de sesion
                this.Hide();
                FrmLogin login = new FrmLogin();
                login.FormClosed += (s, args) => this.Close();
                login.Show();
            }
        }
    }
}