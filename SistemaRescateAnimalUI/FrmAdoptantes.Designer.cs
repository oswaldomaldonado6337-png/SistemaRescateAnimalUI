namespace SistemaRescateAnimalUI
{
    partial class FrmAdoptantes
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
            groupBox1 = new GroupBox();
            txtApellidoMaterno = new TextBox();
            txtApellidoPaterno = new TextBox();
            label3 = new Label();
            label2 = new Label();
            txtNombre = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            txtCorreo = new TextBox();
            txtTelefono = new TextBox();
            label5 = new Label();
            label4 = new Label();
            groupBox3 = new GroupBox();
            txtCiudad = new TextBox();
            txtColonia = new TextBox();
            txtNumero = new TextBox();
            txtCalle = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            btnLimpiar = new Button();
            btnGuardar = new Button();
            label10 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtApellidoMaterno);
            groupBox1.Controls.Add(txtApellidoPaterno);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(52, 82);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(890, 150);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Datos Personales";
            // 
            // txtApellidoMaterno
            // 
            txtApellidoMaterno.Location = new Point(395, 119);
            txtApellidoMaterno.Name = "txtApellidoMaterno";
            txtApellidoMaterno.Size = new Size(326, 31);
            txtApellidoMaterno.TabIndex = 5;
            // 
            // txtApellidoPaterno
            // 
            txtApellidoPaterno.Location = new Point(17, 119);
            txtApellidoPaterno.Name = "txtApellidoPaterno";
            txtApellidoPaterno.Size = new Size(295, 31);
            txtApellidoPaterno.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(395, 89);
            label3.Name = "label3";
            label3.Size = new Size(154, 25);
            label3.TabIndex = 3;
            label3.Text = "Apellido Materno:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 91);
            label2.Name = "label2";
            label2.Size = new Size(147, 25);
            label2.TabIndex = 2;
            label2.Text = "Apellido Paterno:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(17, 55);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(704, 31);
            txtNombre.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 27);
            label1.Name = "label1";
            label1.Size = new Size(100, 25);
            label1.TabIndex = 0;
            label1.Text = "Nombre(s):";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtCorreo);
            groupBox2.Controls.Add(txtTelefono);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(52, 238);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(890, 150);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Contacto";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(395, 84);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(326, 31);
            txtCorreo.TabIndex = 3;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(17, 84);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(295, 31);
            txtTelefono.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(395, 41);
            label5.Name = "label5";
            label5.Size = new Size(161, 25);
            label5.TabIndex = 1;
            label5.Text = "Correo Electrónico:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 41);
            label4.Name = "label4";
            label4.Size = new Size(83, 25);
            label4.TabIndex = 0;
            label4.Text = "Teléfono:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtCiudad);
            groupBox3.Controls.Add(txtColonia);
            groupBox3.Controls.Add(txtNumero);
            groupBox3.Controls.Add(txtCalle);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label6);
            groupBox3.Location = new Point(52, 405);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(890, 150);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Dirección";
            // 
            // txtCiudad
            // 
            txtCiudad.Location = new Point(395, 113);
            txtCiudad.Name = "txtCiudad";
            txtCiudad.Size = new Size(326, 31);
            txtCiudad.TabIndex = 7;
            // 
            // txtColonia
            // 
            txtColonia.Location = new Point(17, 119);
            txtColonia.Name = "txtColonia";
            txtColonia.Size = new Size(295, 31);
            txtColonia.TabIndex = 6;
            // 
            // txtNumero
            // 
            txtNumero.Location = new Point(395, 55);
            txtNumero.Name = "txtNumero";
            txtNumero.Size = new Size(326, 31);
            txtNumero.TabIndex = 5;
            // 
            // txtCalle
            // 
            txtCalle.Location = new Point(17, 55);
            txtCalle.Name = "txtCalle";
            txtCalle.Size = new Size(295, 31);
            txtCalle.TabIndex = 4;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(395, 85);
            label9.Name = "label9";
            label9.Size = new Size(72, 25);
            label9.TabIndex = 3;
            label9.Text = "Ciudad:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(17, 91);
            label8.Name = "label8";
            label8.Size = new Size(76, 25);
            label8.TabIndex = 2;
            label8.Text = "Colonia:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(395, 27);
            label7.Name = "label7";
            label7.Size = new Size(81, 25);
            label7.TabIndex = 1;
            label7.Text = "Número:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 27);
            label6.Name = "label6";
            label6.Size = new Size(53, 25);
            label6.TabIndex = 0;
            label6.Text = "Calle:";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(439, 561);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(112, 34);
            btnLimpiar.TabIndex = 3;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(633, 556);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(112, 34);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(52, 27);
            label10.Name = "label10";
            label10.Size = new Size(374, 45);
            label10.TabIndex = 5;
            label10.Text = "Registro de Adoptantes";
            // 
            // FrmAdoptantes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1019, 602);
            Controls.Add(label10);
            Controls.Add(btnGuardar);
            Controls.Add(btnLimpiar);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "FrmAdoptantes";
            Text = "FrmAdoptantes";
            Load += FrmAdoptantes_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label label3;
        private Label label2;
        private TextBox txtNombre;
        private Label label1;
        private TextBox txtApellidoMaterno;
        private TextBox txtApellidoPaterno;
        private TextBox txtTelefono;
        private Label label5;
        private Label label4;
        private TextBox txtCorreo;
        private TextBox txtCiudad;
        private TextBox txtColonia;
        private TextBox txtNumero;
        private TextBox txtCalle;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Button btnLimpiar;
        private Button btnGuardar;
        private Label label10;
    }
}