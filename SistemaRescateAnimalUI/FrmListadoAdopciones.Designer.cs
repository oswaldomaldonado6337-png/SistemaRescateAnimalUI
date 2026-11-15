namespace SistemaRescateAnimalUI
{
    partial class FrmListadoAdopciones
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
            dgvAdopciones = new DataGridView();
            btnCargarMaria = new Button();
            btnCargarMongo = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAdopciones).BeginInit();
            SuspendLayout();
            // 
            // dgvAdopciones
            // 
            dgvAdopciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdopciones.Dock = DockStyle.Bottom;
            dgvAdopciones.Location = new Point(0, 54);
            dgvAdopciones.Name = "dgvAdopciones";
            dgvAdopciones.RowHeadersWidth = 62;
            dgvAdopciones.Size = new Size(800, 396);
            dgvAdopciones.TabIndex = 0;
            // 
            // btnCargarMaria
            // 
            btnCargarMaria.Location = new Point(12, 12);
            btnCargarMaria.Name = "btnCargarMaria";
            btnCargarMaria.Size = new Size(201, 34);
            btnCargarMaria.TabIndex = 1;
            btnCargarMaria.Text = "Cargar MariaDB (JOIN)";
            btnCargarMaria.UseVisualStyleBackColor = true;
            btnCargarMaria.Click += btnCargarMaria_Click;
            // 
            // btnCargarMongo
            // 
            btnCargarMongo.Location = new Point(299, 14);
            btnCargarMongo.Name = "btnCargarMongo";
            btnCargarMongo.Size = new Size(258, 34);
            btnCargarMongo.TabIndex = 2;
            btnCargarMongo.Text = "Cargar MongoDB ($lookup)";
            btnCargarMongo.UseVisualStyleBackColor = true;
            btnCargarMongo.Click += btnCargarMongo_Click;
            // 
            // FrmListadoAdopciones
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCargarMongo);
            Controls.Add(btnCargarMaria);
            Controls.Add(dgvAdopciones);
            Name = "FrmListadoAdopciones";
            Text = "FrmListadoAdopciones";
            Load += FrmListadoAdopciones_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAdopciones).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvAdopciones;
        private Button btnCargarMaria;
        private Button btnCargarMongo;
    }
}