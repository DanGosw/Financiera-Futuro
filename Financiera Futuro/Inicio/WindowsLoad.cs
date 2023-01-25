using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace Financiera_Futuro
{
    public partial class WindowsLoad : Form
    {
        public WindowsLoad()
        {
            InitializeComponent();
            lblBienve.Text = "Bienvenido " + Session.usuario + ", estamos realizando los\nultimos ajustes en su perfil...";
            verimg();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.Cir.Increment(1);
                if (Cir.Value == 20)
                {
                    lblentr.Text = "Ajustando perfil...";
                }
                if (Cir.Value == 40)
                {
                    lblentr.Text = "Modificando preferencias...";
                }
                if (Cir.Value == 60)
                {
                    lblentr.Text = "Agregando imagenes...";
                }
                if (Cir.Value == 80)
                {
                    lblentr.Text = "Estamos finalizando los ajustes...";
                }
                if (Cir.Value == 100)
                {
                    lblentr.Text = "Ajustes completamos satisfactoriamente...";
                    timer1.Stop();
                    Menu men = new Menu();
                    men.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}