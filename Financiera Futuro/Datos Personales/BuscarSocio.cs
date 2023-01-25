using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Financiera_Futuro.Datos_Personales;

namespace Financiera_Futuro
{
    public partial class BuscarSocio : Form
    {
        public BuscarSocio()
        {
            InitializeComponent();
        }

        Date_Metod xd = new Date_Metod();
        public string cod, nom, pat, mat, dni, dir, tel, ema, tip;
        public Image ima;

        private void dgvdatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cod = dgvdatos.CurrentRow.Cells[0].Value.ToString();
            nom = dgvdatos.CurrentRow.Cells[1].Value.ToString();
            pat = dgvdatos.CurrentRow.Cells[2].Value.ToString();
            mat = dgvdatos.CurrentRow.Cells[3].Value.ToString();
            dni = dgvdatos.CurrentRow.Cells[4].Value.ToString();
            dir = dgvdatos.CurrentRow.Cells[5].Value.ToString();
            tel = dgvdatos.CurrentRow.Cells[6].Value.ToString();
            ema = dgvdatos.CurrentRow.Cells[7].Value.ToString();
            tip = dgvdatos.CurrentRow.Cells[8].Value.ToString();

            if (this.dgvdatos.CurrentRow.Cells[9].Value != DBNull.Value)
            {
                byte[] bytes = (byte[])this.dgvdatos.CurrentRow.Cells[9].Value;
                if (bytes != null)
                {
                    MemoryStream xdd = new MemoryStream(bytes);
                    ima = Image.FromStream(xdd);
                }
                else
                {
                    ima = null;
                }
            }
            this.Close();
        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Txtcod_TextChanged(object sender, EventArgs e)
        {
            string valor = Txtcod.Text;
            dgvdatos.DataSource = xd.Buscar_Socio(valor);
        }
    }
}