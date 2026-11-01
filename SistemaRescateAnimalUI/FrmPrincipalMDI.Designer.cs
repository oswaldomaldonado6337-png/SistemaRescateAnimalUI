namespace SistemaRescateAnimalUI
{
    partial class FrmPrincipalMDI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            módulosToolStripMenuItem = new ToolStripMenuItem();
            gestiónDeAnimalesToolStripMenuItem = new ToolStripMenuItem();
            ventanaToolStripMenuItem1 = new ToolStripMenuItem();
            cascadaToolStripMenuItem1 = new ToolStripMenuItem();
            mosaicoVerticalToolStripMenuItem1 = new ToolStripMenuItem();
            mosaicoHorizontalToolStripMenuItem1 = new ToolStripMenuItem();
            móduloSecundarioToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 418);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 32);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(1037, 25);
            toolStripStatusLabel1.Text = "FLORES MONTANO, Carlos Roberto - GONZALEZ ALVARADO, Alexa Michelle - MALDONADO LLAMAS, Oswaldo Daniel | Equipo 5";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { módulosToolStripMenuItem, ventanaToolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.MdiWindowListItem = módulosToolStripMenuItem;
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 33);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // módulosToolStripMenuItem
            // 
            módulosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gestiónDeAnimalesToolStripMenuItem, móduloSecundarioToolStripMenuItem });
            módulosToolStripMenuItem.Name = "módulosToolStripMenuItem";
            módulosToolStripMenuItem.Size = new Size(99, 29);
            módulosToolStripMenuItem.Text = "Módulos";
            // 
            // gestiónDeAnimalesToolStripMenuItem
            // 
            gestiónDeAnimalesToolStripMenuItem.Name = "gestiónDeAnimalesToolStripMenuItem";
            gestiónDeAnimalesToolStripMenuItem.Size = new Size(276, 34);
            gestiónDeAnimalesToolStripMenuItem.Text = "Gestión de Animales";
            gestiónDeAnimalesToolStripMenuItem.Click += gestiónDeAnimalesToolStripMenuItem_Click;
            // 
            // ventanaToolStripMenuItem1
            // 
            ventanaToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { cascadaToolStripMenuItem1, mosaicoVerticalToolStripMenuItem1, mosaicoHorizontalToolStripMenuItem1 });
            ventanaToolStripMenuItem1.Name = "ventanaToolStripMenuItem1";
            ventanaToolStripMenuItem1.Size = new Size(91, 29);
            ventanaToolStripMenuItem1.Text = "Ventana";
            // 
            // cascadaToolStripMenuItem1
            // 
            cascadaToolStripMenuItem1.Name = "cascadaToolStripMenuItem1";
            cascadaToolStripMenuItem1.Size = new Size(268, 34);
            cascadaToolStripMenuItem1.Text = "Cascada";
            cascadaToolStripMenuItem1.Click += cascadaToolStripMenuItem1_Click;
            // 
            // mosaicoVerticalToolStripMenuItem1
            // 
            mosaicoVerticalToolStripMenuItem1.Name = "mosaicoVerticalToolStripMenuItem1";
            mosaicoVerticalToolStripMenuItem1.Size = new Size(268, 34);
            mosaicoVerticalToolStripMenuItem1.Text = "Mosaico Vertical";
            mosaicoVerticalToolStripMenuItem1.Click += mosaicoVerticalToolStripMenuItem1_Click;
            // 
            // mosaicoHorizontalToolStripMenuItem1
            // 
            mosaicoHorizontalToolStripMenuItem1.Name = "mosaicoHorizontalToolStripMenuItem1";
            mosaicoHorizontalToolStripMenuItem1.Size = new Size(268, 34);
            mosaicoHorizontalToolStripMenuItem1.Text = "Mosaico Horizontal";
            mosaicoHorizontalToolStripMenuItem1.Click += mosaicoHorizontalToolStripMenuItem1_Click;
            // 
            // móduloSecundarioToolStripMenuItem
            // 
            móduloSecundarioToolStripMenuItem.Name = "móduloSecundarioToolStripMenuItem";
            móduloSecundarioToolStripMenuItem.Size = new Size(276, 34);
            móduloSecundarioToolStripMenuItem.Text = "Módulo Secundario";
            móduloSecundarioToolStripMenuItem.Click += móduloSecundarioToolStripMenuItem_Click;
            // 
            // FrmPrincipalMDI
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "FrmPrincipalMDI";
            Text = "FrmPrincipalMDI";
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem módulosToolStripMenuItem;
        private ToolStripMenuItem gestiónDeAnimalesToolStripMenuItem;
        private ToolStripMenuItem ventanaToolStripMenuItem1;
        private ToolStripMenuItem cascadaToolStripMenuItem1;
        private ToolStripMenuItem mosaicoVerticalToolStripMenuItem1;
        private ToolStripMenuItem mosaicoHorizontalToolStripMenuItem1;
        private ToolStripMenuItem móduloSecundarioToolStripMenuItem;
    }
}