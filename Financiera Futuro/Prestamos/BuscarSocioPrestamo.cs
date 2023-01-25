using Financiera_Futuro.Datos_Personales;
using System;
using System.Windows.Forms;

namespace Financiera_Futuro
{
    public partial class BuscarSocioPrestamo : Form
    {
        public BuscarSocioPrestamo()
        {
            InitializeComponent();
        }

        Presta_Encap xd = new Presta_Encap();

        public string cod, nom, pat, mat, dni, tip, mon, amo, ing, tot, sal;

        private void dgvdatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            cod = dgvdatos.CurrentRow.Cells[0].Value.ToString();
            nom = dgvdatos.CurrentRow.Cells[1].Value.ToString();
            pat = dgvdatos.CurrentRow.Cells[2].Value.ToString();
            mat = dgvdatos.CurrentRow.Cells[3].Value.ToString();
            dni = dgvdatos.CurrentRow.Cells[4].Value.ToString();
            tip = dgvdatos.CurrentRow.Cells[5].Value.ToString();
            mon = dgvdatos.CurrentRow.Cells[6].Value.ToString();
            amo = dgvdatos.CurrentRow.Cells[7].Value.ToString();
            ing = dgvdatos.CurrentRow.Cells[8].Value.ToString();
            tot = dgvdatos.CurrentRow.Cells[9].Value.ToString();
            sal = dgvdatos.CurrentRow.Cells[10].Value.ToString();
            this.Close();
        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Txtcod_TextChanged(object sender, EventArgs e)
        {
            string valor = Txtcod.Text;
            dgvdatos.DataSource = xd.Buscar(valor);
        }
    }
}