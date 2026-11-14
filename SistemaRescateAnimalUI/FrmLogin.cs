using SistemaRescateAnimalUI.Models;
using SistemaRescateAnimalUI.Datos;
using SistemaRescateAnimalUI.Utilidades;
using System;
using System.Windows.Forms;

namespace SistemaRescateAnimalUI
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            // Ahora este campo debe recibir un correo electrónico
            string correo = txtUsuario.Text.Trim();
            string passwordPlano = txtContrasena.Text;

            if (string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(passwordPlano))
            {
                MessageBox.Show("Por favor, ingresa tu correo y contraseña.", "Datos faltantes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashPassword = Seguridad.GenerarSHA256(passwordPlano);
            UsuarioDAO dao = new UsuarioDAO();

            try
            {
                string nombreCompletoExtraido, rolExtraido;

                bool credencialesValidas = dao.ValidarCredenciales(correo, hashPassword, out nombreCompletoExtraido, out rolExtraido);

                if (credencialesValidas)
                {
                    SesionSistema.UsuarioActivo = nombreCompletoExtraido;
                    SesionSistema.RolActivo = rolExtraido;
                    SesionSistema.HoraInicioSesion = DateTime.Now;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Correo o contraseña incorrectos. Verifica tus datos.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}