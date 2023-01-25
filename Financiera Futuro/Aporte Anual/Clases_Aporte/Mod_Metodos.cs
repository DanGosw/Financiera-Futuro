using MySql.Data.MySqlClient;
using System.Data;

namespace Financiera_Futuro
{
    class Mod_Metodos
    {
        public int registro (AnualEncap anual, string socio, string esta)
        {
            MySqlConnection conexion = Conexion.GetConexion();
            conexion.Open();    
            string sql = "INSERT INTO apor_anual (cod_soc, año_ap, cuota_extr, est_socio, ene_ap, feb_ap, mar_ap, abr_ap, may_ap, jun_ap, jul_ap, ago_ap, set_ap, oct_ap, nov_ap, dic_ap, total) " +
                "VALUES (@cod_soc, @año_ap, @cuota_extr, @est_socio, @ene_ap, @feb_ap, @mar_ap, @abr_ap, @may_ap, @jun_ap, @jul_ap, @ago_ap, @set_ap, @oct_ap, @nov_ap, @dic_ap, @total)";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@cod_soc", socio);
            comando.Parameters.AddWithValue("@año_ap", anual.AñoA);
            comando.Parameters.AddWithValue("@cuota_extr", anual.Cuota);
            comando.Parameters.AddWithValue("@est_socio", esta);
            comando.Parameters.AddWithValue("@ene_ap", anual.EnerA);
            comando.Parameters.AddWithValue("@feb_ap", anual.FebrA);
            comando.Parameters.AddWithValue("@mar_ap", anual.MarzA);
            comando.Parameters.AddWithValue("@abr_ap", anual.AbriA);
            comando.Parameters.AddWithValue("@may_ap", anual.MayoA);
            comando.Parameters.AddWithValue("@jun_ap", anual.JuniA);
            comando.Parameters.AddWithValue("@jul_ap", anual.JuliA);
            comando.Parameters.AddWithValue("@ago_ap", anual.AgosA);
            comando.Parameters.AddWithValue("@set_ap", anual.SetpA);
            comando.Parameters.AddWithValue("@oct_ap", anual.OctuA);
            comando.Parameters.AddWithValue("@nov_ap", anual.NoviA);
            comando.Parameters.AddWithValue("@dic_ap", anual.DiciA);
            comando.Parameters.AddWithValue("@total", anual.TotaA);
            int resultado = comando.ExecuteNonQuery();
            return resultado;
        }

        public int modificar(AnualEncap anual, string socio, string esta)
        {
            MySqlConnection conexion = Conexion.GetConexion();
            conexion.Open();
            string sql = "update apor_anual set cod_soc = @cod_soc, año_ap =@año_ap, cuota_extr =@cuota_extr, est_socio=@est_socio, ene_ap=@ene_ap, " +
                "feb_ap=@feb_ap, mar_ap=@mar_ap, abr_ap=@abr_ap, may_ap=@may_ap, jun_ap=@jun_ap, jul_ap=@jul_ap, ago_ap=@ago_ap, set_ap=@set_ap, oct_ap=@oct_ap, " +
                "nov_ap=@nov_ap, dic_ap=@dic_ap, total=@total_ap where cod_men = @cod_men";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@cod_soc", socio);
            comando.Parameters.AddWithValue("@cod_men", anual.Codig);
            comando.Parameters.AddWithValue("@año_ap", anual.AñoA);
            comando.Parameters.AddWithValue("@cuota_extr", anual.Cuota);
            comando.Parameters.AddWithValue("@est_socio", esta);
            comando.Parameters.AddWithValue("@ene_ap", anual.EnerA);
            comando.Parameters.AddWithValue("@feb_ap", anual.FebrA);
            comando.Parameters.AddWithValue("@mar_ap", anual.MarzA);
            comando.Parameters.AddWithValue("@abr_ap", anual.AbriA);
            comando.Parameters.AddWithValue("@may_ap", anual.MayoA);
            comando.Parameters.AddWithValue("@jun_ap", anual.JuniA);
            comando.Parameters.AddWithValue("@jul_ap", anual.JuliA);
            comando.Parameters.AddWithValue("@ago_ap", anual.AgosA);
            comando.Parameters.AddWithValue("@set_ap", anual.SetpA);
            comando.Parameters.AddWithValue("@oct_ap", anual.OctuA);
            comando.Parameters.AddWithValue("@nov_ap", anual.NoviA);
            comando.Parameters.AddWithValue("@dic_ap", anual.DiciA);
            comando.Parameters.AddWithValue("@total_ap", anual.TotaA);
            int resultado = comando.ExecuteNonQuery();
            return resultado;
        }
        public int eliminar(AnualEncap anual)
        {
            MySqlConnection conexion = Conexion.GetConexion();
            conexion.Open();
            string sql = "delete from apor_anual where cod_men = @cod_men";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@cod_men", anual.Codig);
            int resultado = comando.ExecuteNonQuery();
            return resultado;
        }

        public DataTable mostrar()
        {
            MySqlConnection conexion = Conexion.GetConexion();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "select * from apor_anual";
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
            cmd.CommandText = "select * from apor_anual where cod_soc like '%" + ingr + "%'";
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public DataTable Filtros(string date, string estado)
        {
            MySqlConnection conexion = Conexion.GetConexion();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "select * from apor_anual where año_ap = '" + date + "' and est_socio = '" + estado + "'";
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}