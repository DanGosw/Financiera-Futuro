using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;

namespace Financiera_Futuro
{
    class Asis_Encap
    {
        string cod, dni, nom, pat, mat, fec, asi, mul;
        byte [] ima;
        public string Cod { get => cod; set => cod = value; }
        public string Dni { get => dni; set => dni = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Pat { get => pat; set => pat = value; }
        public string Mat { get => mat; set => mat = value; }
        public string Fec { get => fec; set => fec = value; }
        public string Asi { get => asi; set => asi = value; }
        public string Mul { get => mul; set => mul = value; }
        public byte[] Ima { get => ima; set => ima = value; }

        public int Agregar(Asis_Encap an)
        {
            MySqlConnection conexion = Conexion.GetConexion();
            conexion.Open();
            string sql = "INSERT INTO asis_reunion (dni, nombre, pat, mat, fec_reu, asis, multa, imag)VALUES (@dni,@nom, @pat,@mat, @fec, @asi, @mul, @ima)";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@dni", an.Dni);
            comando.Parameters.AddWithValue("@nom", an.Nom);
            comando.Parameters.AddWithValue("@pat", an.Pat);
            comando.Parameters.AddWithValue("@mat", an.Mat);
            comando.Parameters.AddWithValue("@fec", an.Fec);
            comando.Parameters.AddWithValue("@asi", an.Asi);
            comando.Parameters.AddWithValue("@mul", an.Mul);
            comando.Parameters.AddWithValue("@ima", an.Ima);
            int resultado = comando.ExecuteNonQuery();
            return resultado;
        }

        public int Modificar(Asis_Encap an)
        {
            MySqlConnection conexion = Conexion.GetConexion();
            conexion.Open();
            string sql = "update asis_reunion set dni=@dni, nombre=@nom, pat=@pat, mat=@mat, fec_reu=@fec, asis=@asi, multa=@mul, imag= @ima";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@dni", an.Dni);
            comando.Parameters.AddWithValue("@nom", an.Nom);
            comando.Parameters.AddWithValue("@pat", an.Pat);
            comando.Parameters.AddWithValue("@mat", an.Mat);
            comando.Parameters.AddWithValue("@fec", an.Fec);
            comando.Parameters.AddWithValue("@asi", an.Asi);
            comando.Parameters.AddWithValue("@mul", an.Mul);
            comando.Parameters.AddWithValue("@ima", an.Ima);
            int resultado = comando.ExecuteNonQuery();
            return resultado;
        }

        public int Eliminar(Asis_Encap an)
        {
            MySqlConnection conexion = Conexion.GetConexion();
            conexion.Open();
            string sql = "delete from asis_reunion where cod_creu =@cod";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@cod", an.Cod);
            int resultado = comando.ExecuteNonQuery();
            return resultado;
        }

        public DataTable Buscar_Aporte(string ingr)
        {
            MySqlConnection conexion = Conexion.GetConexion();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "select * from asis_reunion where fec_reu = '%" + ingr + "%'";
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable mostrar()
        {
            MySqlConnection conexion = Conexion.GetConexion();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "select * from asis_reunion";
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}