namespace SistemaRescateAnimalUI
{
    partial class FrmHistorialMedico
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
            label1 = new Label();
            grpConsulta = new GroupBox();
            btnLimpiar = new Button();
            btnGuardar = new Button();
            txtTratamiento = new TextBox();
            label5 = new Label();
            txtEnfermedad = new TextBox();
            label4 = new Label();
            dtpFechaActualizacion = new DateTimePicker();
            label3 = new Label();
            cmbAnimal = new ComboBox();
            label2 = new Label();
            grpHistorial = new GroupBox();
            dgvHistorial = new DataGridView();
            grpConsulta.SuspendLayout();
            grpHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(386, 38);
            label1.TabIndex = 0;
            label1.Text = "Historial Médico Veterinario";
            // 
            // grpConsulta
            // 
            grpConsulta.Controls.Add(btnLimpiar);
            grpConsulta.Controls.Add(btnGuardar);
            grpConsulta.Controls.Add(txtTratamiento);
            grpConsulta.Controls.Add(label5);
            grpConsulta.Controls.Add(txtEnfermedad);
            grpConsulta.Controls.Add(label4);
            grpConsulta.Controls.Add(dtpFechaActualizacion);
            grpConsulta.Controls.Add(label3);
            grpConsulta.Controls.Add(cmbAnimal);
            grpConsulta.Controls.Add(label2);
            grpConsulta.Location = new Point(15, 48);
            grpConsulta.Name = "grpConsulta";
            grpConsulta.Size = new Size(355, 455);
            grpConsulta.TabIndex = 1;
            grpConsulta.TabStop = false;
            grpConsulta.Text = "Nueva Consulta";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(120, 402);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(105, 35);
            btnLimpiar.TabIndex = 0;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(235, 402);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(105, 35);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtTratamiento
            // 
            txtTratamiento.Location = new Point(15, 283);
            txtTratamiento.Multiline = true;
            txtTratamiento.Name = "txtTratamiento";
            txtTratamiento.ScrollBars = ScrollBars.Vertical;
            txtTratamiento.Size = new Size(325, 110);
            txtTratamiento.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 252);
            label5.Name = "label5";
            label5.Size = new Size(222, 28);
            label5.TabIndex = 0;
            label5.Text = "Tratamiento y Cuidados:";
            // 
            // txtEnfermedad
            // 
            txtEnfermedad.Location = new Point(15, 179);
            txtEnfermedad.Multiline = true;
            txtEnfermedad.Name = "txtEnfermedad";
            txtEnfermedad.ScrollBars = ScrollBars.Vertical;
            txtEnfermedad.Size = new Size(325, 70);
            txtEnfermedad.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 148);
            label4.Name = "label4";
            label4.Size = new Size(244, 28);
            label4.TabIndex = 0;
            label4.Text = "Enfermedad / Diagnóstico:";
            // 
            // dtpFechaActualizacion
            // 
            dtpFechaActualizacion.Format = DateTimePickerFormat.Short;
            dtpFechaActualizacion.Location = new Point(15, 119);
            dtpFechaActualizacion.Name = "dtpFechaActualizacion";
            dtpFechaActualizacion.Size = new Size(325, 34);
            dtpFechaActualizacion.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 88);
            label3.Name = "label3";
            label3.Size = new Size(176, 28);
            label3.TabIndex = 0;
            label3.Text = "Fecha de Atención:";
            // 
            // cmbAnimal
            // 
            cmbAnimal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAnimal.FormattingEnabled = true;
            cmbAnimal.Location = new Point(15, 59);
            cmbAnimal.Name = "cmbAnimal";
            cmbAnimal.Size = new Size(325, 36);
            cmbAnimal.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 28);
            label2.Name = "label2";
            label2.Size = new Size(166, 28);
            label2.TabIndex = 0;
            label2.Text = "Paciente (Animal):";
            // 
            // grpHistorial
            // 
            grpHistorial.Controls.Add(dgvHistorial);
            grpHistorial.Location = new Point(385, 48);
            grpHistorial.Name = "grpHistorial";
            grpHistorial.Size = new Size(645, 455);
            grpHistorial.TabIndex = 2;
            grpHistorial.TabStop = false;
            grpHistorial.Text = "Consultas Registradas";
            // 
            // dgvHistorial
            // 
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Location = new Point(15, 28);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.RowHeadersVisible = false;
            dgvHistorial.RowHeadersWidth = 62;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.Size = new Size(615, 410);
            dgvHistorial.TabIndex = 0;
            // 
            // FrmHistorialMedico
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1038, 504);
            Controls.Add(grpHistorial);
            Controls.Add(grpConsulta);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "FrmHistorialMedico";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Historial Médico Veterinario";
            Load += FrmHistorialMedico_Load;
            Click += FrmHistorialMedico_Load;
            grpConsulta.ResumeLayout(false);
            grpConsulta.PerformLayout();
            grpHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox grpConsulta;
        private Label label2;
        private GroupBox grpHistorial;
        private TextBox txtEnfermedad;
        private Label label4;
        private DateTimePicker dtpFechaActualizacion;
        private Label label3;
        private ComboBox cmbAnimal;
        private Button btnLimpiar;
        private Button btnGuardar;
        private TextBox txtTratamiento;
        private Label label5;
        private DataGridView dgvHistorial;
    }
}