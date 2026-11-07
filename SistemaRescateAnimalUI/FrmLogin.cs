using SistemaRescateAnimalUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaRescateAnimalUI
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // El usuario se arrepintió, cancelo todo y cierro la ventana
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            bool credencialesValidas = false;

            // Recorro mi lista estática en memoria para ver si el usuario y la contraseña coinciden
            foreach (var user in UsuariosSistema.ListaUsuarios)
            {
                if (user.NombreUsuario == txtUsuario.Text && user.Contrasena == txtContrasena.Text)
                {
                    // ¡Lo encontré! Guardo sus datos en la sesión global para usarlos en toda la app
                    SesionSistema.UsuarioActivo = user.NombreCompleto;
                    SesionSistema.RolActivo = user.Rol;
                    SesionSistema.HoraInicioSesion = DateTime.Now;

                    credencialesValidas = true;
                    break; // Rompo el ciclo porque ya encontré al usuario
                }
            }

            if (credencialesValidas)
            {
                // Le digo al sistema que el login fue un éxito y cierro esta ventana
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Me equivoqué de usuario o de contraseña, le aviso al usuario
                MessageBox.Show("Credenciales incorrectas. Verifica tu usuario y contraseña.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
