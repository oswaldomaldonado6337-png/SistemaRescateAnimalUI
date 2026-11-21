
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SistemaRescateAnimal.Models; 

namespace SistemaRescateAnimalUI
{
    public partial class FrmDetalleEliminacion : Form
    {
        public enum TipoBorrado
        {
            Ninguno,
            Logico,
            Fisico
        }

        public TipoBorrado OpcionSeleccionada { get; private set; } = TipoBorrado.Ninguno;

        public FrmDetalleEliminacion(AnimalRescatado animal)
        {
            InitializeComponent();
            CargarDatosSoloLectura(animal);
        }

        private void CargarDatosSoloLectura(AnimalRescatado animal)
        {
            if (animal == null) return;

            txtId.Text = animal.Id;
            txtNombre.Text = animal.Nombre;
            txtEspecie.Text = animal.Especie;
            txtPeso.Text = animal.Peso.ToString("0.00");
            txtFecha.Text = animal.FechaRegistro.ToShortDateString();
            chkActivo.Checked = animal.EsActivo;

            CargarImagenSinBloqueo(animal.RutaImagen);
        }

        private void CargarImagenSinBloqueo(string rutaRelativa)
        {
            if (string.IsNullOrWhiteSpace(rutaRelativa)) return;

            string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, rutaRelativa);

            if (File.Exists(rutaCompleta))
            {
                try
                {
                    using (FileStream fs = new FileStream(rutaCompleta, FileMode.Open, FileAccess.Read))
                    using (MemoryStream ms = new MemoryStream())
                    {
                        fs.CopyTo(ms);
                        ms.Position = 0;
                        using (Image imgTemp = Image.FromStream(ms))
                        {
                            pbxFoto.Image = new Bitmap(imgTemp);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo cargar la vista previa de la fotografía: {ex.Message}",
                                    "Aviso de Imagen", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnLogico_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion(
                TipoBorrado.Logico,
                "¿Está seguro de realizar un BORRADO LÓGICO?\n\nEl registro se marcará como inactivo (EsActivo = 0) y se ocultará de las consultas activas, pero permanecerá en la base de datos."
            );
        }

        private void btnFisico_Click(object sender, EventArgs e)
        {
            ConfirmarEliminacion(
                TipoBorrado.Fisico,
                "ADVERTENCIA: ¿Está seguro de realizar un BORRADO FÍSICO?\n\nEsta acción es irreversible: el registro se eliminará permanentemente de MariaDB y MongoDB, y su fotografía será borrada del disco."
            );
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LiberarImagen();
            OpcionSeleccionada = TipoBorrado.Ninguno;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ConfirmarEliminacion(TipoBorrado tipo, string mensajeAdvertencia)
        {
            DialogResult respuesta = MessageBox.Show(
                mensajeAdvertencia,
                "Confirmación de Seguridad",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (respuesta == DialogResult.Yes)
            {
                LiberarImagen();
                OpcionSeleccionada = tipo;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void LiberarImagen()
        {
            if (pbxFoto.Image != null)
            {
                pbxFoto.Image.Dispose();
                pbxFoto.Image = null;
            }
        }
    }
}