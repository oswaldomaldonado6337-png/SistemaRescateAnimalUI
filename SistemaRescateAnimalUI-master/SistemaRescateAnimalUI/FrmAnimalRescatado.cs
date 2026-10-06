//INTEGRANTES: 
//Alexa Michelle Gonzalez Alvarado,Maldonado Llamas Oswaldo Daniel, Flores Carlos Roberto

using System;
using System.Windows.Forms;
using SistemaRescateAnimal.Models;

namespace SistemaRescateAnimalUI
{
    public partial class FrmAnimalRescatado : FrmBase, IPanelCRUD
    {
        // Instancia estática o compartida del modelo para conservar los datos en memoria RAM
        private static AnimalRescatado _modeloAnimal = new AnimalRescatado();

        public FrmAnimalRescatado()
        {
            InitializeComponent();
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
            //etiqueta 

            Label lblInstruccion = new Label();
            lblInstruccion.Text = "Estado del animal a registrar: ";
            lblInstruccion.Location = new System.Drawing.Point(30, 210);
            lblInstruccion.AutoSize = true;
            this.Controls.Add(lblInstruccion);

            //textbox

            this.txtEstado = new TextBox();
            this.txtEstado.Location = new System.Drawing.Point(30, 230);
            this.txtEstado.Size = new System.Drawing.Size(250, 20);
            this.Controls.Add(this.txtEstado);

            //BOTON PARA REG

            this.btnRegistrarEstado = new Button();
            this.btnRegistrarEstado.Text = "Registrar Estado";
            this.btnRegistrarEstado.Location = new System.Drawing.Point(30, 260);
            this.btnRegistrarEstado.Size = new System.Drawing.Size(120, 30);
            this.btnRegistrarEstado.Click += new EventHandler (this.btnRegistrarEstado_Click);
            this.Controls.Add(this.btnRegistrarEstado);

            //BOTON DESHACER

            this.btnDeshacer = new Button();
            this.btnDeshacer.Text = "Deshacer Ultimo: ";
            this.btnDeshacer.Location = new System.Drawing.Point(160, 260);
            this.btnDeshacer.Size = new System.Drawing.Size(120, 30);
            this.btnDeshacer.Click += new EventHandler(this.btnDeshacer_Click);
            this.Controls.Add(this.btnDeshacer);

            //lissta

            this.lstHistorial = new ListBox();
            this.lstHistorial.Location = new System.Drawing.Point(30, 310);
            this.lstHistorial.Size = new System.Drawing.Size(250, 150);
            this.Controls.Add(this.lstHistorial);

            //lbl

            this.lblCima = new Label();
            this.lblCima.Text = "Cima: (vacia) ";
            this.lblCima.Location = new System.Drawing.Point(30, 470);
            this.lblCima.AutoSize = true;
            this.Controls.Add(this.lblCima);

            //lbl de nosotros
            this.lblAutor = new Label();
            this.lblAutor.Text = "E5: Alexa Michelle Gonzalez Alvarado" +
                "Maldonado Lllamas Oswaldo Daniel" +
                "Flores Carlos Roberto";
            this.lblAutor.Location = new System.Drawing.Point(30, 500);
            this.lblAutor.AutoSize = true;
            this.Controls.Add(this.lblAutor);
        }

        //push

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
    }
}