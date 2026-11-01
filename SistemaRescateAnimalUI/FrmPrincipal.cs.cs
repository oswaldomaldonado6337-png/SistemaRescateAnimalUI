using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaRescateAnimalUI
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            // Dejamos esto vacío por ahora, no necesitamos que haga nada al arrancar
        }

        private void animalesRescatadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Checamos si la ventana de animales ya está abierta en nuestro escritorio principal
            foreach (Form ventana in this.MdiChildren)
            {
                if (ventana.GetType() == typeof(FrmAnimalRescatado))
                {
                    // Si ya la encontramos, la traemos al frente para que el usuario la vea
                    ventana.Activate();

                    // Si el usuario la había minimizado, la volvemos a hacer grande
                    if (ventana.WindowState == FormWindowState.Minimized)
                        ventana.WindowState = FormWindowState.Normal;

                    // Como ya la mostramos, nos salimos de aquí para no crear otra igual
                    return;
                }
            }

            // Si llegamos hasta aquí, significa que la ventana no estaba abierta. ¡La creamos!
            FrmAnimalRescatado ventanaAnimales = new FrmAnimalRescatado();
            ventanaAnimales.MdiParent = this; // Le decimos que esta ventana principal es su "papá" (el contenedor)
            ventanaAnimales.Show(); // Y por último, la mostramos en pantalla flotando
        }
    }
}