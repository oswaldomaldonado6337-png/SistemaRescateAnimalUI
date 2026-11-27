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
            btnTestConexion = new Button();
            btnExportarJSON = new Button();
            btnExportarXML = new Button();
            btnImportar = new Button();
            dgvAnimales = new DataGridView();
            dtpFechaNacimiento = new DateTimePicker();
            label6 = new Label();
            txtLugarHallazgo = new TextBox();
            label7 = new Label();
            cmbCondicionHallazgo = new ComboBox();
            label8 = new Label();
            txtUbicacionFisica = new TextBox();
            btnMasterListar = new Button();
            btnMasterCancelar = new Button();
            label9 = new Label();
            ((System.ComponentModel.ISupportInitialize)numPeso).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAnimales).BeginInit();
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
            chkEsActivo.Size = new Size(161, 29);
            chkEsActivo.TabIndex = 9;
            chkEsActivo.Text = "Esta Vacunado?";
            chkEsActivo.UseVisualStyleBackColor = true;
            chkEsActivo.Visible = false;
            chkEsActivo.CheckedChanged += chkEsActivo_CheckedChanged;
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
            // btnTestConexion
            // 
            btnTestConexion.Location = new Point(12, 519);
            btnTestConexion.Name = "btnTestConexion";
            btnTestConexion.Size = new Size(262, 34);
            btnTestConexion.TabIndex = 18;
            btnTestConexion.Text = "Test Conexión";
            btnTestConexion.UseVisualStyleBackColor = true;
            btnTestConexion.Visible = false;
            btnTestConexion.Click += button1_Click;
            // 
            // btnExportarJSON
            // 
            btnExportarJSON.Location = new Point(12, 530);
            btnExportarJSON.Name = "btnExportarJSON";
            btnExportarJSON.Size = new Size(135, 34);
            btnExportarJSON.TabIndex = 19;
            btnExportarJSON.Text = "Exportar JSON";
            btnExportarJSON.UseVisualStyleBackColor = true;
            btnExportarJSON.Visible = false;
            btnExportarJSON.Click += btnExportarJSON_Click;
            // 
            // btnExportarXML
            // 
            btnExportarXML.Location = new Point(56, 519);
            btnExportarXML.Name = "btnExportarXML";
            btnExportarXML.Size = new Size(130, 34);
            btnExportarXML.TabIndex = 20;
            btnExportarXML.Text = "Exportar XML";
            btnExportarXML.UseVisualStyleBackColor = true;
            btnExportarXML.Visible = false;
            btnExportarXML.Click += btnExportarXML_Click;
            // 
            // btnImportar
            // 
            btnImportar.Location = new Point(12, 519);
            btnImportar.Name = "btnImportar";
            btnImportar.Size = new Size(112, 34);
            btnImportar.TabIndex = 21;
            btnImportar.Text = "Importar";
            btnImportar.UseVisualStyleBackColor = true;
            btnImportar.Visible = false;
            btnImportar.Click += btnImportar_Click;
            // 
            // dgvAnimales
            // 
            dgvAnimales.AllowUserToAddRows = false;
            dgvAnimales.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvAnimales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAnimales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnimales.Location = new Point(25, 320);
            dgvAnimales.MultiSelect = false;
            dgvAnimales.Name = "dgvAnimales";
            dgvAnimales.ReadOnly = true;
            dgvAnimales.RowHeadersWidth = 62;
            dgvAnimales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAnimales.Size = new Size(1050, 235);
            dgvAnimales.TabIndex = 24;
            dgvAnimales.CellClick += dgvAnimales_CellContentClick;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(671, 102);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(155, 31);
            dtpFechaNacimiento.TabIndex = 25;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(480, 146);
            label6.Name = "label6";
            label6.Size = new Size(134, 25);
            label6.TabIndex = 26;
            label6.Text = "Lugar Hallazgo:";
            // 
            // txtLugarHallazgo
            // 
            txtLugarHallazgo.Location = new Point(671, 139);
            txtLugarHallazgo.Name = "txtLugarHallazgo";
            txtLugarHallazgo.Size = new Size(220, 31);
            txtLugarHallazgo.TabIndex = 27;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(484, 182);
            label7.Name = "label7";
            label7.Size = new Size(96, 25);
            label7.TabIndex = 28;
            label7.Text = "Condición:";
            // 
            // cmbCondicionHallazgo
            // 
            cmbCondicionHallazgo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCondicionHallazgo.FormattingEnabled = true;
            cmbCondicionHallazgo.Location = new Point(671, 174);
            cmbCondicionHallazgo.Name = "cmbCondicionHallazgo";
            cmbCondicionHallazgo.Size = new Size(220, 33);
            cmbCondicionHallazgo.TabIndex = 29;
            cmbCondicionHallazgo.SelectedIndexChanged += cmbCondicionHallazgo_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(480, 225);
            label8.Name = "label8";
            label8.Size = new Size(148, 25);
            label8.TabIndex = 30;
            label8.Text = "Ubicación / Jaula:";
            // 
            // txtUbicacionFisica
            // 
            txtUbicacionFisica.Location = new Point(671, 213);
            txtUbicacionFisica.Name = "txtUbicacionFisica";
            txtUbicacionFisica.ReadOnly = true;
            txtUbicacionFisica.Size = new Size(175, 31);
            txtUbicacionFisica.TabIndex = 31;
            // 
            // btnMasterListar
            // 
            btnMasterListar.Location = new Point(786, 13);
            btnMasterListar.Name = "btnMasterListar";
            btnMasterListar.Size = new Size(96, 38);
            btnMasterListar.TabIndex = 32;
            btnMasterListar.Text = "Listar";
            btnMasterListar.UseVisualStyleBackColor = true;
            btnMasterListar.Click += btnMasterListar_Click;
            // 
            // btnMasterCancelar
            // 
            btnMasterCancelar.Location = new Point(888, 13);
            btnMasterCancelar.Name = "btnMasterCancelar";
            btnMasterCancelar.Size = new Size(108, 38);
            btnMasterCancelar.TabIndex = 33;
            btnMasterCancelar.Text = "Cancelar";
            btnMasterCancelar.UseVisualStyleBackColor = true;
            btnMasterCancelar.Click += btnMasterCancelar_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(480, 105);
            label9.Name = "label9";
            label9.Size = new Size(181, 25);
            label9.TabIndex = 34;
            label9.Text = "Nacimiento Estimado";
            // 
            // FrmAnimalRescatado
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1233, 590);
            Controls.Add(label9);
            Controls.Add(btnMasterCancelar);
            Controls.Add(btnMasterListar);
            Controls.Add(txtUbicacionFisica);
            Controls.Add(label8);
            Controls.Add(cmbCondicionHallazgo);
            Controls.Add(label7);
            Controls.Add(txtLugarHallazgo);
            Controls.Add(label6);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(dgvAnimales);
            Controls.Add(btnImportar);
            Controls.Add(btnExportarXML);
            Controls.Add(btnExportarJSON);
            Controls.Add(btnTestConexion);
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
            Load += FrmAnimalRescatado_Load_1;
            ((System.ComponentModel.ISupportInitialize)numPeso).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAnimales).EndInit();
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
        private Button btnTestConexion;
        private Button btnExportarXML;
        private Button btnExportarJSON;
        private Button btnImportar;
        private DataGridView dgvAnimales;
        private ComboBox cmbCondicionHallazgo;
        private Label label7;
        private TextBox txtLugarHallazgo;
        private Label label6;
        private DateTimePicker dtpFechaNacimiento;
        private Button btnMasterCancelar;
        private Button btnMasterListar;
        private TextBox txtUbicacionFisica;
        private Label label8;
        private Label label9;
        //private DataGridView dgvAnimales;
    }
}