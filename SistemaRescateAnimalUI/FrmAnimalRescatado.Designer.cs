namespace SistemaRescateAnimalUI
{
    partial class FrmAnimalRescatado
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
            components = new System.ComponentModel.Container();
            txtNombre = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtEspecie = new TextBox();
            numPeso = new NumericUpDown();
            dtpFechaRegistro = new DateTimePicker();
            chkEsActivo = new CheckBox();
            label5 = new Label();
            lblId = new Label();
            txtIdBusqueda = new TextBox();
            btnMasterBuscar = new Button();
            btnMasterGuardar = new Button();
            btnMasterActualizar = new Button();
            btnMasterEliminar = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)numPeso).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(280, 105);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(150, 31);
            txtNombre.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(85, 266);
            label1.Name = "label1";
            label1.Size = new Size(131, 25);
            label1.TabIndex = 1;
            label1.Text = "Fecha Registro:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(85, 223);
            label2.Name = "label2";
            label2.Size = new Size(88, 25);
            label2.TabIndex = 2;
            label2.Text = "Peso (kg):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(85, 108);
            label3.Name = "label3";
            label3.Size = new Size(82, 25);
            label3.TabIndex = 3;
            label3.Text = "Nombre:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(85, 152);
            label4.Name = "label4";
            label4.Size = new Size(74, 25);
            label4.TabIndex = 4;
            label4.Text = "Especie:";
            // 
            // txtEspecie
            // 
            txtEspecie.Location = new Point(280, 162);
            txtEspecie.Name = "txtEspecie";
            txtEspecie.Size = new Size(150, 31);
            txtEspecie.TabIndex = 5;
            // 
            // numPeso
            // 
            numPeso.Location = new Point(280, 223);
            numPeso.Name = "numPeso";
            numPeso.Size = new Size(180, 31);
            numPeso.TabIndex = 7;
            // 
            // dtpFechaRegistro
            // 
            dtpFechaRegistro.Location = new Point(280, 266);
            dtpFechaRegistro.Name = "dtpFechaRegistro";
            dtpFechaRegistro.Size = new Size(300, 31);
            dtpFechaRegistro.TabIndex = 8;
            // 
            // chkEsActivo
            // 
            chkEsActivo.AutoSize = true;
            chkEsActivo.Location = new Point(95, 321);
            chkEsActivo.Name = "chkEsActivo";
            chkEsActivo.Size = new Size(133, 29);
            chkEsActivo.TabIndex = 9;
            chkEsActivo.Text = "Esta Activo?";
            chkEsActivo.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 77);
            label5.Name = "label5";
            label5.Size = new Size(1046, 25);
            label5.TabIndex = 10;
            label5.Text = "FLORES MONTANO Carlos Roberto, GONZALEZ ALVARADO Alexa Michelle, MALDONADO LLAMAS Oswaldo Daniel - Equipo [E5]   ";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(56, 9);
            lblId.Margin = new Padding(4, 0, 4, 0);
            lblId.Name = "lblId";
            lblId.Padding = new Padding(0, 8, 0, 0);
            lblId.Size = new Size(34, 33);
            lblId.TabIndex = 11;
            lblId.Text = "ID:";
            // 
            // txtIdBusqueda
            // 
            txtIdBusqueda.Location = new Point(98, 13);
            txtIdBusqueda.Margin = new Padding(4);
            txtIdBusqueda.Name = "txtIdBusqueda";
            txtIdBusqueda.Size = new Size(149, 31);
            txtIdBusqueda.TabIndex = 12;
            // 
            // btnMasterBuscar
            // 
            btnMasterBuscar.Location = new Point(255, 13);
            btnMasterBuscar.Margin = new Padding(4);
            btnMasterBuscar.Name = "btnMasterBuscar";
            btnMasterBuscar.Size = new Size(125, 38);
            btnMasterBuscar.TabIndex = 13;
            btnMasterBuscar.Text = "Buscar";
            btnMasterBuscar.UseVisualStyleBackColor = true;
            btnMasterBuscar.Click += btnMasterBuscar_Click;
            // 
            // btnMasterGuardar
            // 
            btnMasterGuardar.Location = new Point(388, 13);
            btnMasterGuardar.Margin = new Padding(4);
            btnMasterGuardar.Name = "btnMasterGuardar";
            btnMasterGuardar.Size = new Size(125, 38);
            btnMasterGuardar.TabIndex = 14;
            btnMasterGuardar.Text = "Guardar";
            btnMasterGuardar.UseVisualStyleBackColor = true;
            btnMasterGuardar.Click += btnMasterGuardar_Click;
            // 
            // btnMasterActualizar
            // 
            btnMasterActualizar.Location = new Point(521, 13);
            btnMasterActualizar.Margin = new Padding(4);
            btnMasterActualizar.Name = "btnMasterActualizar";
            btnMasterActualizar.Size = new Size(125, 38);
            btnMasterActualizar.TabIndex = 15;
            btnMasterActualizar.Text = "Actualizar";
            btnMasterActualizar.UseVisualStyleBackColor = true;
            btnMasterActualizar.Click += btnMasterActualizar_Click;
            // 
            // btnMasterEliminar
            // 
            btnMasterEliminar.Location = new Point(654, 13);
            btnMasterEliminar.Margin = new Padding(4);
            btnMasterEliminar.Name = "btnMasterEliminar";
            btnMasterEliminar.Size = new Size(125, 38);
            btnMasterEliminar.TabIndex = 16;
            btnMasterEliminar.Text = "Eliminar";
            btnMasterEliminar.UseVisualStyleBackColor = true;
            btnMasterEliminar.Click += btnMasterEliminar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // FrmAnimalRescatado
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 488);
            Controls.Add(lblId);
            Controls.Add(txtIdBusqueda);
            Controls.Add(btnMasterBuscar);
            Controls.Add(btnMasterGuardar);
            Controls.Add(btnMasterActualizar);
            Controls.Add(btnMasterEliminar);
            Controls.Add(label5);
            Controls.Add(chkEsActivo);
            Controls.Add(dtpFechaRegistro);
            Controls.Add(numPeso);
            Controls.Add(txtEspecie);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNombre);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAnimalRescatado";
            Text = "FrmAnimalRescatado";
            ((System.ComponentModel.ISupportInitialize)numPeso).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtEspecie;
        private NumericUpDown numPeso;
        private DateTimePicker dtpFechaRegistro;
        private CheckBox chkEsActivo;
        private Label label5;
        private Label lblId;
        private TextBox txtIdBusqueda;
        private Button btnMasterBuscar;
        private Button btnMasterGuardar;
        private Button btnMasterActualizar;
        private Button btnMasterEliminar;
    }
}