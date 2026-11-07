using System;
using System.Windows.Forms;

namespace SistemaRescateAnimalUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            FrmLogin login = new FrmLogin();
            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FrmPrincipalMDI());
            }
        }
    }
}