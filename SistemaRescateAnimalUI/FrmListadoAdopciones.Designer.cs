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
            label1 = new Label();
            txtBuscar = new TextBox();
            label2 = new Label();
            cmbFiltroEstado = new ComboBox();
            chkFiltrarFecha = new CheckBox();
            dtpFecha = new DateTimePicker();
            btnLimpiarFiltros = new Button();
            btnFinalizar = new Button();
            btnCancelarAdopcion = new Button();
            btnRefrescar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvAdopciones).BeginInit();
            SuspendLayout();
            // 
            // dgvAdopciones
            // 
            dgvAdopciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdopciones.Location = new Point(15, 110);
            dgvAdopciones.MultiSelect = false;
            dgvAdopciones.Name = "dgvAdopciones";
            dgvAdopciones.ReadOnly = true;
            dgvAdopciones.RowHeadersWidth = 62;
            dgvAdopciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdopciones.Size = new Size(1005, 345);
            dgvAdopciones.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 22);
            label1.Name = "label1";
            label1.Size = new Size(291, 25);
            label1.TabIndex = 1;
            label1.Text = "Buscar (Folio, Animal o Adoptante):";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(15, 50);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(240, 31);
            txtBuscar.TabIndex = 2;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(280, 22);
            label2.Name = "label2";
            label2.Size = new Size(70, 25);
            label2.TabIndex = 3;
            label2.Text = "Estado:";
            // 
            // cmbFiltroEstado
            // 
            cmbFiltroEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFiltroEstado.FormattingEnabled = true;
            cmbFiltroEstado.Location = new Point(280, 45);
            cmbFiltroEstado.Name = "cmbFiltroEstado";
            cmbFiltroEstado.Size = new Size(140, 33);
            cmbFiltroEstado.TabIndex = 4;
            cmbFiltroEstado.SelectedIndexChanged += cmbFiltroEstado_SelectedIndexChanged;
            // 
            // chkFiltrarFecha
            // 
            chkFiltrarFecha.AutoSize = true;
            chkFiltrarFecha.Location = new Point(450, 47);
            chkFiltrarFecha.Name = "chkFiltrarFecha";
            chkFiltrarFecha.Size = new Size(166, 29);
            chkFiltrarFecha.TabIndex = 5;
            chkFiltrarFecha.Text = "Filtrar por fecha:";
            chkFiltrarFecha.UseVisualStyleBackColor = true;
            chkFiltrarFecha.CheckedChanged += chkFiltrarFecha_CheckedChanged;
            // 
            // dtpFecha
            // 
            dtpFecha.Enabled = false;
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(622, 45);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(120, 31);
            dtpFecha.TabIndex = 6;
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Location = new Point(748, 47);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(120, 28);
            btnLimpiarFiltros.TabIndex = 7;
            btnLimpiarFiltros.Text = "Limpiar Filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // btnFinalizar
            // 
            btnFinalizar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnFinalizar.Location = new Point(15, 470);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new Size(240, 32);
            btnFinalizar.TabIndex = 8;
            btnFinalizar.Text = "Marcar como Finalizado";
            btnFinalizar.UseVisualStyleBackColor = true;
            btnFinalizar.Click += btnFinalizar_Click;
            // 
            // btnCancelarAdopcion
            // 
            btnCancelarAdopcion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancelarAdopcion.Location = new Point(261, 470);
            btnCancelarAdopcion.Name = "btnCancelarAdopcion";
            btnCancelarAdopcion.Size = new Size(239, 32);
            btnCancelarAdopcion.TabIndex = 9;
            btnCancelarAdopcion.Text = "Cancelar Adopción";
            btnCancelarAdopcion.UseVisualStyleBackColor = true;
            btnCancelarAdopcion.Click += btnCancelarAdopcion_Click;
            // 
            // btnRefrescar
            // 
            btnRefrescar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefrescar.Location = new Point(856, 470);
            btnRefrescar.Name = "btnRefrescar";
            btnRefrescar.Size = new Size(164, 32);
            btnRefrescar.TabIndex = 10;
            btnRefrescar.Text = "Refrescar Lista";
            btnRefrescar.UseVisualStyleBackColor = true;
            btnRefrescar.Click += btnRefrescar_Click;
            // 
            // FrmListadoAdopciones
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1028, 504);
            Controls.Add(btnRefrescar);
            Controls.Add(btnCancelarAdopcion);
            Controls.Add(btnFinalizar);
            Controls.Add(btnLimpiarFiltros);
            Controls.Add(dtpFecha);
            Controls.Add(chkFiltrarFecha);
            Controls.Add(cmbFiltroEstado);
            Controls.Add(label2);
            Controls.Add(txtBuscar);
            Controls.Add(label1);
            Controls.Add(dgvAdopciones);
            Name = "FrmListadoAdopciones";
            Text = "FrmListadoAdopciones";
            Load += FrmListadoAdopciones_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAdopciones).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvAdopciones;
        private Label label1;
        private TextBox txtBuscar;
        private Label label2;
        private ComboBox cmbFiltroEstado;
        private CheckBox chkFiltrarFecha;
        private DateTimePicker dtpFecha;
        private Button btnLimpiarFiltros;
        private Button btnFinalizar;
        private Button btnCancelarAdopcion;
        private Button btnRefrescar;
    }
}