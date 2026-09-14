using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SistemaRescateAnimal.Models;

namespace SistemaRescateAnimalUI
{
    public partial class Form1 : Form
    {
        // Almacenamiento en memoria para los animales y expedientes
        private readonly List<AnimalRescatado> _listaAnimales = new List<AnimalRescatado>();
        private readonly List<ExpedienteMedico> _listaExpedientes = new List<ExpedienteMedico>();

        public Form1()
        {
            InitializeComponent();
        }

        #region --- PESTAÑA: ANIMALES RESCATADOS ---

        // BOTÓN: Crear Animal
        private void btnCrearAnimalRescatado_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtBoxIDAnimalRescatado.Text);
                string nombre = txtBoxNombreAnimalRescatado.Text;
                string especie = cmbEspecieAnimalRescatado.SelectedItem?.ToString() ?? cmbEspecieAnimalRescatado.Text;
                double peso = double.Parse(txtBoxPesoAnimalRescatado.Text);

                // Validar duplicado de ID
                if (_listaAnimales.Any(a => a.Id == id))
                {
                    MessageBox.Show($"Ya existe un animal registrado con el ID {id}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nuevoAnimal = new AnimalRescatado(id, nombre, especie, peso);
                _listaAnimales.Add(nuevoAnimal);

                txtBoxResultadoAnimalRescatado.Text = $"¡Animal creado exitosamente!\r\n{nuevoAnimal}\r\n" +
                                                      $"Ración de alimento estándar (3%): {nuevoAnimal.CalcularRacionAlimento():F2} g";

                LimpiarCamposAnimal();
            }
            catch (FormatException)
            {
                MessageBox.Show("Asegúrate de ingresar un ID entero y un Peso numérico válidos.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // BOTÓN: Mostrar Todos los Animales
        private void btnMostrarAnimalRescatado_Click(object sender, EventArgs e)
        {
            if (_listaAnimales.Count == 0)
            {
                txtBoxResultadoAnimalRescatado.Text = "No hay animales registrados en el sistema.";
                return;
            }

            string reporte = "=== LISTA DE ANIMALES RESCATADOS ===\r\n\r\n";
            foreach (var animal in _listaAnimales)
            {
                reporte += $"{animal} | Ración diaria: {animal.CalcularRacionAlimento():F2} g\r\n";
            }

            txtBoxResultadoAnimalRescatado.Text = reporte;
        }

        // BOTÓN: Buscar Animal por ID
        private void btnBuscarAnimalRescatado_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtBoxIDAnimalRescatado.Text);
                var animal = _listaAnimales.FirstOrDefault(a => a.Id == id);

                if (animal != null)
                {
                    txtBoxNombreAnimalRescatado.Text = animal.Nombre;
                    cmbEspecieAnimalRescatado.Text = animal.Especie;
                    txtBoxPesoAnimalRescatado.Text = animal.Peso.ToString();

                    txtBoxResultadoAnimalRescatado.Text = $"=== ANIMAL ENCONTRADO ===\r\n{animal}\r\n" +
                                                          $"Ración recomendada: {animal.CalcularRacionAlimento():F2} g";
                }
                else
                {
                    txtBoxResultadoAnimalRescatado.Text = $"No se encontró ningún animal con ID {id}.";
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingresa un ID numérico válido en el campo ID para buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // BOTÓN: Actualizar Animal por ID
        private void btnActualizarAnimalRescatado_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtBoxIDAnimalRescatado.Text);
                var animal = _listaAnimales.FirstOrDefault(a => a.Id == id);

                if (animal != null)
                {
                    animal.Nombre = txtBoxNombreAnimalRescatado.Text;
                    animal.Especie = cmbEspecieAnimalRescatado.SelectedItem?.ToString() ?? cmbEspecieAnimalRescatado.Text;
                    animal.Peso = double.Parse(txtBoxPesoAnimalRescatado.Text);

                    txtBoxResultadoAnimalRescatado.Text = $"=== ANIMAL ACTUALIZADO ===\r\n{animal}\r\n" +
                                                          $"Nueva ración de alimento: {animal.CalcularRacionAlimento():F2} g";
                    LimpiarCamposAnimal();
                }
                else
                {
                    txtBoxResultadoAnimalRescatado.Text = $"No se encontró ningún animal con ID {id} para actualizar.";
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Revisa que los campos ID y Peso contengan valores numéricos válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // BOTÓN: Borrar (Eliminar) Animal por ID
        private void btnBorrarAnimalRescatado_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtBoxIDAnimalRescatado.Text);
                var animal = _listaAnimales.FirstOrDefault(a => a.Id == id);

                if (animal != null)
                {
                    _listaAnimales.Remove(animal);
                    txtBoxResultadoAnimalRescatado.Text = $"El animal con ID {id} ({animal.Nombre}) ha sido eliminado.";
                    LimpiarCamposAnimal();
                }
                else
                {
                    txtBoxResultadoAnimalRescatado.Text = $"No se pudo eliminar. No existe animal con ID {id}.";
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingresa el ID del animal que deseas borrar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // BOTÓN: Destruir (Vaciar la lista completa de animales)
        private void btnDestruirAnimalRescatado_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show("¿Está seguro de borrar TODOS los animales registrados?", "Confirmar Eliminación Masiva", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmacion == DialogResult.Yes)
            {
                _listaAnimales.Clear();
                txtBoxResultadoAnimalRescatado.Text = "Se han eliminado todos los registros de animales.";
                LimpiarCamposAnimal();
            }
        }

        private void LimpiarCamposAnimal()
        {
            txtBoxIDAnimalRescatado.Clear();
            txtBoxNombreAnimalRescatado.Clear();
            cmbEspecieAnimalRescatado.SelectedIndex = -1;
            txtBoxPesoAnimalRescatado.Clear();
        }

        #endregion

        #region --- PESTAÑA: EXPEDIENTES MÉDICOS ---

        // BOTÓN: Crear Expediente
        private void btnCrearExpedienteMedico_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtIdExpediente.Text);
                string historial = txtHistorial.Text;
                double costo = double.Parse(txtCostoTratamiento.Text);
                bool vacunado = chkEstaVacunadoExpedienteMedico.Checked;

                if (_listaExpedientes.Any(exp => exp.Id == id))
                {
                    MessageBox.Show($"Ya existe un expediente registrado con el ID {id}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nuevoExpediente = new ExpedienteMedico(id, historial, costo, vacunado);
                _listaExpedientes.Add(nuevoExpediente);

                txtBoxResultadoExpedienteMedico.Text = $"¡Expediente Creado!\r\n{nuevoExpediente}\r\n" +
                                                      $"Costo con descuento por defecto (10%): ${nuevoExpediente.AplicarDescuento():F2}";

                LimpiarCamposExpediente();
            }
            catch (FormatException)
            {
                MessageBox.Show("Asegúrate de ingresar valores numéricos válidos en ID y Costo de Tratamiento.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // BOTÓN: Mostrar Todos los Expedientes
        private void btnMostrarExpedienteMedico_Click(object sender, EventArgs e)
        {
            if (_listaExpedientes.Count == 0)
            {
                txtBoxResultadoExpedienteMedico.Text = "No hay expedientes médicos registrados en el sistema.";
                return;
            }

            string reporte = "=== LISTA DE EXPEDIENTES MÉDICOS ===\r\n\r\n";
            foreach (var expediente in _listaExpedientes)
            {
                reporte += $"{expediente} | Costo c/desc: ${expediente.AplicarDescuento():F2}\r\n";
            }

            txtBoxResultadoExpedienteMedico.Text = reporte;
        }

        // BOTÓN: Buscar Expediente por ID
        private void btnBuscarExpedienteMedico_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtIdExpediente.Text);
                var expediente = _listaExpedientes.FirstOrDefault(exp => exp.Id == id);

                if (expediente != null)
                {
                    txtHistorial.Text = expediente.Historial;
                    txtCostoTratamiento.Text = expediente.CostoTratamiento.ToString();
                    chkEstaVacunadoExpedienteMedico.Checked = expediente.EstaVacunado;

                    txtBoxResultadoExpedienteMedico.Text = $"=== EXPEDIENTE ENCONTRADO ===\r\n{expediente}\r\n" +
                                                          $"Costo con 10% desc: ${expediente.AplicarDescuento():F2}";
                }
                else
                {
                    txtBoxResultadoExpedienteMedico.Text = $"No se encontró el expediente con ID {id}.";
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingresa un ID numérico en el campo de ID Expediente para buscar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // BOTÓN: Actualizar Expediente por ID
        private void btnActualizarExpedienteMedico_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtIdExpediente.Text);
                var expediente = _listaExpedientes.FirstOrDefault(exp => exp.Id == id);

                if (expediente != null)
                {
                    expediente.Historial = txtHistorial.Text;
                    expediente.CostoTratamiento = double.Parse(txtCostoTratamiento.Text);
                    expediente.EstaVacunado = chkEstaVacunadoExpedienteMedico.Checked;

                    txtBoxResultadoExpedienteMedico.Text = $"=== EXPEDIENTE ACTUALIZADO ===\r\n{expediente}";
                    LimpiarCamposExpediente();
                }
                else
                {
                    txtBoxResultadoExpedienteMedico.Text = $"No se encontró expediente con ID {id} para actualizar.";
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Revisa que los campos ID y Costo sean números válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // BOTÓN: Borrar Expediente por ID
        private void btnBorrarExpedienteMedico_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtIdExpediente.Text);
                var expediente = _listaExpedientes.FirstOrDefault(exp => exp.Id == id);

                if (expediente != null)
                {
                    _listaExpedientes.Remove(expediente);
                    txtBoxResultadoExpedienteMedico.Text = $"El expediente con ID {id} ha sido eliminado.";
                    LimpiarCamposExpediente();
                }
                else
                {
                    txtBoxResultadoExpedienteMedico.Text = $"No se pudo eliminar. No existe expediente con ID {id}.";
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingresa el ID del expediente que deseas borrar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // BOTÓN: Destruir (Vaciar lista de expedientes)
        private void btnDestruirExpedienteMedico_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show("¿Desea borrar TODOS los expedientes médicos?", "Confirmar Eliminación Masiva", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmacion == DialogResult.Yes)
            {
                _listaExpedientes.Clear();
                txtBoxResultadoExpedienteMedico.Text = "Se han eliminado todos los expedientes médicos.";
                LimpiarCamposExpediente();
            }
        }

        private void LimpiarCamposExpediente()
        {
            txtIdExpediente.Clear();
            txtHistorial.Clear();
            txtCostoTratamiento.Clear();
            chkEstaVacunadoExpedienteMedico.Checked = false;
        }

        #endregion

        #region --- EVENTOS VACÍOS (MANTENIDOS PARA EVITAR CONFLICTOS CON FORM1.DESIGNER.CS) ---
        private void lblAutor_Click(object sender, EventArgs e) { }
        private void gbResultadoAnimal_Enter(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }
        private void button5_Click(object sender, EventArgs e) { }
        private void button4_Click(object sender, EventArgs e) { }
        private void TabPageExpedientes_Click(object sender, EventArgs e) { }
        private void gbDatosExpedienteMedico_Enter(object sender, EventArgs e) { }
        private void lblIDExpedienteMedico_Click(object sender, EventArgs e) { }
        private void txtIdExpediente_TextChanged(object sender, EventArgs e) { }
        private void lblHistorialExpedienteMedico_Click(object sender, EventArgs e) { }
        private void txtHistorial_TextChanged(object sender, EventArgs e) { }
        private void lblCostoTratamientoExpedienteMedico_Click(object sender, EventArgs e) { }
        private void txtCostoTratamiento_TextChanged(object sender, EventArgs e) { }
        private void chkEstaVacunadoExpedienteMedico_CheckedChanged(object sender, EventArgs e) { }
        private void gbResultadoExpedienteMedico_Enter(object sender, EventArgs e) { }
        private void txtBoxResultadoExpedienteMedico_TextChanged(object sender, EventArgs e) { }
        private void gbDatosAnimalRescatado_Enter(object sender, EventArgs e) { }
        private void TabPageAnimales_Click(object sender, EventArgs e) { }
        private void lblIDAnimalRescatado_Click(object sender, EventArgs e) { }
        private void txtBoxIDAnimalRescatado_TextChanged(object sender, EventArgs e) { }
        private void lblNombreAnimalRescatado_Click(object sender, EventArgs e) { }
        private void txtBoxNombreAnimalRescatado_TextChanged(object sender, EventArgs e) { }
        private void lblEspecieAnimalRescatado_Click(object sender, EventArgs e) { }
        private void cmbEspecieAnimalRescatado_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblPesoAnimalRescatado_Click(object sender, EventArgs e) { }
        private void txtBoxPesoAnimalRescatado_TextChanged(object sender, EventArgs e) { }
        private void txtBoxResultadoAnimalRescatado_TextChanged(object sender, EventArgs e) { }
        #endregion
    }
}