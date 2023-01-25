using MySql.Data.MySqlClient;
using System.Data;

namespace Financiera_Futuro.Datos_Personales
{
    class Date_Metod
    {
        public int Agregar(Date_Encap date, string tip, byte[] bit)
        {
            MySqlConnection conexion = Conexion.GetConexion();
            conexion.Open();
            string sql = "INSERT INTO dat_personales (nom_soc, a_pat, a_mat, dni, direc, telefono, email, tip_soc, img_ref) VALUES (@nom, @pat, @mat, @dni, @dir, @tel, @ema, @tip, @img_ref)";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@nom", date.Nom);
            comando.Parameters.AddWithValue("@pat", date.Pat);
            comando.Parameters.AddWithValue("@mat", date.Mat);
            comando.Parameters.AddWithValue("@dni", date.Dni);
            comando.Parameters.AddWithValue("@dir", date.Dir);
            comando.Parameters.AddWithValue("@tel", date.Tel);
            comando.Parameters.AddWithValue("@ema", date.Ema);
            comando.Parameters.AddWithValue("@tip", tip);
            comando.Parameters.AddWithValue("@img_ref", bit);
            int resultado = comando.ExecuteNonQuery();
            return resultado;
        }

        public int Modificar(Date_Encap date, string tip, byte[] bit)
        {
            MySqlConnection conexion = Conexion.GetConexion();
            conexion.Open();
            string sql = "update dat_personales set nom_soc =@nom, a_pat =@pat, a_mat =@mat, dni =@dni, direc =@dir, telefono =@tel,email =@ema, tip_soc =@tip, img_ref =@img_ref where cod_soc =@cod";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@cod", date.Cod);
            comando.Parameters.AddWithValue("@nom", date.Nom);
            comando.Parameters.AddWithValue("@pat", date.Pat);
            comando.Parameters.AddWithValue("@mat", date.Mat);
            comando.Parameters.AddWithValue("@dni", date.Dni);
            comando.Parameters.AddWithValue("@dir", date.Dir);
            comando.Parameters.AddWithValue("@tel", date.Tel);
            comando.Parameters.AddWithValue("@ema", date.Ema);
            comando.Parameters.AddWithValue("@tip", tip);
            comando.Parameters.AddWithValue("@img_ref", bit);
            int resultado = comando.ExecuteNonQuery();
            return resultado;
        }
        public int Eliminar(Date_Encap date)
        {
            MySqlConnection conexion = Conexion.GetConexion();
            conexion.Open();
            string sql = "delete from dat_personales where cod_soc = @cod";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@cod", date.Cod);
            int resultado = comando.ExecuteNonQuery();
            return resultado;
        }
                                    
        public DataTable Mostrar()
        {
            MySqlConnection conexion = Conexion.GetConexion();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "select * from dat_personales";
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable Buscar_Socio(string ingr)
        {
            MySqlConnection conexion = Conexion.GetConexion();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "select cod_soc, nom_soc, a_pat, a_mat, dni, direc, telefono, email, tip_soc, img_ref from " +
                "dat_personales where cod_soc like '%" + ingr + "%'";
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}