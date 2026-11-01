using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

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

        // En caso de que el diseñador vincule la versión con sufijo '1'
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
            // 1. Recorremos la colección de ventanas secundarias abiertas
            foreach (Form hijo in this.MdiChildren)
            {
                // 2. Evaluamos si el tipo del formulario ya existe
                if (hijo is FrmAnimalRescatado)
                {
                    // Restauramos si está minimizado
                    if (hijo.WindowState == FormWindowState.Minimized)
                    {
                        hijo.WindowState = FormWindowState.Normal;
                    }

                    // Enfocamos la ventana existente
                    hijo.Activate();

                    // Abortamos la creación de duplicados
                    return;
                }
            }

            // 3. Si no existe, creamos la nueva instancia en el contenedor
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
    }
}