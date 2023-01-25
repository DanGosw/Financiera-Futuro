using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;

namespace Financiera_Futuro
{
    class Usuarios
    {
        private Image ima;
        string cod, nom, pas,ema,tip, fec;

        public string Cod { get => cod; set => cod = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Pas { get => pas; set => pas = value; }
        public string Ema { get => ema; set => ema = value; }
        public string Tip { get => tip; set => tip = value; }
        public string Fec { get => fec; set => fec = value; }
        public Image Ima { get => ima; set => ima = value; }

        public void eliminar()
        {
            MySqlConnection conexion = Conexion.GetConexion();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "delete from user where cod_user = '" + cod + "'";
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        public DataTable mostrar()
        {
            MySqlConnection conexion = Conexion.GetConexion();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "select * from user";
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable Buscar_Aporte(string ingr)
        {
            MySqlConnection conexion = Conexion.GetConexion();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "select * from user where nom_user like '%" + ingr + "%'";
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}