namespace SistemaRescateAnimalUI
{
    partial class FrmPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            pnlBarraHerramientas = new FlowLayoutPanel();
            statusStrip1 = new StatusStrip();
            menuStrip1 = new MenuStrip();
            mantenimientoToolStripMenuItem = new ToolStripMenuItem();
            animalesRescatadosToolStripMenuItem = new ToolStripMenuItem();
            pnlBarraHerramientas.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBarraHerramientas
            // 
            pnlBarraHerramientas.AutoSize = true;
            pnlBarraHerramientas.Controls.Add(menuStrip1);
            pnlBarraHerramientas.Dock = DockStyle.Top;
            pnlBarraHerramientas.Location = new Point(0, 0);
            pnlBarraHerramientas.Margin = new Padding(4);
            pnlBarraHerramientas.Name = "pnlBarraHerramientas";
            pnlBarraHerramientas.Padding = new Padding(12);
            pnlBarraHerramientas.Size = new Size(1125, 57);
            pnlBarraHerramientas.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Location = new Point(0, 666);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 18, 0);
            statusStrip1.Size = new Size(1125, 22);
            statusStrip1.TabIndex = 2;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { mantenimientoToolStripMenuItem });
            menuStrip1.Location = new Point(12, 12);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(336, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // mantenimientoToolStripMenuItem
            // 
            mantenimientoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { animalesRescatadosToolStripMenuItem });
            mantenimientoToolStripMenuItem.Name = "mantenimientoToolStripMenuItem";
            mantenimientoToolStripMenuItem.Size = new Size(148, 29);
            mantenimientoToolStripMenuItem.Text = "Mantenimiento";
            // 
            // animalesRescatadosToolStripMenuItem
            // 
            animalesRescatadosToolStripMenuItem.Name = "animalesRescatadosToolStripMenuItem";
            animalesRescatadosToolStripMenuItem.Size = new Size(280, 34);
            animalesRescatadosToolStripMenuItem.Text = "Animales Rescatados";
            animalesRescatadosToolStripMenuItem.Click += animalesRescatadosToolStripMenuItem_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 688);
            Controls.Add(pnlBarraHerramientas);
            Controls.Add(statusStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema Rescate Animal - Formulario Principal";
            Load += FrmPrincipal_Load;
            pnlBarraHerramientas.ResumeLayout(false);
            pnlBarraHerramientas.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlBarraHerramientas;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem mantenimientoToolStripMenuItem;
        private ToolStripMenuItem animalesRescatadosToolStripMenuItem;
    }
}