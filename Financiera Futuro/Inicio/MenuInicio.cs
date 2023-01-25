using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Financiera_Futuro
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
            PanelOcultar();
            label1.Text = Session.usuario;
            label2.Text = Session.email;
            verimg();
            this.Padding = new Padding(borderSize);
            this.BackColor = Color.FromArgb(98, 102, 244);
            ti = new Timer();
            ti.Tick += new EventHandler(Exd);
            ti.Enabled = true;
        }
        private void Exd(object ob, EventArgs evt)
        {
            DateTime xd = DateTime.Now;
            lblxd.Text = xd.ToString("h:mm:ss tt");
        }

        private readonly int borderSize = 2;
        private Size formSize;
        private readonly Timer ti;

        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020;
            const int SC_RESTORE = 0xF120;
            const int WM_NCHITTEST = 0x0084;
            const int resizeAreaSize = 10;
            const int HTCLIENT = 1;
            const int HTLEFT = 10;
            const int HTRIGHT = 11;
            const int HTTOP = 12;
            const int HTTOPLEFT = 13;
            const int HTTOPRIGHT = 14;
            const int HTBOTTOM = 15;
            const int HTBOTTOMLEFT = 16;
            const int HTBOTTOMRIGHT = 17;

            if (m.Msg == WM_NCHITTEST)
            {
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)
                {
                    if ((int)m.Result == HTCLIENT)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= resizeAreaSize)
                        {
                            if (clientPoint.X <= resizeAreaSize)
                                m.Result = (IntPtr)HTTOPLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))
                                m.Result = (IntPtr)HTTOP;
                            else
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize))
                        {
                            if (clientPoint.X <= resizeAreaSize)
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
           
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            
            if (m.Msg == WM_SYSCOMMAND)
            {
                int wParam = (m.WParam.ToInt32() & 0xFFF0);
                if (wParam == SC_MINIMIZE)
                    formSize = this.ClientSize;
                if (wParam == SC_RESTORE)
                    this.Size = formSize;
            }
            base.WndProc(ref m);
        }

        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized:
                    this.Padding = new Padding(8, 8, 8, 0);
                    break;
                case FormWindowState.Normal:
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
        }

        private void CollapseMenu()
        {
            if (this.Sidebar.Width > 200)
            {
                Sidebar.Width = 90;
                ImgUsu.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                btnMenu.Dock = DockStyle.Top;

                foreach (Button menuButton in Sidebar.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            {
                Sidebar.Width = 230;
                ImgUsu.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                btnMenu.Dock = DockStyle.None;

                foreach (Button menuButton in Sidebar.Controls.OfType<Button>())
                {
                    menuButton.Text = "   " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }

        private void PanelOcultar()
        {
            PanelReportes.Visible = false;
            menuMantenimiento.Visible = false;
        }

        private void ocultarSubMenu()
        {
            if (PanelReportes.Visible == true)
                PanelReportes.Visible = false;
            if (menuMantenimiento.Visible == true)
                menuMantenimiento.Visible = false;
        }

        private void ShowMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                ocultarSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        public void verimg()
        {
            MySqlConnection conexion = Conexion.GetConexion();
            conexion.Open();
            string sql = "select imagen from user where cod_user = '" + Session.cod + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            MySqlDataAdapter dp = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            DataSet ds = new DataSet("user");
            dp.Fill(ds, "user");
            byte[] datos = new byte[0];
            DataRow dr = ds.Tables["user"].Rows[0];
            datos = (byte[])dr["imagen"];
            System.IO.MemoryStream ms = new System.IO.MemoryStream(datos);
            ImgUsu.Image = System.Drawing.Bitmap.FromStream(ms);
        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {
            ShowMenu(menuMantenimiento);
        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            ShowMenu(PanelReportes);
        }

        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form formulario;
            formulario = PanelContenedor.Controls.OfType<MiForm>().FirstOrDefault();
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                PanelContenedor.Controls.Add(formulario);
                PanelContenedor.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CloseForm);
            }
            else
            {
                formulario.BringToFront();
            }
        }

        private void CloseForm(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["AporteAnual"] == null)
                anual.Visible = false;
            if (Application.OpenForms["Add_Socios"] == null)
                soc.Visible = false;
            if (Application.OpenForms["AddUser"] == null)
                usu.Visible = false; 
            if (Application.OpenForms["Cronograma"] == null)
                crono.Visible = false;
            if (Application.OpenForms["Prestamos"] == null)
                presta.Visible = false;
            if (Application.OpenForms["Asistencia"] == null)
                asis.Visible = false;
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Add_Socios>();
            ocultarSubMenu();
            soc.Visible = true;
        }

        private void gunaButton10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login logxd = new Login();
            logxd.ShowDialog();
            this.Close();
        }

        private void btnAnual_Click_1(object sender, EventArgs e)
        {
            AbrirFormulario<AporteAnual>();
            ocultarSubMenu();
            anual.Visible = true;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            AbrirFormulario<AddUser>();
            ocultarSubMenu();
            usu.Visible = true;
        }

        private void btnAsis_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Asistencia>();
            ocultarSubMenu();
            asis.Visible = true;
        }

        private void btncrono_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Cronograma>();
            ocultarSubMenu();
            crono.Visible = true;
        }

        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Prestamos>();
            ocultarSubMenu();
            presta.Visible = true;
        }

        private void Menu_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }

        private void gunaButton1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void gunaButton2_Click_1(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                formSize = this.ClientSize;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = formSize;
            }
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }
    }
}