namespace SistemaRescateAnimalUI
{
    partial class FrmRegistroAdopcion
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
            grpAdopcion = new GroupBox();
            btnGuardar = new Button();
            txtObservaciones = new TextBox();
            label5 = new Label();
            dtpFechaAdopcion = new DateTimePicker();
            label4 = new Label();
            cmbAdoptante = new ComboBox();
            label3 = new Label();
            cmbAnimal = new ComboBox();
            label2 = new Label();
            grpAdopcion.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(15, 12);
            label1.Name = "label1";
            label1.Size = new Size(391, 38);
            label1.TabIndex = 0;
            label1.Text = "Registro de Nueva Adopción";
            // 
            // grpAdopcion
            // 
            grpAdopcion.Controls.Add(btnGuardar);
            grpAdopcion.Controls.Add(txtObservaciones);
            grpAdopcion.Controls.Add(label5);
            grpAdopcion.Controls.Add(dtpFechaAdopcion);
            grpAdopcion.Controls.Add(label4);
            grpAdopcion.Controls.Add(cmbAdoptante);
            grpAdopcion.Controls.Add(label3);
            grpAdopcion.Controls.Add(cmbAnimal);
            grpAdopcion.Controls.Add(label2);
            grpAdopcion.Location = new Point(15, 48);
            grpAdopcion.Name = "grpAdopcion";
            grpAdopcion.Size = new Size(395, 395);
            grpAdopcion.TabIndex = 1;
            grpAdopcion.TabStop = false;
            grpAdopcion.Text = "Datos de la Adopción";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(190, 368);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(189, 36);
            btnGuardar.TabIndex = 3;
            btnGuardar.Text = "Guardar Adopción";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(15, 264);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.ScrollBars = ScrollBars.Vertical;
            txtObservaciones.Size = new Size(365, 85);
            txtObservaciones.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 233);
            label5.Name = "label5";
            label5.Size = new Size(279, 28);
            label5.TabIndex = 2;
            label5.Text = "Observaciones y Notas Finales:";
            // 
            // dtpFechaAdopcion
            // 
            dtpFechaAdopcion.Format = DateTimePickerFormat.Short;
            dtpFechaAdopcion.Location = new Point(15, 196);
            dtpFechaAdopcion.Name = "dtpFechaAdopcion";
            dtpFechaAdopcion.Size = new Size(365, 34);
            dtpFechaAdopcion.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 165);
            label4.Name = "label4";
            label4.Size = new Size(184, 28);
            label4.TabIndex = 2;
            label4.Text = "Fecha de Adopción:";
            // 
            // cmbAdoptante
            // 
            cmbAdoptante.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAdoptante.FormattingEnabled = true;
            cmbAdoptante.Location = new Point(15, 128);
            cmbAdoptante.Name = "cmbAdoptante";
            cmbAdoptante.Size = new Size(365, 36);
            cmbAdoptante.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 98);
            label3.Name = "label3";
            label3.Size = new Size(110, 28);
            label3.TabIndex = 2;
            label3.Text = "Adoptante:";
            // 
            // cmbAnimal
            // 
            cmbAnimal.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAnimal.FormattingEnabled = true;
            cmbAnimal.Location = new Point(15, 59);
            cmbAnimal.Name = "cmbAnimal";
            cmbAnimal.Size = new Size(365, 36);
            cmbAnimal.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 28);
            label2.Name = "label2";
            label2.Size = new Size(196, 28);
            label2.TabIndex = 2;
            label2.Text = "Animal (Disponibles):";
            // 
            // FrmRegistroAdopcion
            // 
            AutoScaleDimensions = new SizeF(11F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(418, 468);
            Controls.Add(grpAdopcion);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MaximizeBox = false;
            Name = "FrmRegistroAdopcion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmRegistroAdopcion";
            Load += FrmRegistroAdopcion_Load;
            Click += FrmRegistroAdopcion_Load;
            grpAdopcion.ResumeLayout(false);
            grpAdopcion.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox grpAdopcion;
        private Label label3;
        private ComboBox cmbAnimal;
        private Label label2;
        private ComboBox cmbAdoptante;
        private Label label5;
        private DateTimePicker dtpFechaAdopcion;
        private Label label4;
        private TextBox txtObservaciones;
        private Button btnGuardar;
    }
}