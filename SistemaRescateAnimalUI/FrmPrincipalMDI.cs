using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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
        // ALGORITMO DE INSTANCIA ÚNICA (MÓDULO ANIMALES)
        // ============================================================================
        private void gestiónDeAnimalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form hijo in this.MdiChildren)
            {
                if (hijo is FrmAnimalRescatado)
                {
                    if (hijo.WindowState == FormWindowState.Minimized)
                    {
                        hijo.WindowState = FormWindowState.Normal;
                    }
                    hijo.Activate();
                    return;
                }
            }

            FrmAnimalRescatado frmAnimal = new FrmAnimalRescatado();
            frmAnimal.MdiParent = this;
            frmAnimal.Show();
        }

        private void móduloSecundarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form hijo in this.MdiChildren)
            {
                if (hijo is Form1)
                {
                    if (hijo.WindowState == FormWindowState.Minimized)
                        hijo.WindowState = FormWindowState.Normal;

                    hijo.Activate();
                    return;
                }
            }

            Form1 f1 = new Form1();
            f1.MdiParent = this;
            f1.Show();
        }

        private void módulosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        // EVENTO DE ARRANQUE (CARGA DE SESIÓN Y SEGURIDAD POR ROLES)
        private void FrmPrincipalMDI_Load(object sender, EventArgs e)
        {
            // 1. Cargamos datos de la sesión estática en el StatusStrip
            lblUsuario.Text = "Usuario: " + SesionSistema.UsuarioActivo;
            lblRol.Text = "Perfil: " + SesionSistema.RolActivo;
            lblHora.Text = "Conexión: " + SesionSistema.HoraInicioSesion.ToString("HH:mm:ss");

            // 2. Evaluamos el rol del usuario autenticado para restringir accesos
            if (SesionSistema.RolActivo == "Operador")
            {
                // El Operador no puede ver el Módulo Secundario
                móduloSecundarioToolStripMenuItem.Visible = false;
            }
            else if (SesionSistema.RolActivo == "Invitado")
            {
                // El Invitado no tiene acceso a las opciones del menú Módulos
                módulosToolStripMenuItem.Enabled = false;
            }
        }
    }
}