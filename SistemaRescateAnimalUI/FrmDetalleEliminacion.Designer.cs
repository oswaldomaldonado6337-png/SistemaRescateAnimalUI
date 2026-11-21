namespace SistemaRescateAnimalUI
{
    partial class FrmDetalleEliminacion
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
            grpDatos = new GroupBox();
            chkActivo = new CheckBox();
            txtFecha = new TextBox();
            txtPeso = new TextBox();
            txtEspecie = new TextBox();
            txtNombre = new TextBox();
            txtId = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            grpFoto = new GroupBox();
            pbxFoto = new PictureBox();
            btnLogico = new Button();
            btnFisico = new Button();
            btnCancelar = new Button();
            lblAutoria = new Label();
            grpDatos.SuspendLayout();
            grpFoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxFoto).BeginInit();
            SuspendLayout();
            // 
            // grpDatos
            // 
            grpDatos.Controls.Add(chkActivo);
            grpDatos.Controls.Add(txtFecha);
            grpDatos.Controls.Add(txtPeso);
            grpDatos.Controls.Add(txtEspecie);
            grpDatos.Controls.Add(txtNombre);
            grpDatos.Controls.Add(txtId);
            grpDatos.Controls.Add(label5);
            grpDatos.Controls.Add(label4);
            grpDatos.Controls.Add(label3);
            grpDatos.Controls.Add(label2);
            grpDatos.Controls.Add(label1);
            grpDatos.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            grpDatos.Location = new Point(15, 58);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(365, 250);
            grpDatos.TabIndex = 0;
            grpDatos.TabStop = false;
            grpDatos.Text = "Datos del Animal (Solo Lectura)";
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Enabled = false;
            chkActivo.Location = new Point(135, 210);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(235, 29);
            chkActivo.TabIndex = 1;
            chkActivo.Text = "Registro Activo (EsActivo)";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // txtFecha
            // 
            txtFecha.Location = new Point(154, 183);
            txtFecha.Name = "txtFecha";
            txtFecha.ReadOnly = true;
            txtFecha.Size = new Size(210, 31);
            txtFecha.TabIndex = 5;
            txtFecha.TabStop = false;
            // 
            // txtPeso
            // 
            txtPeso.Location = new Point(153, 146);
            txtPeso.Name = "txtPeso";
            txtPeso.ReadOnly = true;
            txtPeso.Size = new Size(210, 31);
            txtPeso.TabIndex = 4;
            txtPeso.TabStop = false;
            // 
            // txtEspecie
            // 
            txtEspecie.Location = new Point(153, 109);
            txtEspecie.Name = "txtEspecie";
            txtEspecie.ReadOnly = true;
            txtEspecie.Size = new Size(210, 31);
            txtEspecie.TabIndex = 3;
            txtEspecie.TabStop = false;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(153, 72);
            txtNombre.Name = "txtNombre";
            txtNombre.ReadOnly = true;
            txtNombre.Size = new Size(210, 31);
            txtNombre.TabIndex = 2;
            txtNombre.TabStop = false;
            // 
            // txtId
            // 
            txtId.Location = new Point(153, 35);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(210, 31);
            txtId.TabIndex = 1;
            txtId.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 179);
            label5.Name = "label5";
            label5.Size = new Size(130, 25);
            label5.TabIndex = 1;
            label5.Text = "Fecha Registro:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 142);
            label4.Name = "label4";
            label4.Size = new Size(86, 25);
            label4.TabIndex = 1;
            label4.Text = "Peso (kg):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 106);
            label3.Name = "label3";
            label3.Size = new Size(73, 25);
            label3.TabIndex = 1;
            label3.Text = "Especie:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 69);
            label2.Name = "label2";
            label2.Size = new Size(80, 25);
            label2.TabIndex = 1;
            label2.Text = "Nombre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 35);
            label1.Name = "label1";
            label1.Size = new Size(95, 25);
            label1.TabIndex = 1;
            label1.Text = "ID Animal:";
            // 
            // grpFoto
            // 
            grpFoto.Controls.Add(pbxFoto);
            grpFoto.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            grpFoto.Location = new Point(395, 58);
            grpFoto.Name = "grpFoto";
            grpFoto.Size = new Size(215, 250);
            grpFoto.TabIndex = 1;
            grpFoto.TabStop = false;
            grpFoto.Text = "Fotografía Registrada";
            // 
            // pbxFoto
            // 
            pbxFoto.BorderStyle = BorderStyle.FixedSingle;
            pbxFoto.Location = new Point(17, 30);
            pbxFoto.Name = "pbxFoto";
            pbxFoto.Size = new Size(180, 200);
            pbxFoto.SizeMode = PictureBoxSizeMode.Zoom;
            pbxFoto.TabIndex = 0;
            pbxFoto.TabStop = false;
            // 
            // btnLogico
            // 
            btnLogico.BackColor = Color.Khaki;
            btnLogico.FlatStyle = FlatStyle.Flat;
            btnLogico.Location = new Point(15, 322);
            btnLogico.Name = "btnLogico";
            btnLogico.Size = new Size(185, 45);
            btnLogico.TabIndex = 2;
            btnLogico.Text = "Borrado Lógico";
            btnLogico.UseVisualStyleBackColor = false;
            btnLogico.Click += btnLogico_Click;
            // 
            // btnFisico
            // 
            btnFisico.BackColor = Color.LightCoral;
            btnFisico.FlatStyle = FlatStyle.Flat;
            btnFisico.ForeColor = Color.White;
            btnFisico.Location = new Point(220, 322);
            btnFisico.Name = "btnFisico";
            btnFisico.Size = new Size(185, 45);
            btnFisico.TabIndex = 3;
            btnFisico.Text = "Borrado Físico";
            btnFisico.UseVisualStyleBackColor = false;
            btnFisico.Click += btnFisico_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.LightGray;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(425, 322);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(185, 45);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // lblAutoria
            // 
            lblAutoria.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAutoria.Location = new Point(12, 9);
            lblAutoria.Name = "lblAutoria";
            lblAutoria.Size = new Size(595, 44);
            lblAutoria.TabIndex = 5;
            lblAutoria.Text = "FLORES MONTAÑO Roberto Carlos, GONZALEZ ALVARADO Alexa Michelle, MALDONADO LLAMAS Oswaldo Daniel - Equipo [E5]";
            lblAutoria.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // FrmDetalleEliminacion
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(633, 369);
            Controls.Add(lblAutoria);
            Controls.Add(btnCancelar);
            Controls.Add(btnFisico);
            Controls.Add(btnLogico);
            Controls.Add(grpFoto);
            Controls.Add(grpDatos);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmDetalleEliminacion";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalle de Registro - Confirmación de Eliminación";
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            grpFoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbxFoto).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpDatos;
        private Label label1;
        private Label label2;
        private TextBox txtFecha;
        private TextBox txtPeso;
        private TextBox txtEspecie;
        private TextBox txtNombre;
        private TextBox txtId;
        private Label label5;
        private Label label4;
        private Label label3;
        private CheckBox chkActivo;
        private GroupBox grpFoto;
        private PictureBox pbxFoto;
        private Button btnLogico;
        private Button btnFisico;
        private Button btnCancelar;
        private Label lblAutoria;
    }
}