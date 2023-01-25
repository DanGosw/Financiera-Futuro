using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
namespace Financiera_Futuro
{
    public partial class Cronograma : Form
    {
        public Cronograma()
        {
            InitializeComponent();
            dgvdatos.DataSource = Object.ListarDocumento();
        }

        Crono_control control = new Crono_control();
        Crono_Encap Object = new Crono_Encap();

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(MessageBox.Show("¿Deseas Agregar el Registro seleccionado?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (x == 6)
            {
                try
                {
                    Crono_Encap anual = new Crono_Encap();

                    byte[] archivo = null;
                    Stream mystr = file.OpenFile();
                    MemoryStream obj = new MemoryStream();
                    mystr.CopyTo(obj);
                    archivo = obj.ToArray();

                    anual.Soci = txtsoc.Text;
                    anual.NomS = txtnos.Text;
                    anual.Fech = dtpfec.Text;
                    anual.Mont = txtcan.Text;
                    anual.Cuot = txtnro.Text;
                    anual.Amor = txtamo.Text;
                    anual.Inte = txtint.Text;
                    anual.Tota = txttot.Text;
                    anual.Obse = txtobs.Text;
                    anual.Mult = txtmul.Text;
                    anual.Docs = archivo;
                    anual.Exts = file.SafeFileName ;
                    anual.Nodo = txtnom.Text;

                    string respuesta = control.AgregaCronoGrama(anual);
                    if (respuesta.Length > 0)
                    {
                        MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Limpiar();
                        dgvdatos.DataSource = Object.ListarDocumento();                    
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
            file.InitialDirectory = "C:\\Documentos";
            file.Filter = "Todos los archivos(*.*)|*.*";
            file.FilterIndex = 1;
            if (file.ShowDialog() == DialogResult.OK)
                txtrut.Text = file.FileName;
        }

        private void gunaButton7_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvdatos.SelectedRows.Count > 0)
                {
                    string cod = dgvdatos.CurrentRow.Cells[0].Value.ToString();
                    Object.Codi = cod;

                    var lista = new List<Crono_Encap>();
                    lista = Object.Filtrado();

                    foreach (Crono_Encap item in lista)
                    {
                        string dir = AppDomain.CurrentDomain.BaseDirectory;
                        string car = dir + "/temp/";
                        string ubi = car + item.Exts;

                        if (!Directory.Exists(car))
                            Directory.CreateDirectory(car);

                        if (File.Exists(ubi))
                            File.Delete(ubi);

                        File.WriteAllBytes(ubi, item.Docs);
                        Process.Start(ubi);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Parece que no hubo un archivo agregado, " + ex.Message, "Error D:");
            }
        }

        private void btncalcular_Click(object sender, EventArgs e)
        {
            double mon, dia, tot,xd;
            mon = Double.Parse(txtmon.Text);
            dia = Double.Parse(txtdia.Text);

            tot = 1.5 / mon;
            xd = tot * dia;
            txtres.Text = Convert.ToString(xd);
            txtmul.Text = Convert.ToString(xd);
        }

        private void cboact_CheckedChanged(object sender, EventArgs e)
        {
            if (cboact.Checked)
            {
               MessageBox.Show("Por favor use esto solo si hubo un retraso en el imcumplimiento de pago", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtmon.Enabled = true;
                txtdia.Enabled = true;
                txtres.Enabled = true;
                btncalcular.Enabled = true;
                Calculadora.Enabled = true;
                txtmul.ReadOnly = false;
            }
            else
            {
                txtmon.Enabled = false;
                txtdia.Enabled = false;
                txtres.Enabled = false;
                btncalcular.Enabled = false;
                Calculadora.Enabled = false;
                txtmul.ReadOnly = true;
            }
        }

        private void txtmon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            Process calc = new Process { StartInfo = { FileName = @"calc.exe" } };
            calc.Start();
        }

        private void Cronograma_Load(object sender, EventArgs e)
        {
            dtpfec.Value = DateTime.Now.Date;
            dtpfec.MaxDate = DateTime.Now.Date;
        }

        private void Limpiar()
        {
            txtcod.Text = null;
            txtsoc.Text = null;
            txtnos.Text = null;
            dtpfec.Value = DateTime.Now.Date;
            txtnro.Text = null;
            txtamo.Text = null;
            txtcan.Text = null;
            txtint.Text = null;
            txttot.Text = null;
            txtobs.Text = null;
            txtmul.Text = "0.00";
            txtrut.Text = null;
            txtnom.Text = null;
            txtmon.Text = null;
            txtdia.Text = null;
            txtres.Text = null;
        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(MessageBox.Show("¿Deseas Modificar el Registro seleccionado?\n los Documentos agregados no pueden ser modificados :)", "Modificar", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (x == 6)
            {
                try
                {
                    Crono_Encap anual = new Crono_Encap();

                    anual.Codi = txtcod.Text;
                    anual.Soci = txtsoc.Text;
                    anual.NomS = txtnos.Text;
                    anual.Fech = dtpfec.Text;
                    anual.Mont = txtcan.Text;
                    anual.Cuot = txtnro.Text;
                    anual.Amor = txtamo.Text;
                    anual.Inte = txtint.Text;

                    double n1, n2, tot;
                    n1 = Convert.ToDouble(txtcan.Text);
                    n2 = Convert.ToDouble(txtamo.Text);
                    tot = n1 - n2;
                    anual.Sald = Convert.ToString(tot);
                    anual.Tota = txttot.Text;
                    anual.Obse = txtobs.Text;
                    anual.Mult = txtmul.Text;

                    string respuesta = control.ModificaCronoGrama(anual);
                    if (respuesta.Length > 0)
                    {
                        MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Limpiar();
                        dgvdatos.DataSource = Object.ListarDocumento();
                    
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void gunaButton8_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(MessageBox.Show("¿Deseas Eliminar el Registro seleccionado?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (x == 6)
            {
                try
                {
                    Crono_Encap anual = new Crono_Encap();

                    anual.Codi = txtcod.Text;

                    string respuesta = control.EliminaCronoGrama(anual);
                    if (respuesta.Length > 0)
                    {
                        MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Limpiar();
                        dgvdatos.DataSource = Object.ListarDocumento();                        
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtmul_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',' && e.KeyChar == '.'))
            {
                e.Handled = true;
            }
        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvdatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcod.Text = dgvdatos.CurrentRow.Cells[0].Value.ToString();
            txtsoc.Text = dgvdatos.CurrentRow.Cells[1].Value.ToString();
            txtnos.Text = dgvdatos.CurrentRow.Cells[2].Value.ToString();
            dtpfec.Value = Convert.ToDateTime(dgvdatos.CurrentRow.Cells[3].Value.ToString());
            txtcan.Text = dgvdatos.CurrentRow.Cells[4].Value.ToString();
            txtnro.Text = dgvdatos.CurrentRow.Cells[5].Value.ToString();
            txtamo.Text = dgvdatos.CurrentRow.Cells[6].Value.ToString();
            txtint.Text = dgvdatos.CurrentRow.Cells[7].Value.ToString();
            txtsal.Text = dgvdatos.CurrentRow.Cells[8].Value.ToString();
            txttot.Text = dgvdatos.CurrentRow.Cells[9].Value.ToString();
            txtobs.Text = dgvdatos.CurrentRow.Cells[10].Value.ToString();
            txtmul.Text = dgvdatos.CurrentRow.Cells[11].Value.ToString();
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            BuscarSocioPrestamo bus = new BuscarSocioPrestamo();
            bus.ShowDialog();
            txtsoc.Text = bus.cod;
            txtnos.Text = bus.pat + " " + bus.mat +", "+ bus.nom;
            txtcan.Text = bus.mon;
            txtamo.Text = bus.amo;
            txtint.Text = bus.ing;
            txttot.Text = bus.tot;

            double capital = Convert.ToDouble(bus.mon);
            double cuotas = Convert.ToDouble(bus.amo);
            double interes = Convert.ToDouble(bus.ing);
            
            capital = Math.Round(capital -cuotas + interes,2);

            txtsal.Text = Convert.ToString(capital);
        }

        private void txtcan_TextChanged(object sender, EventArgs e)
        {

        }
    }
}