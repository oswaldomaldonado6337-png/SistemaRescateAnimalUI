namespace SistemaRescateAnimalUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            TabPageExpedientes = new TabPage();
            btnDestruirExpedienteMedico = new Button();
            btnBorrarExpedienteMedico = new Button();
            btnActualizarExpedienteMedico = new Button();
            btnMostrarExpedienteMedico = new Button();
            btnBuscarExpedienteMedico = new Button();
            btnCrearExpedienteMedico = new Button();
            gbResultadoExpedienteMedico = new GroupBox();
            txtBoxResultadoExpedienteMedico = new TextBox();
            gbDatosExpedienteMedico = new GroupBox();
            chkEstaVacunadoExpedienteMedico = new CheckBox();
            txtCostoTratamiento = new TextBox();
            lblIDExpedienteMedico = new Label();
            txtHistorial = new TextBox();
            lblHistorialExpedienteMedico = new Label();
            txtIdExpediente = new TextBox();
            lblCostoTratamientoExpedienteMedico = new Label();
            TabPageAnimales = new TabPage();
            btnDestruirAnimalRescatado = new Button();
            btnBorrarAnimalRescatado = new Button();
            btnActualizarAnimalRescatado = new Button();
            btnMostrarAnimalRescatado = new Button();
            btnBuscarAnimalRescatado = new Button();
            btnCrearAnimalRescatado = new Button();
            gbResultadoAnimalRescatado = new GroupBox();
            txtBoxResultadoAnimalRescatado = new TextBox();
            gbDatosAnimalRescatado = new GroupBox();
            txtBoxPesoAnimalRescatado = new TextBox();
            lblPesoAnimalRescatado = new Label();
            cmbEspecieAnimalRescatado = new ComboBox();
            txtBoxNombreAnimalRescatado = new TextBox();
            txtBoxIDAnimalRescatado = new TextBox();
            lblEspecieAnimalRescatado = new Label();
            lblNombreAnimalRescatado = new Label();
            lblIDAnimalRescatado = new Label();
            lblAutores = new Label();
            tabControl1.SuspendLayout();
            TabPageExpedientes.SuspendLayout();
            gbResultadoExpedienteMedico.SuspendLayout();
            gbDatosExpedienteMedico.SuspendLayout();
            TabPageAnimales.SuspendLayout();
            gbResultadoAnimalRescatado.SuspendLayout();
            gbDatosAnimalRescatado.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(TabPageExpedientes);
            tabControl1.Controls.Add(TabPageAnimales);
            tabControl1.Location = new Point(10, 10);
            tabControl1.Margin = new Padding(2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1402, 546);
            tabControl1.TabIndex = 0;
            // 
            // TabPageExpedientes
            // 
            TabPageExpedientes.Controls.Add(btnDestruirExpedienteMedico);
            TabPageExpedientes.Controls.Add(btnBorrarExpedienteMedico);
            TabPageExpedientes.Controls.Add(btnActualizarExpedienteMedico);
            TabPageExpedientes.Controls.Add(btnMostrarExpedienteMedico);
            TabPageExpedientes.Controls.Add(btnBuscarExpedienteMedico);
            TabPageExpedientes.Controls.Add(btnCrearExpedienteMedico);
            TabPageExpedientes.Controls.Add(gbResultadoExpedienteMedico);
            TabPageExpedientes.Controls.Add(gbDatosExpedienteMedico);
            TabPageExpedientes.Location = new Point(4, 29);
            TabPageExpedientes.Margin = new Padding(2);
            TabPageExpedientes.Name = "TabPageExpedientes";
            TabPageExpedientes.Padding = new Padding(2);
            TabPageExpedientes.Size = new Size(1394, 513);
            TabPageExpedientes.TabIndex = 0;
            TabPageExpedientes.Text = "Expedientes Médicos";
            TabPageExpedientes.UseVisualStyleBackColor = true;
            TabPageExpedientes.Click += TabPageExpedientes_Click;
            // 
            // btnDestruirExpedienteMedico
            // 
            btnDestruirExpedienteMedico.Location = new Point(686, 446);
            btnDestruirExpedienteMedico.Margin = new Padding(2);
            btnDestruirExpedienteMedico.Name = "btnDestruirExpedienteMedico";
            btnDestruirExpedienteMedico.Size = new Size(90, 27);
            btnDestruirExpedienteMedico.TabIndex = 7;
            btnDestruirExpedienteMedico.Text = "Destruir";
            btnDestruirExpedienteMedico.UseVisualStyleBackColor = true;
            btnDestruirExpedienteMedico.Click += btnDestruirExpedienteMedico_Click;
            // 
            // btnBorrarExpedienteMedico
            // 
            btnBorrarExpedienteMedico.Location = new Point(560, 446);
            btnBorrarExpedienteMedico.Margin = new Padding(2);
            btnBorrarExpedienteMedico.Name = "btnBorrarExpedienteMedico";
            btnBorrarExpedienteMedico.Size = new Size(90, 27);
            btnBorrarExpedienteMedico.TabIndex = 6;
            btnBorrarExpedienteMedico.Text = "Borrar";
            btnBorrarExpedienteMedico.UseVisualStyleBackColor = true;
            btnBorrarExpedienteMedico.Click += button5_Click;
            // 
            // btnActualizarExpedienteMedico
            // 
            btnActualizarExpedienteMedico.Location = new Point(426, 446);
            btnActualizarExpedienteMedico.Margin = new Padding(2);
            btnActualizarExpedienteMedico.Name = "btnActualizarExpedienteMedico";
            btnActualizarExpedienteMedico.Size = new Size(90, 27);
            btnActualizarExpedienteMedico.TabIndex = 5;
            btnActualizarExpedienteMedico.Text = "Actualizar";
            btnActualizarExpedienteMedico.UseVisualStyleBackColor = true;
            btnActualizarExpedienteMedico.Click += btnActualizarExpedienteMedico_Click;
            // 
            // btnMostrarExpedienteMedico
            // 
            btnMostrarExpedienteMedico.Location = new Point(276, 446);
            btnMostrarExpedienteMedico.Margin = new Padding(2);
            btnMostrarExpedienteMedico.Name = "btnMostrarExpedienteMedico";
            btnMostrarExpedienteMedico.Size = new Size(90, 27);
            btnMostrarExpedienteMedico.TabIndex = 4;
            btnMostrarExpedienteMedico.Text = "Mostrar";
            btnMostrarExpedienteMedico.UseVisualStyleBackColor = true;
            btnMostrarExpedienteMedico.Click += button3_Click;
            // 
            // btnBuscarExpedienteMedico
            // 
            btnBuscarExpedienteMedico.Location = new Point(145, 446);
            btnBuscarExpedienteMedico.Margin = new Padding(2);
            btnBuscarExpedienteMedico.Name = "btnBuscarExpedienteMedico";
            btnBuscarExpedienteMedico.Size = new Size(90, 27);
            btnBuscarExpedienteMedico.TabIndex = 3;
            btnBuscarExpedienteMedico.Text = "Buscar";
            btnBuscarExpedienteMedico.UseVisualStyleBackColor = true;
            btnBuscarExpedienteMedico.Click += btnBuscarExpedienteMedico_Click;
            // 
            // btnCrearExpedienteMedico
            // 
            btnCrearExpedienteMedico.Location = new Point(19, 446);
            btnCrearExpedienteMedico.Margin = new Padding(2);
            btnCrearExpedienteMedico.Name = "btnCrearExpedienteMedico";
            btnCrearExpedienteMedico.Size = new Size(90, 27);
            btnCrearExpedienteMedico.TabIndex = 2;
            btnCrearExpedienteMedico.Text = "Crear";
            btnCrearExpedienteMedico.UseVisualStyleBackColor = true;
            btnCrearExpedienteMedico.Click += btnCrearExpedienteMedico_Click;
            // 
            // gbResultadoExpedienteMedico
            // 
            gbResultadoExpedienteMedico.Controls.Add(txtBoxResultadoExpedienteMedico);
            gbResultadoExpedienteMedico.Location = new Point(695, 25);
            gbResultadoExpedienteMedico.Margin = new Padding(2);
            gbResultadoExpedienteMedico.Name = "gbResultadoExpedienteMedico";
            gbResultadoExpedienteMedico.Padding = new Padding(2);
            gbResultadoExpedienteMedico.Size = new Size(701, 393);
            gbResultadoExpedienteMedico.TabIndex = 1;
            gbResultadoExpedienteMedico.TabStop = false;
            gbResultadoExpedienteMedico.Text = "Resultado / Salida";
            gbResultadoExpedienteMedico.Enter += gbResultadoExpedienteMedico_Enter;
            // 
            // txtBoxResultadoExpedienteMedico
            // 
            txtBoxResultadoExpedienteMedico.Location = new Point(15, 52);
            txtBoxResultadoExpedienteMedico.Margin = new Padding(2);
            txtBoxResultadoExpedienteMedico.Multiline = true;
            txtBoxResultadoExpedienteMedico.Name = "txtBoxResultadoExpedienteMedico";
            txtBoxResultadoExpedienteMedico.ReadOnly = true;
            txtBoxResultadoExpedienteMedico.Size = new Size(645, 305);
            txtBoxResultadoExpedienteMedico.TabIndex = 0;
            txtBoxResultadoExpedienteMedico.TextChanged += txtBoxResultadoExpedienteMedico_TextChanged;
            // 
            // gbDatosExpedienteMedico
            // 
            gbDatosExpedienteMedico.Controls.Add(chkEstaVacunadoExpedienteMedico);
            gbDatosExpedienteMedico.Controls.Add(txtCostoTratamiento);
            gbDatosExpedienteMedico.Controls.Add(lblIDExpedienteMedico);
            gbDatosExpedienteMedico.Controls.Add(txtHistorial);
            gbDatosExpedienteMedico.Controls.Add(lblHistorialExpedienteMedico);
            gbDatosExpedienteMedico.Controls.Add(txtIdExpediente);
            gbDatosExpedienteMedico.Controls.Add(lblCostoTratamientoExpedienteMedico);
            gbDatosExpedienteMedico.Location = new Point(5, 25);
            gbDatosExpedienteMedico.Margin = new Padding(2);
            gbDatosExpedienteMedico.Name = "gbDatosExpedienteMedico";
            gbDatosExpedienteMedico.Padding = new Padding(2);
            gbDatosExpedienteMedico.Size = new Size(690, 393);
            gbDatosExpedienteMedico.TabIndex = 0;
            gbDatosExpedienteMedico.TabStop = false;
            gbDatosExpedienteMedico.Text = "Datos del Expediente Médico";
            gbDatosExpedienteMedico.Enter += gbDatosExpedienteMedico_Enter;
            // 
            // chkEstaVacunadoExpedienteMedico
            // 
            chkEstaVacunadoExpedienteMedico.AutoSize = true;
            chkEstaVacunadoExpedienteMedico.Location = new Point(182, 342);
            chkEstaVacunadoExpedienteMedico.Margin = new Padding(2);
            chkEstaVacunadoExpedienteMedico.Name = "chkEstaVacunadoExpedienteMedico";
            chkEstaVacunadoExpedienteMedico.Size = new Size(141, 24);
            chkEstaVacunadoExpedienteMedico.TabIndex = 7;
            chkEstaVacunadoExpedienteMedico.Text = "¿Esta Vacunado?";
            chkEstaVacunadoExpedienteMedico.UseVisualStyleBackColor = true;
            chkEstaVacunadoExpedienteMedico.CheckedChanged += chkEstaVacunadoExpedienteMedico_CheckedChanged;
            // 
            // txtCostoTratamiento
            // 
            txtCostoTratamiento.Location = new Point(182, 269);
            txtCostoTratamiento.Margin = new Padding(2);
            txtCostoTratamiento.Name = "txtCostoTratamiento";
            txtCostoTratamiento.Size = new Size(121, 27);
            txtCostoTratamiento.TabIndex = 6;
            txtCostoTratamiento.TextChanged += txtCostoTratamiento_TextChanged;
            // 
            // lblIDExpedienteMedico
            // 
            lblIDExpedienteMedico.AutoSize = true;
            lblIDExpedienteMedico.Location = new Point(14, 33);
            lblIDExpedienteMedico.Margin = new Padding(2, 0, 2, 0);
            lblIDExpedienteMedico.Name = "lblIDExpedienteMedico";
            lblIDExpedienteMedico.Size = new Size(27, 20);
            lblIDExpedienteMedico.TabIndex = 1;
            lblIDExpedienteMedico.Text = "ID:";
            lblIDExpedienteMedico.Click += lblIDExpedienteMedico_Click;
            // 
            // txtHistorial
            // 
            txtHistorial.Location = new Point(182, 72);
            txtHistorial.Margin = new Padding(2);
            txtHistorial.Multiline = true;
            txtHistorial.Name = "txtHistorial";
            txtHistorial.Size = new Size(504, 173);
            txtHistorial.TabIndex = 5;
            txtHistorial.TextChanged += txtHistorial_TextChanged;
            // 
            // lblHistorialExpedienteMedico
            // 
            lblHistorialExpedienteMedico.AutoSize = true;
            lblHistorialExpedienteMedico.Location = new Point(14, 72);
            lblHistorialExpedienteMedico.Margin = new Padding(2, 0, 2, 0);
            lblHistorialExpedienteMedico.Name = "lblHistorialExpedienteMedico";
            lblHistorialExpedienteMedico.Size = new Size(68, 20);
            lblHistorialExpedienteMedico.TabIndex = 2;
            lblHistorialExpedienteMedico.Text = "Historial:";
            lblHistorialExpedienteMedico.Click += lblHistorialExpedienteMedico_Click;
            // 
            // txtIdExpediente
            // 
            txtIdExpediente.Location = new Point(182, 30);
            txtIdExpediente.Margin = new Padding(2);
            txtIdExpediente.Name = "txtIdExpediente";
            txtIdExpediente.Size = new Size(121, 27);
            txtIdExpediente.TabIndex = 4;
            txtIdExpediente.TextChanged += txtIdExpediente_TextChanged;
            // 
            // lblCostoTratamientoExpedienteMedico
            // 
            lblCostoTratamientoExpedienteMedico.AutoSize = true;
            lblCostoTratamientoExpedienteMedico.Location = new Point(14, 269);
            lblCostoTratamientoExpedienteMedico.Margin = new Padding(2, 0, 2, 0);
            lblCostoTratamientoExpedienteMedico.Name = "lblCostoTratamientoExpedienteMedico";
            lblCostoTratamientoExpedienteMedico.RightToLeft = RightToLeft.No;
            lblCostoTratamientoExpedienteMedico.Size = new Size(134, 20);
            lblCostoTratamientoExpedienteMedico.TabIndex = 3;
            lblCostoTratamientoExpedienteMedico.Text = "Costo Tratamiento:";
            lblCostoTratamientoExpedienteMedico.Click += lblCostoTratamientoExpedienteMedico_Click;
            // 
            // TabPageAnimales
            // 
            TabPageAnimales.Controls.Add(btnDestruirAnimalRescatado);
            TabPageAnimales.Controls.Add(btnBorrarAnimalRescatado);
            TabPageAnimales.Controls.Add(btnActualizarAnimalRescatado);
            TabPageAnimales.Controls.Add(btnMostrarAnimalRescatado);
            TabPageAnimales.Controls.Add(btnBuscarAnimalRescatado);
            TabPageAnimales.Controls.Add(btnCrearAnimalRescatado);
            TabPageAnimales.Controls.Add(gbResultadoAnimalRescatado);
            TabPageAnimales.Controls.Add(gbDatosAnimalRescatado);
            TabPageAnimales.Location = new Point(4, 29);
            TabPageAnimales.Margin = new Padding(2);
            TabPageAnimales.Name = "TabPageAnimales";
            TabPageAnimales.Padding = new Padding(2);
            TabPageAnimales.Size = new Size(1394, 513);
            TabPageAnimales.TabIndex = 1;
            TabPageAnimales.Text = "Animales Rescatados";
            TabPageAnimales.UseVisualStyleBackColor = true;
            TabPageAnimales.Click += TabPageAnimales_Click;
            // 
            // btnDestruirAnimalRescatado
            // 
            btnDestruirAnimalRescatado.Location = new Point(664, 470);
            btnDestruirAnimalRescatado.Margin = new Padding(2);
            btnDestruirAnimalRescatado.Name = "btnDestruirAnimalRescatado";
            btnDestruirAnimalRescatado.Size = new Size(90, 27);
            btnDestruirAnimalRescatado.TabIndex = 10;
            btnDestruirAnimalRescatado.Text = "Destruir";
            btnDestruirAnimalRescatado.UseVisualStyleBackColor = true;
            btnDestruirAnimalRescatado.Click += btnDestruirAnimalRescatado_Click;
            // 
            // btnBorrarAnimalRescatado
            // 
            btnBorrarAnimalRescatado.Location = new Point(550, 470);
            btnBorrarAnimalRescatado.Margin = new Padding(2);
            btnBorrarAnimalRescatado.Name = "btnBorrarAnimalRescatado";
            btnBorrarAnimalRescatado.Size = new Size(90, 27);
            btnBorrarAnimalRescatado.TabIndex = 8;
            btnBorrarAnimalRescatado.Text = "Borrar";
            btnBorrarAnimalRescatado.UseVisualStyleBackColor = true;
            btnBorrarAnimalRescatado.Click += btnBorrarAnimalRescatado_Click;
            // 
            // btnActualizarAnimalRescatado
            // 
            btnActualizarAnimalRescatado.Location = new Point(436, 470);
            btnActualizarAnimalRescatado.Margin = new Padding(2);
            btnActualizarAnimalRescatado.Name = "btnActualizarAnimalRescatado";
            btnActualizarAnimalRescatado.Size = new Size(90, 27);
            btnActualizarAnimalRescatado.TabIndex = 9;
            btnActualizarAnimalRescatado.Text = "Actualizar";
            btnActualizarAnimalRescatado.UseVisualStyleBackColor = true;
            btnActualizarAnimalRescatado.Click += button4_Click;
            // 
            // btnMostrarAnimalRescatado
            // 
            btnMostrarAnimalRescatado.Location = new Point(201, 470);
            btnMostrarAnimalRescatado.Margin = new Padding(2);
            btnMostrarAnimalRescatado.Name = "btnMostrarAnimalRescatado";
            btnMostrarAnimalRescatado.Size = new Size(90, 27);
            btnMostrarAnimalRescatado.TabIndex = 5;
            btnMostrarAnimalRescatado.Text = "Mostrar";
            btnMostrarAnimalRescatado.UseVisualStyleBackColor = true;
            btnMostrarAnimalRescatado.Click += btnMostrarAnimalRescatado_Click;
            // 
            // btnBuscarAnimalRescatado
            // 
            btnBuscarAnimalRescatado.Location = new Point(322, 470);
            btnBuscarAnimalRescatado.Margin = new Padding(2);
            btnBuscarAnimalRescatado.Name = "btnBuscarAnimalRescatado";
            btnBuscarAnimalRescatado.Size = new Size(90, 27);
            btnBuscarAnimalRescatado.TabIndex = 4;
            btnBuscarAnimalRescatado.Text = "Buscar";
            btnBuscarAnimalRescatado.UseVisualStyleBackColor = true;
            btnBuscarAnimalRescatado.Click += btnBuscarAnimalRescatado_Click;
            // 
            // btnCrearAnimalRescatado
            // 
            btnCrearAnimalRescatado.Location = new Point(79, 470);
            btnCrearAnimalRescatado.Margin = new Padding(2);
            btnCrearAnimalRescatado.Name = "btnCrearAnimalRescatado";
            btnCrearAnimalRescatado.Size = new Size(90, 27);
            btnCrearAnimalRescatado.TabIndex = 3;
            btnCrearAnimalRescatado.Text = "Crear";
            btnCrearAnimalRescatado.UseVisualStyleBackColor = true;
            btnCrearAnimalRescatado.Click += btnCrearAnimalRescatado_Click;
            // 
            // gbResultadoAnimalRescatado
            // 
            gbResultadoAnimalRescatado.Controls.Add(txtBoxResultadoAnimalRescatado);
            gbResultadoAnimalRescatado.Location = new Point(729, 5);
            gbResultadoAnimalRescatado.Margin = new Padding(2);
            gbResultadoAnimalRescatado.Name = "gbResultadoAnimalRescatado";
            gbResultadoAnimalRescatado.Padding = new Padding(2);
            gbResultadoAnimalRescatado.Size = new Size(667, 460);
            gbResultadoAnimalRescatado.TabIndex = 1;
            gbResultadoAnimalRescatado.TabStop = false;
            gbResultadoAnimalRescatado.Text = "Resultado / Salida";
            gbResultadoAnimalRescatado.Enter += gbResultadoAnimal_Enter;
            // 
            // txtBoxResultadoAnimalRescatado
            // 
            txtBoxResultadoAnimalRescatado.Location = new Point(18, 47);
            txtBoxResultadoAnimalRescatado.Margin = new Padding(2);
            txtBoxResultadoAnimalRescatado.Multiline = true;
            txtBoxResultadoAnimalRescatado.Name = "txtBoxResultadoAnimalRescatado";
            txtBoxResultadoAnimalRescatado.ReadOnly = true;
            txtBoxResultadoAnimalRescatado.Size = new Size(611, 297);
            txtBoxResultadoAnimalRescatado.TabIndex = 0;
            txtBoxResultadoAnimalRescatado.TextChanged += txtBoxResultadoAnimalRescatado_TextChanged;
            // 
            // gbDatosAnimalRescatado
            // 
            gbDatosAnimalRescatado.Controls.Add(txtBoxPesoAnimalRescatado);
            gbDatosAnimalRescatado.Controls.Add(lblPesoAnimalRescatado);
            gbDatosAnimalRescatado.Controls.Add(cmbEspecieAnimalRescatado);
            gbDatosAnimalRescatado.Controls.Add(txtBoxNombreAnimalRescatado);
            gbDatosAnimalRescatado.Controls.Add(txtBoxIDAnimalRescatado);
            gbDatosAnimalRescatado.Controls.Add(lblEspecieAnimalRescatado);
            gbDatosAnimalRescatado.Controls.Add(lblNombreAnimalRescatado);
            gbDatosAnimalRescatado.Controls.Add(lblIDAnimalRescatado);
            gbDatosAnimalRescatado.Location = new Point(-3, 5);
            gbDatosAnimalRescatado.Margin = new Padding(2);
            gbDatosAnimalRescatado.Name = "gbDatosAnimalRescatado";
            gbDatosAnimalRescatado.Padding = new Padding(2);
            gbDatosAnimalRescatado.Size = new Size(727, 460);
            gbDatosAnimalRescatado.TabIndex = 0;
            gbDatosAnimalRescatado.TabStop = false;
            gbDatosAnimalRescatado.Text = "Datos del Animal Rescatado";
            gbDatosAnimalRescatado.Enter += gbDatosAnimalRescatado_Enter;
            // 
            // txtBoxPesoAnimalRescatado
            // 
            txtBoxPesoAnimalRescatado.Location = new Point(232, 263);
            txtBoxPesoAnimalRescatado.Margin = new Padding(2);
            txtBoxPesoAnimalRescatado.Name = "txtBoxPesoAnimalRescatado";
            txtBoxPesoAnimalRescatado.Size = new Size(121, 27);
            txtBoxPesoAnimalRescatado.TabIndex = 7;
            txtBoxPesoAnimalRescatado.TextChanged += txtBoxPesoAnimalRescatado_TextChanged;
            // 
            // lblPesoAnimalRescatado
            // 
            lblPesoAnimalRescatado.AutoSize = true;
            lblPesoAnimalRescatado.Location = new Point(51, 254);
            lblPesoAnimalRescatado.Margin = new Padding(2, 0, 2, 0);
            lblPesoAnimalRescatado.Name = "lblPesoAnimalRescatado";
            lblPesoAnimalRescatado.Size = new Size(72, 20);
            lblPesoAnimalRescatado.TabIndex = 6;
            lblPesoAnimalRescatado.Text = "Peso (kg):";
            lblPesoAnimalRescatado.Click += lblPesoAnimalRescatado_Click;
            // 
            // cmbEspecieAnimalRescatado
            // 
            cmbEspecieAnimalRescatado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEspecieAnimalRescatado.FormattingEnabled = true;
            cmbEspecieAnimalRescatado.Items.AddRange(new object[] { "Canino", "Felino", "Ave ", "Otro" });
            cmbEspecieAnimalRescatado.Location = new Point(232, 188);
            cmbEspecieAnimalRescatado.Margin = new Padding(2);
            cmbEspecieAnimalRescatado.Name = "cmbEspecieAnimalRescatado";
            cmbEspecieAnimalRescatado.Size = new Size(146, 28);
            cmbEspecieAnimalRescatado.TabIndex = 5;
            cmbEspecieAnimalRescatado.SelectedIndexChanged += cmbEspecieAnimalRescatado_SelectedIndexChanged;
            // 
            // txtBoxNombreAnimalRescatado
            // 
            txtBoxNombreAnimalRescatado.Location = new Point(232, 111);
            txtBoxNombreAnimalRescatado.Margin = new Padding(2);
            txtBoxNombreAnimalRescatado.Name = "txtBoxNombreAnimalRescatado";
            txtBoxNombreAnimalRescatado.Size = new Size(121, 27);
            txtBoxNombreAnimalRescatado.TabIndex = 4;
            txtBoxNombreAnimalRescatado.TextChanged += txtBoxNombreAnimalRescatado_TextChanged;
            // 
            // txtBoxIDAnimalRescatado
            // 
            txtBoxIDAnimalRescatado.Location = new Point(232, 51);
            txtBoxIDAnimalRescatado.Margin = new Padding(2);
            txtBoxIDAnimalRescatado.Name = "txtBoxIDAnimalRescatado";
            txtBoxIDAnimalRescatado.Size = new Size(121, 27);
            txtBoxIDAnimalRescatado.TabIndex = 3;
            txtBoxIDAnimalRescatado.TextChanged += txtBoxIDAnimalRescatado_TextChanged;
            // 
            // lblEspecieAnimalRescatado
            // 
            lblEspecieAnimalRescatado.AutoSize = true;
            lblEspecieAnimalRescatado.Location = new Point(51, 194);
            lblEspecieAnimalRescatado.Margin = new Padding(2, 0, 2, 0);
            lblEspecieAnimalRescatado.Name = "lblEspecieAnimalRescatado";
            lblEspecieAnimalRescatado.Size = new Size(62, 20);
            lblEspecieAnimalRescatado.TabIndex = 2;
            lblEspecieAnimalRescatado.Text = "Especie:";
            lblEspecieAnimalRescatado.Click += lblEspecieAnimalRescatado_Click;
            // 
            // lblNombreAnimalRescatado
            // 
            lblNombreAnimalRescatado.AutoSize = true;
            lblNombreAnimalRescatado.Location = new Point(51, 114);
            lblNombreAnimalRescatado.Margin = new Padding(2, 0, 2, 0);
            lblNombreAnimalRescatado.Name = "lblNombreAnimalRescatado";
            lblNombreAnimalRescatado.Size = new Size(67, 20);
            lblNombreAnimalRescatado.TabIndex = 1;
            lblNombreAnimalRescatado.Text = "Nombre:";
            lblNombreAnimalRescatado.Click += lblNombreAnimalRescatado_Click;
            // 
            // lblIDAnimalRescatado
            // 
            lblIDAnimalRescatado.AutoSize = true;
            lblIDAnimalRescatado.Location = new Point(51, 51);
            lblIDAnimalRescatado.Margin = new Padding(2, 0, 2, 0);
            lblIDAnimalRescatado.Name = "lblIDAnimalRescatado";
            lblIDAnimalRescatado.Size = new Size(27, 20);
            lblIDAnimalRescatado.TabIndex = 0;
            lblIDAnimalRescatado.Text = "ID:";
            lblIDAnimalRescatado.Click += lblIDAnimalRescatado_Click;
            // 
            // lblAutores
            // 
            lblAutores.AutoSize = true;
            lblAutores.Location = new Point(54, 555);
            lblAutores.Margin = new Padding(2, 0, 2, 0);
            lblAutores.Name = "lblAutores";
            lblAutores.Size = new Size(976, 20);
            lblAutores.TabIndex = 0;
            lblAutores.Text = "FLORES MONTAÑO Roberto Carlos, GONZALEZ ALVARADO Alexa Michelle, MALDONADO LLAMAS Oswaldo Daniel - Equipo Animales Rescatados";
            lblAutores.Click += lblAutor_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1421, 669);
            Controls.Add(lblAutores);
            Controls.Add(tabControl1);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            TabPageExpedientes.ResumeLayout(false);
            gbResultadoExpedienteMedico.ResumeLayout(false);
            gbResultadoExpedienteMedico.PerformLayout();
            gbDatosExpedienteMedico.ResumeLayout(false);
            gbDatosExpedienteMedico.PerformLayout();
            TabPageAnimales.ResumeLayout(false);
            gbResultadoAnimalRescatado.ResumeLayout(false);
            gbResultadoAnimalRescatado.PerformLayout();
            gbDatosAnimalRescatado.ResumeLayout(false);
            gbDatosAnimalRescatado.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage TabPageExpedientes;
        private TabPage TabPageAnimales;
        private Label lblAutores;
        private GroupBox gbDatosExpedienteMedico;
        private TextBox txtCostoTratamiento;
        private Label lblID;
        private TextBox txtHistorial;
        private Label lblHistorialExpedienteMedico;
        private TextBox txtIdExpediente;
        private Label lblCostoTratamientoExpedienteMedico;
        private CheckBox chkEstaVacunadoExpedienteMedico;
        private GroupBox gbResultadoExpedienteMedico;
        private TextBox txtBoxResultadoExpedienteMedico;
        private GroupBox gbDatosAnimalRescatado;
        private ComboBox cmbEspecieAnimalRescatado;
        private TextBox txtBoxNombreAnimalRescatado;
        private TextBox txtBoxIDAnimalRescatado;
        private Label lblEspecieAnimalRescatado;
        private Label lblNombreAnimalRescatado;
        private Label lblIDAnimalRescatado;
        private TextBox txtBoxPesoAnimalRescatado;
        private Label lblPesoAnimalRescatado;
        private GroupBox gbResultadoAnimalRescatado;
        private TextBox txtBoxResultadoAnimalRescatado;
        private Button btnDestruirExpedienteMedico;
        private Button btnBorrarExpedienteMedico;
        private Button btnActualizarExpedienteMedico;
        private Button btnMostrarExpedienteMedico;
        private Button btnBuscarExpedienteMedico;
        private Button btnCrearExpedienteMedico;
        private Button btnDestruirAnimalRescatado;
        private Button btnBorrarAnimalRescatado;
        private Button btnActualizarAnimalRescatado;
        private Button btnMostrarAnimalRescatado;
        private Button btnBuscarAnimalRescatado;
        private Button btnCrearAnimalRescatado;
        private Label lblIDExpedienteMedico;
    }
}
