using System;
using System.Windows.Forms;

namespace Financiera_Futuro
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            string usu = txtusu.Text;
            string ema = txtema.Text;
            string pas = txtpas.Text;

                Control ctrl = new Control();
                string respuesta = ctrl.ctrlLogin(usu, ema, pas);
                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    WindowsLoad lod = new WindowsLoad();
                    this.Hide();
                    lod.Show();
                    this.Close();
                }
        }

        private void btnFaceBook_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/dangosw");
        }

        private void btnInsta_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/dan_gosw/");
        }
    }
}