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
            components = new System.ComponentModel.Container();
            pnlBarraHerramientas = new FlowLayoutPanel();
            lblId = new Label();
            txtIdBusqueda = new TextBox();
            btnMasterBuscar = new Button();
            btnMasterGuardar = new Button();
            btnMasterActualizar = new Button();
            btnMasterEliminar = new Button();
            pnlContenedorVistas = new Panel();
            errorProvider1 = new ErrorProvider(components);
            statusStrip1 = new StatusStrip();
            pnlBarraHerramientas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // pnlBarraHerramientas
            // 
            pnlBarraHerramientas.AutoSize = true;
            pnlBarraHerramientas.Controls.Add(lblId);
            pnlBarraHerramientas.Controls.Add(txtIdBusqueda);
            pnlBarraHerramientas.Controls.Add(btnMasterBuscar);
            pnlBarraHerramientas.Controls.Add(btnMasterGuardar);
            pnlBarraHerramientas.Controls.Add(btnMasterActualizar);
            pnlBarraHerramientas.Controls.Add(btnMasterEliminar);
            pnlBarraHerramientas.Dock = DockStyle.Top;
            pnlBarraHerramientas.Location = new Point(0, 0);
            pnlBarraHerramientas.Margin = new Padding(4, 4, 4, 4);
            pnlBarraHerramientas.Name = "pnlBarraHerramientas";
            pnlBarraHerramientas.Padding = new Padding(12, 12, 12, 12);
            pnlBarraHerramientas.Size = new Size(1125, 70);
            pnlBarraHerramientas.TabIndex = 0;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(16, 12);
            lblId.Margin = new Padding(4, 0, 4, 0);
            lblId.Name = "lblId";
            lblId.Padding = new Padding(0, 8, 0, 0);
            lblId.Size = new Size(34, 33);
            lblId.TabIndex = 0;
            lblId.Text = "ID:";
            // 
            // txtIdBusqueda
            // 
            txtIdBusqueda.Location = new Point(58, 16);
            txtIdBusqueda.Margin = new Padding(4, 4, 4, 4);
            txtIdBusqueda.Name = "txtIdBusqueda";
            txtIdBusqueda.Size = new Size(149, 31);
            txtIdBusqueda.TabIndex = 1;
            // 
            // btnMasterBuscar
            // 
            btnMasterBuscar.Location = new Point(215, 16);
            btnMasterBuscar.Margin = new Padding(4, 4, 4, 4);
            btnMasterBuscar.Name = "btnMasterBuscar";
            btnMasterBuscar.Size = new Size(125, 38);
            btnMasterBuscar.TabIndex = 2;
            btnMasterBuscar.Text = "Buscar";
            btnMasterBuscar.UseVisualStyleBackColor = true;
            btnMasterBuscar.Click += btnMasterBuscar_Click;
            // 
            // btnMasterGuardar
            // 
            btnMasterGuardar.Location = new Point(348, 16);
            btnMasterGuardar.Margin = new Padding(4, 4, 4, 4);
            btnMasterGuardar.Name = "btnMasterGuardar";
            btnMasterGuardar.Size = new Size(125, 38);
            btnMasterGuardar.TabIndex = 3;
            btnMasterGuardar.Text = "Guardar";
            btnMasterGuardar.UseVisualStyleBackColor = true;
            btnMasterGuardar.Click += btnMasterGuardar_Click;
            // 
            // btnMasterActualizar
            // 
            btnMasterActualizar.Location = new Point(481, 16);
            btnMasterActualizar.Margin = new Padding(4, 4, 4, 4);
            btnMasterActualizar.Name = "btnMasterActualizar";
            btnMasterActualizar.Size = new Size(125, 38);
            btnMasterActualizar.TabIndex = 4;
            btnMasterActualizar.Text = "Actualizar";
            btnMasterActualizar.UseVisualStyleBackColor = true;
            btnMasterActualizar.Click += btnMasterActualizar_Click;
            // 
            // btnMasterEliminar
            // 
            btnMasterEliminar.Location = new Point(614, 16);
            btnMasterEliminar.Margin = new Padding(4, 4, 4, 4);
            btnMasterEliminar.Name = "btnMasterEliminar";
            btnMasterEliminar.Size = new Size(125, 38);
            btnMasterEliminar.TabIndex = 5;
            btnMasterEliminar.Text = "Eliminar";
            btnMasterEliminar.UseVisualStyleBackColor = true;
            btnMasterEliminar.Click += btnMasterEliminar_Click;
            // 
            // pnlContenedorVistas
            // 
            pnlContenedorVistas.Dock = DockStyle.Fill;
            pnlContenedorVistas.Location = new Point(0, 70);
            pnlContenedorVistas.Margin = new Padding(4, 4, 4, 4);
            pnlContenedorVistas.Name = "pnlContenedorVistas";
            pnlContenedorVistas.Size = new Size(1125, 596);
            pnlContenedorVistas.TabIndex = 1;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
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
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 688);
            Controls.Add(pnlContenedorVistas);
            Controls.Add(pnlBarraHerramientas);
            Controls.Add(statusStrip1);
            Margin = new Padding(4, 4, 4, 4);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema Rescate Animal - Formulario Principal";
            pnlBarraHerramientas.ResumeLayout(false);
            pnlBarraHerramientas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnlBarraHerramientas;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtIdBusqueda;
        private System.Windows.Forms.Button btnMasterBuscar;
        private System.Windows.Forms.Button btnMasterGuardar;
        private System.Windows.Forms.Button btnMasterActualizar;
        private System.Windows.Forms.Button btnMasterEliminar;
        private System.Windows.Forms.Panel pnlContenedorVistas;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}