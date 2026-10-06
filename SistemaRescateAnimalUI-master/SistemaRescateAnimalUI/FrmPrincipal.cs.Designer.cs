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
            this.components = new System.ComponentModel.Container();
            this.pnlBarraHerramientas = new System.Windows.Forms.FlowLayoutPanel();
            this.lblId = new System.Windows.Forms.Label();
            this.txtIdBusqueda = new System.Windows.Forms.TextBox();
            this.btnMasterBuscar = new System.Windows.Forms.Button();
            this.btnMasterGuardar = new System.Windows.Forms.Button();
            this.btnMasterActualizar = new System.Windows.Forms.Button();
            this.btnMasterEliminar = new System.Windows.Forms.Button();
            this.pnlContenedorVistas = new System.Windows.Forms.Panel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pnlBarraHerramientas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBarraHerramientas
            // 
            this.pnlBarraHerramientas.AutoSize = true;
            this.pnlBarraHerramientas.Controls.Add(this.lblId);
            this.pnlBarraHerramientas.Controls.Add(this.txtIdBusqueda);
            this.pnlBarraHerramientas.Controls.Add(this.btnMasterBuscar);
            this.pnlBarraHerramientas.Controls.Add(this.btnMasterGuardar);
            this.pnlBarraHerramientas.Controls.Add(this.btnMasterActualizar);
            this.pnlBarraHerramientas.Controls.Add(this.btnMasterEliminar);
            this.pnlBarraHerramientas.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBarraHerramientas.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBarraHerramientas.Size = new System.Drawing.Size(900, 50);
            this.pnlBarraHerramientas.TabIndex = 0;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lblId.Text = "ID:";
            // 
            // txtIdBusqueda
            // 
            this.txtIdBusqueda.Size = new System.Drawing.Size(120, 27);
            // 
            // btnMasterBuscar
            // 
            this.btnMasterBuscar.Size = new System.Drawing.Size(100, 30);
            this.btnMasterBuscar.Text = "Buscar";
            this.btnMasterBuscar.UseVisualStyleBackColor = true;
            this.btnMasterBuscar.Click += new System.EventHandler(this.btnMasterBuscar_Click);
            // 
            // btnMasterGuardar
            // 
            this.btnMasterGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnMasterGuardar.Text = "Guardar";
            this.btnMasterGuardar.UseVisualStyleBackColor = true;
            this.btnMasterGuardar.Click += new System.EventHandler(this.btnMasterGuardar_Click);
            // 
            // btnMasterActualizar
            // 
            this.btnMasterActualizar.Size = new System.Drawing.Size(100, 30);
            this.btnMasterActualizar.Text = "Actualizar";
            this.btnMasterActualizar.UseVisualStyleBackColor = true;
            this.btnMasterActualizar.Click += new System.EventHandler(this.btnMasterActualizar_Click);
            // 
            // btnMasterEliminar
            // 
            this.btnMasterEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnMasterEliminar.Text = "Eliminar";
            this.btnMasterEliminar.UseVisualStyleBackColor = true;
            this.btnMasterEliminar.Click += new System.EventHandler(this.btnMasterEliminar_Click);
            // 
            // pnlContenedorVistas
            // 
            this.pnlContenedorVistas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedorVistas.Location = new System.Drawing.Point(0, 50);
            this.pnlContenedorVistas.Name = "pnlContenedorVistas";
            this.pnlContenedorVistas.Size = new System.Drawing.Size(900, 500);
            this.pnlContenedorVistas.TabIndex = 1;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 528);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(900, 22);
            this.statusStrip1.TabIndex = 2;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.pnlContenedorVistas);
            this.Controls.Add(this.pnlBarraHerramientas);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Rescate Animal - Formulario Principal";
            this.pnlBarraHerramientas.ResumeLayout(false);
            this.pnlBarraHerramientas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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