using Financiera_Futuro.Datos_Personales;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Financiera_Futuro
{
    public partial class Add_Socios : Form
    {
        public Add_Socios()
        {
            InitializeComponent();
        }
        Date_Control control = new Date_Control();
        Date_Metod ver = new Date_Metod();

        string tip = "";

        private void Limpiar()
        {
            if (ImgRef.Image != null)
            {
                ImgRef.Image = Financiera_Futuro.Properties.Resources.LogUser;
            }
            Txtcod.Text = "";
            Txtnom.Text = "";
            Txtpat.Text = "";
            Txtmat.Text = "";
            Txtdni.Text = "";
            Txtdir.Text = "";
            Txtcel.Text = "";
            Txtema.Text = "";
            dgvdatos.DataSource = ver.Mostrar();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(MessageBox.Show("¿Deseas Agregar el Registro seleccionado?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (x == 6)
            {
                try
                {
                    Date_Encap anual = new Date_Encap();

                    MemoryStream ms = new MemoryStream();
                    ImgRef.Image.Save(ms, ImageFormat.Jpeg);
                    byte[] bit = ms.ToArray();

                    anual.Nom = Txtnom.Text;
                    anual.Pat = Txtpat.Text;
                    anual.Mat = Txtmat.Text;
                    anual.Dni = Txtdni.Text;
                    anual.Dir = Txtdir.Text;
                    anual.Tel = Txtcel.Text;
                    anual.Ema = Txtema.Text;
                    string respuesta = control.Agrega(anual, tip, bit);
                    if (respuesta.Length > 0)
                    {
                        MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Limpiar();
                        dgvdatos.DataSource = ver.Mostrar();                    
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(MessageBox.Show("¿Deseas modificar el Registro seleccionado?", "Modificar", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (x == 6)
            {
                try
                {
                    Date_Encap anual = new Date_Encap();

                    MemoryStream ms = new MemoryStream();
                    ImgRef.Image.Save(ms, ImageFormat.Jpeg);
                    byte[] bit = ms.ToArray();

                    anual.Cod = Txtcod.Text;
                    anual.Nom = Txtnom.Text;
                    anual.Pat = Txtpat.Text;
                    anual.Mat = Txtmat.Text;
                    anual.Dni = Txtdni.Text;
                    anual.Dir = Txtdir.Text;
                    anual.Tel = Txtcel.Text;
                    anual.Ema = Txtema.Text;
                    string respuesta = control.Modifica(anual, tip, bit);
                    if (respuesta.Length > 0)
                    {
                        MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Limpiar();
                        dgvdatos.DataSource = ver.Mostrar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(MessageBox.Show("¿Deseas Eliminar el Registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (x == 6)
            {
                Date_Encap anual = new Date_Encap();
                anual.Cod = Txtcod.Text;
                string respuesta = control.Elimina(anual);
                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                        Limpiar();
                        dgvdatos.DataSource = ver.Mostrar();
                }
            }
        }

        private void Add_Socios_Load(object sender, EventArgs e)
        {
            rbtsoc.Checked = true;
            dgvdatos.DataSource = ver.Mostrar();
        }

        private void dgvdatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Txtcod.Text = dgvdatos.CurrentRow.Cells[0].Value.ToString();
            Txtnom.Text = dgvdatos.CurrentRow.Cells[1].Value.ToString();
            Txtpat.Text = dgvdatos.CurrentRow.Cells[2].Value.ToString();
            Txtmat.Text = dgvdatos.CurrentRow.Cells[3].Value.ToString();
            Txtdni.Text = dgvdatos.CurrentRow.Cells[4].Value.ToString();
            Txtdir.Text = dgvdatos.CurrentRow.Cells[5].Value.ToString();
            Txtcel.Text = dgvdatos.CurrentRow.Cells[6].Value.ToString();
            Txtema.Text = dgvdatos.CurrentRow.Cells[7].Value.ToString();
            byte[] img = (byte[])dgvdatos.CurrentRow.Cells[9].Value;
            MemoryStream ms = new MemoryStream(img);

            ImgRef.Image = Image.FromStream(ms);
        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbtsoc_CheckedChanged(object sender, EventArgs e)
        {
            tip = "Socio";
        }

        private void rbtnat_CheckedChanged(object sender, EventArgs e)
        {
            tip = "Persona Natural";
        }

        private void ImgRef_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdSeleccionar = new OpenFileDialog();
            ofdSeleccionar.Filter = "Imagenes|*.jpg; *.png";
            ofdSeleccionar.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofdSeleccionar.Title = "Seleccionar imagen referencial al socio";

            if (ofdSeleccionar.ShowDialog() == DialogResult.OK)
            {
                ImgRef.Image = Image.FromFile(ofdSeleccionar.FileName);
            }
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            BuscarSocio bus = new BuscarSocio();
            bus.ShowDialog();
            Txtcod.Text = bus.cod;
            Txtnom.Text = bus.nom;
            Txtpat.Text = bus.pat;
            Txtmat.Text = bus.mat;
            Txtdni.Text = bus.dni;
            Txtdir.Text = bus.dir;
            Txtcel.Text = bus.tel;
            Txtema.Text = bus.ema;
            ImgRef.Image = bus.ima;

            if (bus.ima == null)
            {
                ImgRef.Image = Financiera_Futuro.Properties.Resources.LogUser;
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dgvdatos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
    }
}