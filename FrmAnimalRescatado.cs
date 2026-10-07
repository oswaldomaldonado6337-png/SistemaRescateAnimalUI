//INTEGRANTES: 
//Alexa Michelle Gonzalez Alvarado,Maldonado Llamas Oswaldo Daniel, Flores Carlos Roberto
//FRM ANIMALRESCATADO

using System;
using System.Windows.Forms;
using SistemaRescateAnimal.Models;
using SistemaRescateAnimalUI.Models;

namespace SistemaRescateAnimalUI
{
    public partial class FrmAnimalRescatado : FrmBase, IPanelCRUD
    {
        
        private static AnimalRescatado _modeloAnimal = new AnimalRescatado();

        public FrmAnimalRescatado()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(1100, 800);
            InicializarControlesPila();
            InicializarControlesLista();
        }

        public void EjecutarGuardar()
        {
            try
            {
                // Toma el ID de la caja local o lo solicita
                string idFinal = string.IsNullOrWhiteSpace(txtId.Text) ? "101" : txtId.Text;

                AnimalRescatado animal = new AnimalRescatado
                {
                    Id = idFinal,
                    Nombre = txtNombre.Text,
                    Especie = txtEspecie.Text,
                    Peso = double.TryParse(numPeso.Text, out double p) ? p : 0.0,
                    FechaRegistro = dtpFechaRegistro.Value,
                    EsActivo = chkEsActivo.Checked
                };

                _modeloAnimal.InsertarRegistro(animal);
                MessageBox.Show($"Animal '{animal.Nombre}' guardado correctamente con ID: {animal.Id}", "Sistema de Rescate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void EjecutarBuscar(string id, ErrorProvider alerta)
        {
            alerta.Clear();

            if (string.IsNullOrWhiteSpace(id))
            {
                alerta.SetError(txtId, "Ingrese un ID válido para buscar.");
                return;
            }

            var resultado = _modeloAnimal.ConsultarRegistro(id) as AnimalRescatado;

            if (resultado != null)
            {
                // Asignar el ID encontrado al control de texto
                txtId.Text = resultado.Id;
                txtNombre.Text = resultado.Nombre;
                txtEspecie.Text = resultado.Especie;
                numPeso.Text = resultado.Peso.ToString();
                dtpFechaRegistro.Value = resultado.FechaRegistro;
                chkEsActivo.Checked = resultado.EsActivo;

                MessageBox.Show($"Registro encontrado: {resultado.Nombre}", "Búsqueda exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"No se encontró ningún animal registrado con el ID: {id}", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void EjecutarActualizar()
        {
            try
            {
                AnimalRescatado animal = new AnimalRescatado
                {
                    Id = txtId.Text,
                    Nombre = txtNombre.Text,
                    Especie = txtEspecie.Text,
                    Peso = double.TryParse(numPeso.Text, out double p) ? p : 0.0,
                    FechaRegistro = dtpFechaRegistro.Value,
                    EsActivo = chkEsActivo.Checked
                };

                _modeloAnimal.ActualizarRegistro(animal);
                MessageBox.Show("Registro actualizado correctamente.", "Sistema de Rescate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar: {ex.Message}", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void EjecutarEliminar(StatusStrip barraEstado)
        {
            try
            {
                string idAEliminar = txtId.Text;

                if (string.IsNullOrWhiteSpace(idAEliminar))
                {
                    MessageBox.Show("Seleccione o busque un registro primero para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _modeloAnimal.EliminarRegistro(idAEliminar);

                // Solución al crash de la barra de estado: validar existencia de ítems
                if (barraEstado != null)
                {
                    if (barraEstado.Items.Count == 0)
                    {
                        barraEstado.Items.Add("Listo");
                    }
                    barraEstado.Items[0].Text = $"Registro con ID {idAEliminar} ha sido eliminado.";
                }

                MessageBox.Show($"Registro con ID {idAEliminar} eliminado correctamente.", "Sistema de Rescate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LimpiarFormulario()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtEspecie.Text = string.Empty;
            numPeso.Text = "0";
            chkEsActivo.Checked = false;
            dtpFechaRegistro.Value = DateTime.Now;
        }

        //instancia :)
        private AnimalHistorial historialPila = new AnimalHistorial();

        private TextBox txtEstado;
        private Button btnRegistrarEstado;
        private Button btnRegistrar;
        private Button btnDeshacer;
        private ListBox lstHistorial;
        private Label lblCima;
        private Label lblAutor;

        private void InicializarControlesPila()
        {
            Label lblInstruccion = new Label();
            lblInstruccion.Text = "Estado del animal a registrar: ";
            lblInstruccion.Location = new System.Drawing.Point(350, 200); // <-- MOVIDO
            lblInstruccion.AutoSize = true;
            this.Controls.Add(lblInstruccion);

            
            this.txtEstado = new TextBox();
            this.txtEstado.Location = new System.Drawing.Point(350, 220); // <-- MOVIDO
            this.txtEstado.Size = new System.Drawing.Size(200, 20);
            this.Controls.Add(this.txtEstado);

            this.btnRegistrarEstado = new Button();
            this.btnRegistrarEstado.Text = "Registrar Estado";
            this.btnRegistrarEstado.Location = new System.Drawing.Point(350, 250); // <-- MOVIDO
            this.btnRegistrarEstado.Size = new System.Drawing.Size(120, 30);
            this.btnRegistrarEstado.Click += new EventHandler(this.btnRegistrarEstado_Click);
            this.Controls.Add(this.btnRegistrarEstado);

           
            this.btnDeshacer = new Button();
            this.btnDeshacer.Text = "Deshacer Último";
            this.btnDeshacer.Location = new System.Drawing.Point(480, 250); // <-- MOVIDO
            this.btnDeshacer.Size = new System.Drawing.Size(120, 30);
            this.btnDeshacer.Click += new EventHandler(this.btnDeshacer_Click);
            this.Controls.Add(this.btnDeshacer);

            this.lstHistorial = new ListBox();
            this.lstHistorial.Location = new System.Drawing.Point(350, 290); // <-- MOVIDO
            this.lstHistorial.Size = new System.Drawing.Size(250, 150);
            this.Controls.Add(this.lstHistorial);

           
            this.lblCima = new Label();
            this.lblCima.Text = "Cima: (vacía)";
            this.lblCima.Location = new System.Drawing.Point(350, 450); // <-- MOVIDO
            this.lblCima.AutoSize = true;
            this.Controls.Add(this.lblCima);

           
            this.lblAutor = new Label();
            this.lblAutor.Text = "EQUIPO: Alexa Michelle Gonzalez Alvarado, Maldonado Llamas Oswaldo Daniel, Flores Carlos Roberto";
            this.lblAutor.Location = new System.Drawing.Point(30, 650); // <-- MOVIDO HASTA ABAJO
            this.lblAutor.AutoSize = true;
            this.Controls.Add(this.lblAutor);
        }

        

        private void btnRegistrarEstado_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEstado.Text))
            {
                return;
            }
            historialPila.Push(txtEstado.Text);
            txtEstado.Clear();
            ActualizarInterfaz();
        }
        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            historialPila.Pop();
            ActualizarInterfaz();
        }
        private void ActualizarInterfaz()
        {
            lstHistorial.Items.Clear();
            List<string> lista = historialPila.VolcarArreglo();
            foreach (string item in lista)
            {
                lstHistorial.Items.Add(item);
            }

            if (historialPila.Count() == 0)
            {
                btnDeshacer.Enabled = false;
                lblCima.Text = "Cima: (Vacia) ";

            }
            else
            {
                btnDeshacer.Enabled = true;
                lblCima.Text = "Cima: " + historialPila.Peek();
            }


        }

        private void FrmAnimalRescatado_Load(object sender, EventArgs e)
        {

        }

    private HistorialClinico miHistorial = new HistorialClinico();

       
        private TextBox txtIdVacuna;
        private TextBox txtNombreVacuna;
        private Button btnAgregarDetalle;
        private Button btnEliminarDetalle;
        private DataGridView dgvVacunas;
        private Label lblContadorVacunas;

        
        private void InicializarControlesLista()
        {
           
            Label lblId = new Label();
            lblId.Text = "ID Vacuna:";
            lblId.Location = new System.Drawing.Point(650, 200);
            lblId.AutoSize = true;
            this.Controls.Add(lblId);

            
            this.txtIdVacuna = new TextBox();
            this.txtIdVacuna.Location = new System.Drawing.Point(650, 220); 
            this.txtIdVacuna.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(this.txtIdVacuna);

            
            Label lblNom = new Label();
            lblNom.Text = "Nombre Vacuna:";
            lblNom.Location = new System.Drawing.Point(650, 250); 
            lblNom.AutoSize = true;
            this.Controls.Add(lblNom);

            
            this.txtNombreVacuna = new TextBox();
            this.txtNombreVacuna.Location = new System.Drawing.Point(650, 270); 
            this.txtNombreVacuna.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(this.txtNombreVacuna);

            
            this.btnAgregarDetalle = new Button();
            this.btnAgregarDetalle.Text = "Agregar Detalle";
            this.btnAgregarDetalle.Location = new System.Drawing.Point(650, 300); 
            this.btnAgregarDetalle.Size = new System.Drawing.Size(120, 30);
            this.btnAgregarDetalle.Click += new EventHandler(this.btnAgregarDetalle_Click);
            this.Controls.Add(this.btnAgregarDetalle);

            
            this.btnEliminarDetalle = new Button();
            this.btnEliminarDetalle.Text = "Eliminar por ID";
            this.btnEliminarDetalle.Location = new System.Drawing.Point(780, 300); 
            this.btnEliminarDetalle.Size = new System.Drawing.Size(120, 30);
            this.btnEliminarDetalle.Click += new EventHandler(this.btnEliminarDetalle_Click);
            this.Controls.Add(this.btnEliminarDetalle);

            
            this.dgvVacunas = new DataGridView();
            this.dgvVacunas.Location = new System.Drawing.Point(650, 350); 
            this.dgvVacunas.Size = new System.Drawing.Size(400, 200);
            this.dgvVacunas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Controls.Add(this.dgvVacunas);

            
            this.lblContadorVacunas = new Label();
            this.lblContadorVacunas.Text = "Total vacunas: 0";
            this.lblContadorVacunas.Location = new System.Drawing.Point(650, 560); 
            this.lblContadorVacunas.AutoSize = true;
            this.Controls.Add(this.lblContadorVacunas);
        }

        
        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdVacuna.Text) || string.IsNullOrWhiteSpace(txtNombreVacuna.Text))
            {
                MessageBox.Show("Por favor, llene todos los campos de la vacuna.", "Aviso");
                return;
            }

            if (miHistorial.ExisteVacuna(txtIdVacuna.Text) == true)
            {
                MessageBox.Show("Ya existe una vacuna con ese ID.", "Error");
                return;
            }

            Vacuna nueva = new Vacuna();
            nueva.Id = txtIdVacuna.Text;
            nueva.Nombre = txtNombreVacuna.Text;
            nueva.FechaAplicacion = DateTime.Now;
            nueva.EsActiva = true;

            miHistorial.RegistrarElementos(nueva);

            txtIdVacuna.Clear();
            txtNombreVacuna.Clear();

            ActualizarVistaLista();
        }

        // EVENTO ELIMINAR DETALLE
        private void btnEliminarDetalle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdVacuna.Text))
            {
                MessageBox.Show("Escriba el ID de la vacuna a eliminar.", "Aviso");
                return;
            }

            miHistorial.EliminarPorID(txtIdVacuna.Text);
            txtIdVacuna.Clear();

            ActualizarVistaLista();
        }

        // MÉTODO QUE SINCRONIZA LA VISTA CON LA COLECCIÓN
        private void ActualizarVistaLista()
        {
            dgvVacunas.DataSource = null;
            dgvVacunas.DataSource = miHistorial.ListaVacunas;

            lblContadorVacunas.Text = "Total vacunas: " + miHistorial.ContarElementos().ToString();
        }

    } 
}