using MySql.Data.MySqlClient;

namespace Financiera_Futuro
{
    public class Conexion
    {
        public static MySqlConnection GetConexion()
        {
            string cadenaConexion = "database=futuro; data source=localhost; user id=root; pwd=AnnAuwu12";
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            return conexion;
        }
    }
}