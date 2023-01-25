using MySql.Data.MySqlClient;

namespace Financiera_Futuro
{
    class Modelo
    {
        public int registro(Usuarios usuario, byte[] aByte)
        {
            MySqlConnection conexion = Conexion.GetConexion();
            conexion.Open();

            string sql = "INSERT INTO user (cod_user, nom_user, password, imagen, email, tipo, fec_creation) VALUES (@cod_user, @nom_user, @password, @imagen, @email, @tipo, @fecha)";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@cod_user", usuario.Cod);
            comando.Parameters.AddWithValue("@nom_user", usuario.Nom);
            comando.Parameters.AddWithValue("@password", usuario.Pas);
            comando.Parameters.AddWithValue("@imagen", aByte);
            comando.Parameters.AddWithValue("@email", usuario.Ema);
            comando.Parameters.AddWithValue("@tipo", usuario.Tip);
            comando.Parameters.AddWithValue("@fecha", usuario.Fec);
            int resultado = comando.ExecuteNonQuery();

            return resultado;
        }

        public int modificar(Usuarios usuario, byte[] imagen)
        {
            MySqlConnection conexion = Conexion.GetConexion();
            conexion.Open();
            string sql = "update user set nom_user = @nom_user , password =@password, imagen =@imagen, email=@email, tipo=@tipo, fec_creation = @fecha where cod_user = @cod_user";                       
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@cod_user", usuario.Cod);
            comando.Parameters.AddWithValue("@nom_user", usuario.Nom);
            comando.Parameters.AddWithValue("@password", usuario.Pas);
            comando.Parameters.AddWithValue("@imagen", imagen);
            comando.Parameters.AddWithValue("@email", usuario.Ema);
            comando.Parameters.AddWithValue("@tipo", usuario.Tip);
            comando.Parameters.AddWithValue("@fecha", usuario.Fec);
            int resultado = comando.ExecuteNonQuery();

            return resultado;
        }

        public bool existeUsuario(string usuario)
        {
            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.GetConexion();
            conexion.Open();

            string sql = "SELECT cod_user FROM user WHERE nom_user LIKE @usuario";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@usuario", usuario);
            reader = comando.ExecuteReader();

            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Usuarios porUsuario(string usuario)
        {
            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.GetConexion();
            conexion.Open();
            string sql = "SELECT cod_user, nom_user, password, email, imagen, tipo, fec_creation FROM user WHERE nom_user LIKE @usuario";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@usuario", usuario);
            reader = comando.ExecuteReader();
            Usuarios usr = null;
            while (reader.Read())
            {
                usr = new Usuarios();
                usr.Cod = reader["cod_user"].ToString();
                usr.Nom = reader["nom_user"].ToString();
                usr.Pas = reader["password"].ToString();
                usr.Ema = reader["email"].ToString();
                usr.Tip = reader["tipo"].ToString();
                usr.Fec = reader["fec_creation"].ToString();
            }
            return usr;
        }
    }
}