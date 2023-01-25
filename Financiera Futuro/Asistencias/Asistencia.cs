using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace Financiera_Futuro
{
    public partial class Asistencia : Form
    {
        public Asistencia()
        {
            InitializeComponent();
        }

        public string estado = "";
        Asis_Encap Object = new Asis_Encap();
        Asis_Control control = new Asis_Control();

        private void rjbAsistio_CheckedChanged(object sender, EventArgs e)
        {
            estado = "Asistio";
            if (rjbAsistio.Checked == true)
            {
                lblMult.Text = "S/0.00";
            }
        }

        private void rjbTardanza_CheckedChanged(object sender, EventArgs e)
        {
            estado = "Tardanza";
            if (rjbTardanza.Checked == true)
            {
                lblMult.Text = "S/5.00";
            }
        }

        private void rjbInasistencia_CheckedChanged(object sender, EventArgs e)
        {
            estado = "Inasistencia";
            if (rjbInasistencia.Checked == true)
            {
                lblMult.Text = "S/15.00";
            }
        }

        private void Asistencia_Load(object sender, EventArgs e)
        {
            rjbAsistio.Checked = true;
        }

        private void dgvdatos_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvdatos.Rows[e.RowIndex].Cells[6].Value.ToString() == "Asistio")
            {
                if (e.Value != null)
                {
                    if (e.Value.GetType() != typeof(System.DBNull))
                    {
                        foreach (DataGridViewCell celda in this.dgvdatos.Rows[e.RowIndex].Cells)
                        {
                            celda.Style.BackColor = Color.FromArgb(141, 197, 37);
                            celda.Style.ForeColor = Color.Black;
                        }
                    }
                }
            }

            if (this.dgvdatos.Rows[e.RowIndex].Cells[6].Value.ToString() == "Tardanza")
            {
                if (e.Value != null)
                {
                    if (e.Value.GetType() != typeof(System.DBNull))
                    {
                        foreach (DataGridViewCell celda in this.dgvdatos.Rows[e.RowIndex].Cells)
                        {
                            celda.Style.BackColor = Color.FromArgb(216, 189, 63);
                            celda.Style.ForeColor = Color.Black;
                        }
                    }
                }
            }

            if (this.dgvdatos.Rows[e.RowIndex].Cells[6].Value.ToString() == "Inasistencia")
            {
                if (e.Value != null)
                {
                    if (e.Value.GetType() != typeof(System.DBNull))
                    {
                        foreach (DataGridViewCell celda in this.dgvdatos.Rows[e.RowIndex].Cells)
                        {
                            celda.Style.BackColor = Color.FromArgb(179, 34, 67);
                            celda.Style.ForeColor = Color.Black;
                        }
                    }
                }
            }
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(MessageBox.Show("¿Deseas Agregar el Registro?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (x == 6)
            {
                try
                {                
                    Asis_Encap ass = new Asis_Encap();
                    MemoryStream ms = new MemoryStream();
                    ImgRef.Image.Save(ms, ImageFormat.Jpeg);
                    byte[] bit = ms.ToArray();
                    ass.Dni = txtdni.Text;
                    ass.Nom = txtnom.Text;
                    ass.Pat = txtpat.Text;
                    ass.Mat = txtmat.Text;
                    ass.Fec = dtpfec.Text;
                    ass.Asi = estado;
                    ass.Mul = lblMult.Text;
                    ass.Nom = txtnom.Text;
                    ass.Ima = bit;

                    string respuesta = control.AgregaAsistencia(ass);
                    if (respuesta.Length > 0)
                    {
                        MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                            Limpiar();
                            dgvdatos.DataSource = Object.mostrar();                    
                    }
                }            
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void rjButton3_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(MessageBox.Show("¿Deseas Cambiar el Registro seleccionado?", "Cambiar", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (x == 6)
            {

                try
                {
                    Asis_Encap ass = new Asis_Encap();
                    MemoryStream ms = new MemoryStream();
                    ImgRef.Image.Save(ms, ImageFormat.Jpeg);
                    byte[] bit = ms.ToArray();
                    ass.Dni = txtdni.Text;
                    ass.Nom = txtnom.Text;
                    ass.Pat = txtpat.Text;
                    ass.Mat = txtmat.Text;
                    ass.Fec = dtpfec.Text;
                    ass.Asi = estado;
                    ass.Mul = lblMult.Text;
                    ass.Nom = txtnom.Text;
                    ass.Ima = bit;

                    string respuesta = control.ModificaAsistencia(ass);
                    if (respuesta.Length > 0)
                    {
                        MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                            Limpiar();
                            dgvdatos.DataSource = Object.mostrar();
                    
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(MessageBox.Show("¿Deseas Eliminar el Registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (x == 6)
            {
                try
                {
                    Asis_Encap ass = new Asis_Encap();

                    ass.Cod = txtcod.Text;

                    string respuesta = control.EliminaAsistencia(ass);
                    if (respuesta.Length > 0)
                    {
                        MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                            Limpiar();
                            dgvdatos.DataSource = Object.mostrar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            BuscarSocio bus = new BuscarSocio();
            bus.ShowDialog();
            txtdni.Text = bus.dni;
            txtnom.Text = bus.nom;
            txtpat.Text = bus.pat;
            txtmat.Text = bus.mat;
            ImgRef.Image = bus.ima;

            if (bus.ima == null)
            {
                ImgRef.Image = Financiera_Futuro.Properties.Resources.LogUser;
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dtpbus_TextChanged(object sender, EventArgs e)
        {
            string valor = Convert.ToString(dtpbus.Value);
            dgvdatos.DataSource = Object.Buscar_Aporte(valor);
        }

        private void Limpiar()
        {
            txtcod.Text = null;
            txtdni.Text = null;
            txtnom.Text = null;
            txtpat.Text = null;
            txtmat.Text = null;
            lblMult.Text = "S/0.00";
            rjbAsistio.Checked = true;
            rjbTardanza.Checked = false;
            rjbInasistencia.Checked = false;
            dtpbus.Value =DateTime.Now;
            dgvdatos.DataSource = Object.mostrar();
        }

        private void dgvdatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcod.Text = dgvdatos.CurrentRow.Cells[0].Value.ToString();
            txtdni.Text = dgvdatos.CurrentRow.Cells[1].Value.ToString();
            txtnom.Text = dgvdatos.CurrentRow.Cells[2].Value.ToString();
            txtpat.Text = dgvdatos.CurrentRow.Cells[3].Value.ToString();
            txtmat.Text = dgvdatos.CurrentRow.Cells[4].Value.ToString();
            dtpfec.Value = Convert.ToDateTime(dgvdatos.CurrentRow.Cells[5].Value.ToString());
            lblMult.Text = dgvdatos.CurrentRow.Cells[7].Value.ToString();
            byte[] img = (byte[])dgvdatos.CurrentRow.Cells[8].Value;
            MemoryStream ms = new MemoryStream(img);
            ImgRef.Image = Image.FromStream(ms);
        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}