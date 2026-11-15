using System.Windows.Forms;

namespace SistemaRescateAnimalUI
{
    public partial class FrmBase : Form
    {
        protected TextBox txtId = new TextBox();

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // FrmBase
            // 
            ClientSize = new Size(785, 436);
            Name = "FrmBase";
            ResumeLayout(false);

        }

        public FrmBase()
        {
        }
    }
}