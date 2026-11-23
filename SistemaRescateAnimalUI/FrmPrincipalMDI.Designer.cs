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
            lblUsuario = new ToolStripStatusLabel();
            lblRol = new ToolStripStatusLabel();
            lblHora = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            módulosToolStripMenuItem = new ToolStripMenuItem();
            gestiónDeAnimalesToolStripMenuItem = new ToolStripMenuItem();
            historialMedicoToolStripMenuItem = new ToolStripMenuItem();
            adopcionesToolStripMenuItem = new ToolStripMenuItem();
            registroDeAdoptantesToolStripMenuItem = new ToolStripMenuItem();
            listadoDeAdopcionesToolStripMenuItem = new ToolStripMenuItem();
            registrarAdopciónToolStripMenuItem = new ToolStripMenuItem();
            ventanaToolStripMenuItem1 = new ToolStripMenuItem();
            cascadaToolStripMenuItem1 = new ToolStripMenuItem();
            mosaicoVerticalToolStripMenuItem1 = new ToolStripMenuItem();
            mosaicoHorizontalToolStripMenuItem1 = new ToolStripMenuItem();
            ventasToolStripMenuItem = new ToolStripMenuItem();
            carritoDeComprasToolStripMenuItem = new ToolStripMenuItem();
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
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { módulosToolStripMenuItem, adopcionesToolStripMenuItem, ventanaToolStripMenuItem1, ventasToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.MdiWindowListItem = módulosToolStripMenuItem;
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 33);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // módulosToolStripMenuItem
            // 
            módulosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gestiónDeAnimalesToolStripMenuItem, historialMedicoToolStripMenuItem });
            módulosToolStripMenuItem.Name = "módulosToolStripMenuItem";
            módulosToolStripMenuItem.Size = new Size(100, 29);
            módulosToolStripMenuItem.Text = "Animales";
            módulosToolStripMenuItem.Click += módulosToolStripMenuItem_Click;
            // 
            // gestiónDeAnimalesToolStripMenuItem
            // 
            gestiónDeAnimalesToolStripMenuItem.Name = "gestiónDeAnimalesToolStripMenuItem";
            gestiónDeAnimalesToolStripMenuItem.Size = new Size(276, 34);
            gestiónDeAnimalesToolStripMenuItem.Text = "Gestión de Animales";
            gestiónDeAnimalesToolStripMenuItem.Click += gestiónDeAnimalesToolStripMenuItem_Click;
            // 
            // historialMedicoToolStripMenuItem
            // 
            historialMedicoToolStripMenuItem.Name = "historialMedicoToolStripMenuItem";
            historialMedicoToolStripMenuItem.Size = new Size(276, 34);
            historialMedicoToolStripMenuItem.Text = "Historial Médico";
            historialMedicoToolStripMenuItem.Click += historialMedicoToolStripMenuItem_Click;
            // 
            // adopcionesToolStripMenuItem
            // 
            adopcionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registroDeAdoptantesToolStripMenuItem, listadoDeAdopcionesToolStripMenuItem, registrarAdopciónToolStripMenuItem });
            adopcionesToolStripMenuItem.Name = "adopcionesToolStripMenuItem";
            adopcionesToolStripMenuItem.Size = new Size(123, 29);
            adopcionesToolStripMenuItem.Text = "Adopciones";
            // 
            // registroDeAdoptantesToolStripMenuItem
            // 
            registroDeAdoptantesToolStripMenuItem.Name = "registroDeAdoptantesToolStripMenuItem";
            registroDeAdoptantesToolStripMenuItem.Size = new Size(302, 34);
            registroDeAdoptantesToolStripMenuItem.Text = "Registro de Adoptantes";
            registroDeAdoptantesToolStripMenuItem.Click += registroDeAdoptantesToolStripMenuItem_Click;
            // 
            // listadoDeAdopcionesToolStripMenuItem
            // 
            listadoDeAdopcionesToolStripMenuItem.Name = "listadoDeAdopcionesToolStripMenuItem";
            listadoDeAdopcionesToolStripMenuItem.Size = new Size(302, 34);
            listadoDeAdopcionesToolStripMenuItem.Text = "Listado de Adopciones";
            listadoDeAdopcionesToolStripMenuItem.Click += listadoDeAdopcionesToolStripMenuItem_Click_1;
            // 
            // registrarAdopciónToolStripMenuItem
            // 
            registrarAdopciónToolStripMenuItem.Name = "registrarAdopciónToolStripMenuItem";
            registrarAdopciónToolStripMenuItem.Size = new Size(302, 34);
            registrarAdopciónToolStripMenuItem.Text = "Registrar Adopción";
            registrarAdopciónToolStripMenuItem.Click += registrarAdopciónToolStripMenuItem_Click;
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
            cascadaToolStripMenuItem1.Size = new Size(270, 34);
            cascadaToolStripMenuItem1.Text = "Cascada";
            cascadaToolStripMenuItem1.Click += cascadaToolStripMenuItem1_Click;
            // 
            // mosaicoVerticalToolStripMenuItem1
            // 
            mosaicoVerticalToolStripMenuItem1.Name = "mosaicoVerticalToolStripMenuItem1";
            mosaicoVerticalToolStripMenuItem1.Size = new Size(270, 34);
            mosaicoVerticalToolStripMenuItem1.Text = "Mosaico Vertical";
            mosaicoVerticalToolStripMenuItem1.Click += mosaicoVerticalToolStripMenuItem1_Click;
            // 
            // mosaicoHorizontalToolStripMenuItem1
            // 
            mosaicoHorizontalToolStripMenuItem1.Name = "mosaicoHorizontalToolStripMenuItem1";
            mosaicoHorizontalToolStripMenuItem1.Size = new Size(270, 34);
            mosaicoHorizontalToolStripMenuItem1.Text = "Mosaico Horizontal";
            mosaicoHorizontalToolStripMenuItem1.Click += mosaicoHorizontalToolStripMenuItem1_Click;
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { carritoDeComprasToolStripMenuItem });
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(80, 29);
            ventasToolStripMenuItem.Text = "Ventas";
            // 
            // carritoDeComprasToolStripMenuItem
            // 
            carritoDeComprasToolStripMenuItem.Name = "carritoDeComprasToolStripMenuItem";
            carritoDeComprasToolStripMenuItem.Size = new Size(270, 34);
            carritoDeComprasToolStripMenuItem.Text = "Carrito de Compras";
            carritoDeComprasToolStripMenuItem.Click += carritoDeComprasToolStripMenuItem_Click;
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
            Text = "Sistema de Rescate Animal";
            WindowState = FormWindowState.Maximized;
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
        private ToolStripMenuItem historialMedicoToolStripMenuItem;
        private ToolStripStatusLabel lblUsuario;
        private ToolStripStatusLabel lblRol;
        private ToolStripStatusLabel lblHora;
        private ToolStripMenuItem adopcionesToolStripMenuItem;
        private ToolStripMenuItem registroDeAdoptantesToolStripMenuItem;
        private ToolStripMenuItem listadoDeAdopcionesToolStripMenuItem;
        private ToolStripMenuItem registrarAdopciónToolStripMenuItem;
        private ToolStripMenuItem ventasToolStripMenuItem;
        private ToolStripMenuItem carritoDeComprasToolStripMenuItem;
    }
}