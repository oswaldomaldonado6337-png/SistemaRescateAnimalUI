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
            lblAutores = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            módulosToolStripMenuItem = new ToolStripMenuItem();
            gestiónDeAnimalesToolStripMenuItem = new ToolStripMenuItem();
            móduloSecundarioToolStripMenuItem = new ToolStripMenuItem();
            ventanaToolStripMenuItem1 = new ToolStripMenuItem();
            cascadaToolStripMenuItem1 = new ToolStripMenuItem();
            mosaicoVerticalToolStripMenuItem1 = new ToolStripMenuItem();
            mosaicoHorizontalToolStripMenuItem1 = new ToolStripMenuItem();
            lblUsuario = new ToolStripStatusLabel();
            lblRol = new ToolStripStatusLabel();
            lblHora = new ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblAutores, lblUsuario, lblRol, lblHora });
            statusStrip1.Location = new Point(0, 418);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 32);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblAutores
            // 
            lblAutores.Name = "lblAutores";
            lblAutores.Size = new Size(1037, 25);
            lblAutores.Text = "FLORES MONTANO, Carlos Roberto - GONZALEZ ALVARADO, Alexa Michelle - MALDONADO LLAMAS, Oswaldo Daniel | Equipo 5";
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
            módulosToolStripMenuItem.Click += módulosToolStripMenuItem_Click;
            // 
            // gestiónDeAnimalesToolStripMenuItem
            // 
            gestiónDeAnimalesToolStripMenuItem.Name = "gestiónDeAnimalesToolStripMenuItem";
            gestiónDeAnimalesToolStripMenuItem.Size = new Size(276, 34);
            gestiónDeAnimalesToolStripMenuItem.Text = "Gestión de Animales";
            gestiónDeAnimalesToolStripMenuItem.Click += gestiónDeAnimalesToolStripMenuItem_Click;
            // 
            // móduloSecundarioToolStripMenuItem
            // 
            móduloSecundarioToolStripMenuItem.Name = "móduloSecundarioToolStripMenuItem";
            móduloSecundarioToolStripMenuItem.Size = new Size(276, 34);
            móduloSecundarioToolStripMenuItem.Text = "Módulo Secundario";
            móduloSecundarioToolStripMenuItem.Click += móduloSecundarioToolStripMenuItem_Click;
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
            // lblUsuario
            // 
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(76, 25);
            lblUsuario.Text = "Usuario:";
            // 
            // lblRol
            // 
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(54, 25);
            lblRol.Text = "Perfil:";
            // 
            // lblHora
            // 
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(90, 25);
            lblHora.Text = "Conexión:";
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
            Load += FrmPrincipalMDI_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblAutores;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem módulosToolStripMenuItem;
        private ToolStripMenuItem gestiónDeAnimalesToolStripMenuItem;
        private ToolStripMenuItem ventanaToolStripMenuItem1;
        private ToolStripMenuItem cascadaToolStripMenuItem1;
        private ToolStripMenuItem mosaicoVerticalToolStripMenuItem1;
        private ToolStripMenuItem mosaicoHorizontalToolStripMenuItem1;
        private ToolStripMenuItem móduloSecundarioToolStripMenuItem;
        private ToolStripStatusLabel lblUsuario;
        private ToolStripStatusLabel lblRol;
        private ToolStripStatusLabel lblHora;
    }
}