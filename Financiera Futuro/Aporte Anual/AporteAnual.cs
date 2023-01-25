using System;
using System.Windows.Forms;

namespace Financiera_Futuro
{
    public partial class AporteAnual : Form
    {
        public AporteAnual()
        {
            InitializeComponent();
        }

        ControlAnual control = new ControlAnual();
        Mod_Metodos met = new Mod_Metodos();
        string campo, filtro;

        private void Limpiar()
        {
            txtcod.Text = "";
            TxtSoc.Text = "";
            txtnos.Text = "";
            dtpaño.Value = DateTime.Now.Date;
            txtcuo.Text = "00.00";
            txtene.Text = "00.00";
            txtfeb.Text = "00.00";
            txtmar.Text = "00.00";
            txtabr.Text = "00.00";
            txtmay.Text = "00.00";
            txtjun.Text = "00.00";
            txtjul.Text = "00.00";
            txtago.Text = "00.00";
            txtsep.Text = "00.00";
            txtoct.Text = "00.00";
            txtnov.Text = "00.00";
            txtdic.Text = "00.00";
            lbltot.Text = "00.00";
            rbtact.Checked = true;
            rbtret.Checked = false;
        }

        private void BtnAgregar_Click(object sender, System.EventArgs e)
        {
            int x = Convert.ToInt32(MessageBox.Show("¿Deseas Agregar el Registro seleccionado?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (x == 6)
            {
                try
                {
                    AnualEncap anual = new AnualEncap();
                    string socio = TxtSoc.Text;
                    anual.AñoA = dtpaño.Text;
                    anual.Cuota = txtcuo.Text;
                    anual.EnerA = txtene.Text;
                    anual.FebrA = txtfeb.Text;
                    anual.MarzA = txtmar.Text;
                    anual.AbriA = txtabr.Text;
                    anual.MayoA = txtmay.Text;
                    anual.JuniA = txtjun.Text;
                    anual.JuliA = txtjul.Text;
                    anual.AgosA = txtago.Text;
                    anual.SetpA = txtsep.Text;
                    anual.OctuA = txtoct.Text;
                    anual.NoviA = txtnov.Text;
                    anual.DiciA = txtdic.Text;
                    anual.TotaA = lbltot.Text;
                    string respuesta = control.AgregaAporte(anual, socio, campo);
                    if (respuesta.Length > 0)
                    {
                        MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                    Limpiar();
                    dgvdatos.DataSource = met.mostrar();                   
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }        

        private void rbtact_CheckedChanged(object sender, EventArgs e)
        {
            campo = "Activo";
        }

        private void rbtret_CheckedChanged(object sender, EventArgs e)
        {
            campo = "Retirado";
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            dgvdatos.DataSource = met.mostrar();
        }

        private void AporteAnual_Load(object sender, EventArgs e)
        {
            rbtact.Checked = true;
            dgvdatos.DataSource = met.mostrar();
            dtpaño.Value = DateTime.Now.Date;
            dtpaño.MaxDate = DateTime.Now.Date;
            dtpFil.Value = DateTime.Now.Date;
            rbtactFil.Checked = true;
        }

        private void dgvdatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcod.Text = dgvdatos.CurrentRow.Cells[0].Value.ToString();
            TxtSoc.Text = dgvdatos.CurrentRow.Cells[1].Value.ToString();
            dtpaño.Value = Convert.ToDateTime(dgvdatos.CurrentRow.Cells[2].Value.ToString());
            txtcuo.Text = dgvdatos.CurrentRow.Cells[3].Value.ToString();
            txtene.Text = dgvdatos.CurrentRow.Cells[5].Value.ToString();
            txtfeb.Text = dgvdatos.CurrentRow.Cells[6].Value.ToString();
            txtmar.Text = dgvdatos.CurrentRow.Cells[7].Value.ToString();
            txtabr.Text = dgvdatos.CurrentRow.Cells[8].Value.ToString();
            txtmay.Text = dgvdatos.CurrentRow.Cells[9].Value.ToString();
            txtjun.Text = dgvdatos.CurrentRow.Cells[10].Value.ToString();
            txtjul.Text = dgvdatos.CurrentRow.Cells[11].Value.ToString();
            txtago.Text = dgvdatos.CurrentRow.Cells[12].Value.ToString();
            txtsep.Text = dgvdatos.CurrentRow.Cells[13].Value.ToString();
            txtoct.Text = dgvdatos.CurrentRow.Cells[14].Value.ToString();
            txtnov.Text = dgvdatos.CurrentRow.Cells[15].Value.ToString();
            txtdic.Text = dgvdatos.CurrentRow.Cells[16].Value.ToString();
            lbltot.Text = dgvdatos.CurrentRow.Cells[17].Value.ToString();
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(MessageBox.Show("¿Deseas Modificar el Registro seleccionado?", "Modificar", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (x == 6)
            {
            try
            {
                string socio = TxtSoc.Text;
                AnualEncap anual = new AnualEncap();
                anual.Codig = txtcod.Text;
                anual.AñoA = dtpaño.Text;
                anual.Cuota = txtcuo.Text;
                anual.EnerA = txtene.Text;
                anual.FebrA = txtfeb.Text;
                anual.MarzA = txtmar.Text;
                anual.AbriA = txtabr.Text;
                anual.MayoA = txtmay.Text;
                anual.JuniA = txtjun.Text;
                anual.JuliA = txtjul.Text;
                anual.AgosA = txtago.Text;
                anual.SetpA = txtsep.Text;
                anual.OctuA = txtoct.Text;
                anual.NoviA = txtnov.Text;
                anual.DiciA = txtdic.Text;
                anual.TotaA = lbltot.Text;
                string respuesta = control.ModificaAporte(anual, socio, campo);
                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {   
                        Limpiar();                    
                        dgvdatos.DataSource = met.mostrar();                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
            }            
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(MessageBox.Show("¿Deseas Eliminar el Registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (x == 6)
            {
                try
                {                
                AnualEncap anual = new AnualEncap();
                anual.Codig = txtcod.Text;
                string respuesta = control.EliminaAporte(anual);
                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                        Limpiar();
                        dgvdatos.DataSource = met.mostrar();
                }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtcuo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double ext, ene, feb, mar, abr, may, jun, jul, ago, sep, oct, nov, dic, total;

                ext = Convert.ToDouble(txtcuo.Text);
                ene = Convert.ToDouble(txtene.Text);
                feb = Convert.ToDouble(txtfeb.Text);
                mar = Convert.ToDouble(txtmar.Text);
                abr = Convert.ToDouble(txtabr.Text);
                may = Convert.ToDouble(txtmay.Text);
                jun = Convert.ToDouble(txtjun.Text);
                jul = Convert.ToDouble(txtjul.Text);
                ago = Convert.ToDouble(txtago.Text);
                sep = Convert.ToDouble(txtsep.Text);
                oct = Convert.ToDouble(txtoct.Text);
                nov = Convert.ToDouble(txtnov.Text);
                dic = Convert.ToDouble(txtdic.Text);

                total = (ext + ene + feb + mar + abr + may + jun + jul + ago + sep + oct + nov + dic);
                lbltot.Text = total.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Solo se permiten numeros", "Oh no algo salio mal D:", MessageBoxButtons.OK, MessageBoxIcon.Error);            
            }
        }

        private void rbtactFil_CheckedChanged(object sender, EventArgs e)
        {
            filtro = "Activo";
        }

        private void rbtretFil_CheckedChanged(object sender, EventArgs e)
        {
            filtro = "Retirado";
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            string date = dtpFil.Text;
            dgvdatos.DataSource = met.Filtros(date, filtro);
        }

        private void gunaButton1_Click_1(object sender, EventArgs e)
        {
            BuscarSocio bus = new BuscarSocio();
            bus.ShowDialog();
            TxtSoc.Text = bus.cod;
            txtnos.Text = bus.pat + " " + bus.mat + ", "+ bus.nom;
        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {
            string busqueda = gunaTextBox1.Text;
            dgvdatos.DataSource = met.Buscar_Aporte(busqueda);
        }

        private void txtcuo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChkFiltros_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkFiltros.Checked)
            {
                dtpFil.Enabled = true;
                rbtactFil.Enabled = true;
                rbtactFil.Checked = true;
                rbtretFil.Enabled = true;
                Btnfiltros.Enabled = true;
            }
            else
            {
                dtpFil.Enabled = false;
                rbtactFil.Enabled = false;
                rbtactFil.Checked = false;
                rbtretFil.Enabled = false;
                dgvdatos.DataSource = met.mostrar();
                Btnfiltros.Enabled = false;
            }
        }
    }
}