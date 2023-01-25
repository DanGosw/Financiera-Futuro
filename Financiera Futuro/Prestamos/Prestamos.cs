using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Financiera_Futuro
{
    public partial class Prestamos : Form
    {
        public Prestamos()
        {
            InitializeComponent();
        }

        Presta_Control control = new Presta_Control();
        Presta_Encap Object = new Presta_Encap();

        private void Prestamos_Load(object sender, EventArgs e)
        {
            dtpfec.Value = DateTime.Now.Date;
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            BuscarSocio bus = new BuscarSocio();
            bus.ShowDialog();
            txtsoc.Text = bus.cod;
            txtnos.Text = bus.pat + " " + bus.mat + ", " + bus.nom;
            lbltip.Text = bus.tip;
        }

        private void gunaButton7_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvdatos.SelectedRows.Count > 0)
                {
                    string cod = dgvdatos.CurrentRow.Cells[0].Value.ToString();
                    Object.Codig = cod;

                    var lista = new List<Presta_Encap>();
                    lista = Object.Filtrado();

                    foreach (Presta_Encap item in lista)
                    {
                        string dir = AppDomain.CurrentDomain.BaseDirectory;
                        string car = dir + "/temp/";
                        string ubi = car + item.Exten;

                        if (!Directory.Exists(car))
                            Directory.CreateDirectory(car);

                        if (File.Exists(ubi))
                            File.Delete(ubi);

                        File.WriteAllBytes(ubi, item.Docum);
                        Process.Start(ubi);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Parece que no hubo un archivo agregado, " + ex.Message, "Error D:");
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

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(MessageBox.Show("¿Deseas Agregar el Registro seleccionado?", "Agregar", MessageBoxButtons.YesNo, MessageBoxIcon.Question));
            if (x == 6)
            {
                try
                {
                    Presta_Encap anual = new Presta_Encap();

                    byte[] archivo = null;
                    Stream mystr = file.OpenFile();
                    MemoryStream obj = new MemoryStream();
                    mystr.CopyTo(obj);
                    archivo = obj.ToArray();

                    anual.Socio = txtsoc.Text;
                    anual.Datso = txtnos.Text;
                    anual.Nrota = txtnro.Text;
                    anual.Aport = txtapo.Text;
                    anual.Fecap = dtpfec.Text;
                    anual.Preot = txtpre.Text;
                    anual.Cuota = txtcuo.Text;
                    anual.Amort = txtamo.Text;
                    anual.Intge = txtint.Text;
                    anual.Total = txttot.Text;
                    anual.Cuoex = txtext.Text;
                    anual.Docum = archivo;
                    anual.Exten = file.SafeFileName;
                    anual.Ndocs = txtnom.Text;

                    string respuesta = control.AgregaPrestamo(anual);
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

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            Limpiar();
            dgvdatos.DataSource = Object.ListarDocumento();
        }

        private void txtpre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Limpiar()
        {
            txtcod.Text = null;
            txtsoc.Text = null;
            txtnos.Text = null;
            txtnro.Text = null;
            txtapo.Text = null;
            dtpfec.Value = DateTime.Now;
            txtcuo.Text = null;
            txtnro.Text = null;
            txttot.Text = null;
            txtpre.Text = null;
            txtamo.Text = null;
            txtint.Text = null;
            txtext.Text = null;
            txtrut.Text = null;
            txtnom.Text = null;
            lbltip.Text = "Tipo.";
            dgvdatos.DataSource = Object.ListarDocumento();
        }

        private void Prestamos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (lbltip.Text == "Tipo.")
                {
                    MessageBox.Show("Debe de elegir un socio para realizar esta operacion :)", "¡Vaya ha sucedido un error!");
                }
                else
                {
                    if (lbltip.Text.Trim() == "Socio")
                    {
                        double n1, n2, tot, total;
                        double interes;
                        n1 = Convert.ToDouble(txtpre.Text);
                        n2 = Convert.ToDouble(txtcuo.Text);

                        tot = n1 / n2;
                        interes = n1 * 0.02;
                        total = interes + tot;
                        txtamo.Text = Convert.ToString(Math.Ceiling(tot));
                        txtint.Text = Convert.ToString(Math.Ceiling(interes));
                        txttot.Text = Convert.ToString(Math.Ceiling(total));
                    }

                    if (lbltip.Text.Trim() == "Persona Natural")
                    {
                        double n1, n2, tot, total;
                        double interes;
                        n1 = Convert.ToDouble(txtpre.Text);
                        n2 = Convert.ToDouble(txtcuo.Text);

                        tot = n1 / n2;
                        interes = n1 * 0.05;
                        total = interes + tot;
                        txtamo.Text = Convert.ToString(Math.Ceiling(tot));
                        txtint.Text = Convert.ToString(Math.Ceiling(interes));
                        txttot.Text = Convert.ToString(Math.Ceiling(total));
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void txtbus_TextChanged(object sender, EventArgs e)
        {
            string xd = txtbus.Text;
            dgvdatos.DataSource = Object.BuscarDatos(xd);
        }

        private void gunaImageButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}