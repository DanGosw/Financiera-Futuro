using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Financiera_Futuro
{
    public partial class AddUser : Form
    {
        private readonly Timer ti;

        public AddUser()
        {
            ti = new Timer();
            ti.Tick += new EventHandler(Exd);
            InitializeComponent();
            ti.Enabled = true;
        }

        private void Exd(object ob, EventArgs evt)
        {
            DateTime xd = DateTime.Now;
            lblhor.Text = xd.ToString("h:mm:ss tt");
            lblfec.Text = xd.ToLongDateString();
        }

        Usuarios xd = new Usuarios();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string valor = txtcod.Text;
            dgvdatos.DataSource = xd.Buscar_Aporte(valor);
        }
        private void llenar()
        {
            xd.Cod = txtcod.Text;
        }

        private void LimpiarTexto()
        {
            if (picSoc.Image != null)
            {
                picSoc.Image = Financiera_Futuro.Properties.Resources.LogUser;
            }
            txtcod.Text = "";
            txtusu.Text = "";
            txtpass.Text = "";
            txtema.Text = "";
            cbotip.SelectedIndex = 0;
        }

        private void dgvdatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcod.Text = dgvdatos.CurrentRow.Cells[0].Value.ToString();
            txtusu.Text = dgvdatos.CurrentRow.Cells[1].Value.ToString();
            txtpass.Text = null;
            byte[] img = (byte[])dgvdatos.CurrentRow.Cells[3].Value;
            MemoryStream ms = new MemoryStream(img);

            picSoc.Image = Image.FromStream(ms);
            txtema.Text = dgvdatos.CurrentRow.Cells[4].Value.ToString();
            cbotip.Text = dgvdatos.CurrentRow.Cells[5].Value.ToString();
            lblfec.Text = dgvdatos.CurrentRow.Cells[6].Value.ToString();
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            string tex = txtbuscar.Text;
            dgvdatos.DataSource = xd.Buscar_Aporte(tex);
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            dgvdatos.DataSource = xd.mostrar();
        }

        private void BtnSelec_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes|*.jpg; *.png";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar imagen";

            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                picSoc.Image = Image.FromFile(ofdSeleccionar.FileName);
            }
        }

        private void BtnReg_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(MessageBox.Show("¿Deseas Agregar el Registro seleccionado?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (x == 6)
            {
                //try
                //    {
                        MemoryStream ms = new MemoryStream();
                        picSoc.Image.Save(ms, ImageFormat.Jpeg);
                        byte[] aByte = ms.ToArray();

                        Usuarios usuario = new Usuarios();
                        usuario.Cod = txtcod.Text;
                        usuario.Nom = txtusu.Text;
                        usuario.Ema = txtema.Text;
                        usuario.Pas = txtpass.Text;
                        usuario.Tip = cbotip.Text;
                        usuario.Fec = lblfec.Text + ", " + lblhor.Text;

                        Control control = new Control();
                        string respuesta = control.ctrlRegistro(usuario, aByte);
                        if (respuesta.Length > 0)
                        {
                            MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            dgvdatos.DataSource = xd.mostrar();
                            LimpiarTexto();
                        }
            //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }
        }

        private void BtnElim_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtcod.Text))
            {
                MessageBox.Show("Seleccione en el registro una fila para eliminar", "Error D:");
            }
            else
            {
                int x = Convert.ToInt32(MessageBox.Show("¿Deseas eliminar el Registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
                if (x == 6)
                {
                    llenar();
                    xd.eliminar();
                    dgvdatos.DataSource = xd.mostrar();
                    LimpiarTexto();
                }
            }
        }

        private void Btnmod_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(MessageBox.Show("¿Deseas Modificar el Registro seleccionado?", "Modificar", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (x == 6)
            {
            try
                    {
                MemoryStream ms = new MemoryStream();
                picSoc.Image.Save(ms, ImageFormat.Jpeg);
                byte[] img = ms.ToArray();

                Usuarios usuario = new Usuarios();
                usuario.Cod = txtcod.Text;
                usuario.Nom = txtusu.Text;
                usuario.Ema = txtema.Text;
                usuario.Pas = txtpass.Text;
                usuario.Tip = cbotip.Text;                

                Control control = new Control();
                string respuesta = control.modificarusuarios(usuario, img);
                dgvdatos.DataSource = xd.mostrar();
                LimpiarTexto();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}