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
            txtNombre = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtEspecie = new TextBox();
            numPeso = new NumericUpDown();
            dtpFechaRegistro = new DateTimePicker();
            chkEsActivo = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)numPeso).BeginInit();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(280, 70);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(150, 31);
            txtNombre.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(85, 231);
            label1.Name = "label1";
            label1.Size = new Size(131, 25);
            label1.TabIndex = 1;
            label1.Text = "Fecha Registro:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(85, 188);
            label2.Name = "label2";
            label2.Size = new Size(88, 25);
            label2.TabIndex = 2;
            label2.Text = "Peso (kg):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(85, 73);
            label3.Name = "label3";
            label3.Size = new Size(82, 25);
            label3.TabIndex = 3;
            label3.Text = "Nombre:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(85, 117);
            label4.Name = "label4";
            label4.Size = new Size(74, 25);
            label4.TabIndex = 4;
            label4.Text = "Especie:";
            // 
            // txtEspecie
            // 
            txtEspecie.Location = new Point(280, 127);
            txtEspecie.Name = "txtEspecie";
            txtEspecie.Size = new Size(150, 31);
            txtEspecie.TabIndex = 5;
            // 
            // numPeso
            // 
            numPeso.Location = new Point(280, 188);
            numPeso.Name = "numPeso";
            numPeso.Size = new Size(180, 31);
            numPeso.TabIndex = 7;
            // 
            // dtpFechaRegistro
            // 
            dtpFechaRegistro.Location = new Point(280, 231);
            dtpFechaRegistro.Name = "dtpFechaRegistro";
            dtpFechaRegistro.Size = new Size(300, 31);
            dtpFechaRegistro.TabIndex = 8;
            // 
            // chkEsActivo
            // 
            chkEsActivo.AutoSize = true;
            chkEsActivo.Location = new Point(95, 286);
            chkEsActivo.Name = "chkEsActivo";
            chkEsActivo.Size = new Size(133, 29);
            chkEsActivo.TabIndex = 9;
            chkEsActivo.Text = "Esta Activo?";
            chkEsActivo.UseVisualStyleBackColor = true;
            // 
            // FrmAnimalRescatado
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(chkEsActivo);
            Controls.Add(dtpFechaRegistro);
            Controls.Add(numPeso);
            Controls.Add(txtEspecie);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtNombre);
            Name = "FrmAnimalRescatado";
            Text = "FrmAnimalRescatado";
            ((System.ComponentModel.ISupportInitialize)numPeso).EndInit();
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
    }
}