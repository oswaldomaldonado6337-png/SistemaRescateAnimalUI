namespace SistemaRescateAnimalUI
{
    partial class FrmVentas
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
            grpCatalogo = new GroupBox();
            numCantidad = new NumericUpDown();
            dgvProductos = new DataGridView();
            btnAgregarCarrito = new Button();
            btnBuscarId = new Button();
            txtBuscarNombre = new TextBox();
            txtBuscarId = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            grpCarrito = new GroupBox();
            lblTotalVenta = new Label();
            btnQuitarProducto = new Button();
            dgvCarrito = new DataGridView();
            btnConfirmarPedido = new Button();
            grpCatalogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            grpCarrito.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(15, 10);
            label1.Name = "label1";
            label1.Size = new Size(995, 42);
            label1.TabIndex = 0;
            label1.Text = "FLORES MONTAÑO Roberto Carlos, GONZALEZ ALVARADO Alexa Michelle, MALDONADO LLAMAS Oswaldo Daniel - Equipo [E5]";
            // 
            // grpCatalogo
            // 
            grpCatalogo.Controls.Add(numCantidad);
            grpCatalogo.Controls.Add(dgvProductos);
            grpCatalogo.Controls.Add(btnAgregarCarrito);
            grpCatalogo.Controls.Add(btnBuscarId);
            grpCatalogo.Controls.Add(txtBuscarNombre);
            grpCatalogo.Controls.Add(txtBuscarId);
            grpCatalogo.Controls.Add(label4);
            grpCatalogo.Controls.Add(label3);
            grpCatalogo.Controls.Add(label2);
            grpCatalogo.Location = new Point(15, 60);
            grpCatalogo.Name = "grpCatalogo";
            grpCatalogo.Size = new Size(485, 445);
            grpCatalogo.TabIndex = 1;
            grpCatalogo.TabStop = false;
            grpCatalogo.Text = "1. Búsqueda y Catálogo de Productos";
            // 
            // numCantidad
            // 
            numCantidad.Location = new Point(85, 398);
            numCantidad.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCantidad.Name = "numCantidad";
            numCantidad.Size = new Size(85, 31);
            numCantidad.TabIndex = 8;
            numCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(15, 102);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowHeadersWidth = 62;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(455, 280);
            dgvProductos.TabIndex = 7;
            // 
            // btnAgregarCarrito
            // 
            btnAgregarCarrito.BackColor = Color.MediumSeaGreen;
            btnAgregarCarrito.FlatStyle = FlatStyle.Flat;
            btnAgregarCarrito.ForeColor = Color.White;
            btnAgregarCarrito.Location = new Point(185, 392);
            btnAgregarCarrito.Name = "btnAgregarCarrito";
            btnAgregarCarrito.Size = new Size(285, 36);
            btnAgregarCarrito.TabIndex = 6;
            btnAgregarCarrito.Text = "Añadir al Carrito >>";
            btnAgregarCarrito.UseVisualStyleBackColor = false;
            btnAgregarCarrito.Click += btnAgregarCarrito_Click;
            // 
            // btnBuscarId
            // 
            btnBuscarId.Location = new Point(245, 27);
            btnBuscarId.Name = "btnBuscarId";
            btnBuscarId.Size = new Size(105, 28);
            btnBuscarId.TabIndex = 5;
            btnBuscarId.Text = "Buscar ID";
            btnBuscarId.UseVisualStyleBackColor = true;
            btnBuscarId.Click += btnBuscarId_Click;
            // 
            // txtBuscarNombre
            // 
            txtBuscarNombre.Location = new Point(155, 68);
            txtBuscarNombre.Name = "txtBuscarNombre";
            txtBuscarNombre.Size = new Size(150, 31);
            txtBuscarNombre.TabIndex = 4;
            txtBuscarNombre.Click += txtBuscarNombre_TextChanged;
            txtBuscarNombre.TextChanged += txtBuscarNombre_TextChanged;
            // 
            // txtBuscarId
            // 
            txtBuscarId.Location = new Point(95, 29);
            txtBuscarId.Name = "txtBuscarId";
            txtBuscarId.Size = new Size(140, 31);
            txtBuscarId.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 68);
            label4.Name = "label4";
            label4.Size = new Size(113, 25);
            label4.TabIndex = 2;
            label4.Text = "Por Nombre:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 400);
            label3.Name = "label3";
            label3.Size = new Size(87, 25);
            label3.TabIndex = 1;
            label3.Text = "Cantidad:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 32);
            label2.Name = "label2";
            label2.Size = new Size(90, 25);
            label2.TabIndex = 0;
            label2.Text = "Buscar ID:";
            // 
            // grpCarrito
            // 
            grpCarrito.Controls.Add(lblTotalVenta);
            grpCarrito.Controls.Add(btnQuitarProducto);
            grpCarrito.Controls.Add(dgvCarrito);
            grpCarrito.Location = new Point(515, 60);
            grpCarrito.Name = "grpCarrito";
            grpCarrito.Size = new Size(495, 385);
            grpCarrito.TabIndex = 2;
            grpCarrito.TabStop = false;
            grpCarrito.Text = "2. Carrito de Compras Temporal";
            // 
            // lblTotalVenta
            // 
            lblTotalVenta.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalVenta.ForeColor = Color.DarkGreen;
            lblTotalVenta.Location = new Point(190, 328);
            lblTotalVenta.Name = "lblTotalVenta";
            lblTotalVenta.Size = new Size(290, 40);
            lblTotalVenta.TabIndex = 2;
            lblTotalVenta.Text = "Total: $0.00";
            lblTotalVenta.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnQuitarProducto
            // 
            btnQuitarProducto.BackColor = Color.IndianRed;
            btnQuitarProducto.FlatStyle = FlatStyle.Flat;
            btnQuitarProducto.ForeColor = Color.White;
            btnQuitarProducto.Location = new Point(15, 330);
            btnQuitarProducto.Name = "btnQuitarProducto";
            btnQuitarProducto.Size = new Size(165, 38);
            btnQuitarProducto.TabIndex = 1;
            btnQuitarProducto.Text = "Quitar Seleccionado";
            btnQuitarProducto.UseVisualStyleBackColor = false;
            btnQuitarProducto.Click += btnQuitarProducto_Click;
            // 
            // dgvCarrito
            // 
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Location = new Point(15, 30);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.RowHeadersVisible = false;
            dgvCarrito.RowHeadersWidth = 62;
            dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarrito.Size = new Size(465, 285);
            dgvCarrito.TabIndex = 0;
            // 
            // btnConfirmarPedido
            // 
            btnConfirmarPedido.BackColor = Color.DodgerBlue;
            btnConfirmarPedido.FlatStyle = FlatStyle.Flat;
            btnConfirmarPedido.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirmarPedido.ForeColor = Color.White;
            btnConfirmarPedido.Location = new Point(515, 455);
            btnConfirmarPedido.Name = "btnConfirmarPedido";
            btnConfirmarPedido.Size = new Size(495, 48);
            btnConfirmarPedido.TabIndex = 3;
            btnConfirmarPedido.Text = "Confirmar Pedido";
            btnConfirmarPedido.UseVisualStyleBackColor = false;
            btnConfirmarPedido.Click += btnConfirmarPedido_Click;
            // 
            // FrmVentas
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1018, 504);
            Controls.Add(btnConfirmarPedido);
            Controls.Add(grpCarrito);
            Controls.Add(grpCatalogo);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Terminal de Ventas y Pedidos";
            grpCatalogo.ResumeLayout(false);
            grpCatalogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            grpCarrito.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private GroupBox grpCatalogo;
        private TextBox txtBuscarNombre;
        private TextBox txtBuscarId;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnAgregarCarrito;
        private Button btnBuscarId;
        private NumericUpDown numCantidad;
        private DataGridView dgvProductos;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private GroupBox grpCarrito;
        private Button btnQuitarProducto;
        private DataGridView dgvCarrito;
        private Label lblTotalVenta;
        private Button btnConfirmarPedido;
    }
}