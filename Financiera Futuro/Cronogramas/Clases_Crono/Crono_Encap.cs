using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Financiera_Futuro
{
    class Crono_Encap
    {
        private string codi;
        private string soci;
        private string nomS;
        private string fech;
        private string mont;
        private string cuot;
        private string amor;
        private string inte;
        private string tota;
        private string sald;
        private string obse;
        private string mult;
        private string exts;
        private string nodo;
        private byte[] docs;

        public string Codi { get => codi; set => codi = value; }
        public string Soci { get => soci; set => soci = value; }
        public string NomS { get => nomS; set => nomS = value; }
        public string Fech { get => fech; set => fech = value; }
        public string Amor { get => amor; set => amor = value; }
        public string Inte { get => inte; set => inte = value; }
        public string Tota { get => tota; set => tota = value; }
        public string Obse { get => obse; set => obse = value; }
        public string Mult { get => mult; set => mult = value; }
        public string Exts { get => exts; set => exts = value; }
        public string Nodo { get => nodo; set => nodo = value; }
        public byte[] Docs { get => docs; set => docs = value; }
        public string Cuot { get => cuot; set => cuot = value; }
        public string Mont { get => mont; set => mont = value; }
        public string Sald { get => sald; set => sald = value; }

        public int Agregar(Crono_Encap an)
        {
            MySqlConnection conexion = Conexion.GetConexion();
            conexion.Open();
            string sql = "INSERT INTO cronograma (cod_soc, nom_soc, fec_vence, monto, cuotas, amort_capital, interes, total_pago, saldo, obs, mul, doc, extension, nom_doc)VALUES (@soci,@nomb, @fech,@cuot, @mont, @amor, @inte, @tota, @sald,@obse, @mult, @docs,@exte, @ndoc)";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@soci", an.Soci);
            comando.Parameters.AddWithValue("@nomb", an.NomS);
            comando.Parameters.AddWithValue("@fech", an.Fech);
            comando.Parameters.AddWithValue("@mont", an.Mont);
            comando.Parameters.AddWithValue("@cuot", an.Cuot);
            comando.Parameters.AddWithValue("@amor", an.Amor);
            comando.Parameters.AddWithValue("@inte", an.Inte);
            comando.Parameters.AddWithValue("@tota", an.Tota);
            comando.Parameters.AddWithValue("@mult", an.Mult);
            comando.Parameters.AddWithValue("@sald", an.Sald);
            comando.Parameters.AddWithValue("@obse", an.Obse);
            comando.Parameters.AddWithValue("@docs", an.Docs);
            comando.Parameters.AddWithValue("@exte", an.Exts);
            comando.Parameters.AddWithValue("@ndoc", an.Nodo);
            int resultado = comando.ExecuteNonQuery();
            return resultado;
        }

        public int Modificar(Crono_Encap an)
        {
            MySqlConnection conexion = Conexion.GetConexion();
            conexion.Open();
            string sql = "update cronograma set cod_soc=@soci, nom_soc=@nomb, fec_vence=@fech, monto=@mont, cuotas=@cuot, " +
                "amort_capital=@amor, interes=@inte, total_pago=@tota, mul= @mult,saldo=@sald obs=@obse where cod_cro =@codi";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@codi", an.Codi);
            comando.Parameters.AddWithValue("@soci", an.Soci);
            comando.Parameters.AddWithValue("@nomb", an.NomS);
            comando.Parameters.AddWithValue("@fech", an.Fech);
            comando.Parameters.AddWithValue("@mont", an.Mont);
            comando.Parameters.AddWithValue("@cuot", an.Cuot);
            comando.Parameters.AddWithValue("@amor", an.Amor);
            comando.Parameters.AddWithValue("@inte", an.Inte);
            comando.Parameters.AddWithValue("@tota", an.Tota);
            comando.Parameters.AddWithValue("@mult", an.Mult);
            comando.Parameters.AddWithValue("@sald", an.Sald);
            comando.Parameters.AddWithValue("@obse", an.Obse);
            int resultado = comando.ExecuteNonQuery();
            return resultado;
        }

        public int Eliminar(Crono_Encap an)
        {
            MySqlConnection conexion = Conexion.GetConexion();
            conexion.Open();
            string sql = "delete from cronograma where cod_cro =@codi";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@codi", an.Codi);
            int resultado = comando.ExecuteNonQuery();
            return resultado;
        }

        public DataTable Buscar_Aporte(string ingr)
        {
            MySqlConnection conexion = Conexion.GetConexion();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "select * from cronograma where nom_socio like '%" + ingr + "%'";
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable ListarDocumento()
        {
            DataTable dt = new DataTable();
            MySqlConnection conexion = Conexion.GetConexion();
            conexion.Open();
            MySqlCommand cmd = new MySqlCommand("select cod_cro, cod_soc, nom_soc, fec_vence, monto, cuotas, amort_capital, interes, total_pago, saldo, obs, mul, nom_doc from cronograma", conexion);
            MySqlDataReader res = cmd.ExecuteReader();

            if (res.HasRows) dt.Load(res);
            res.Close();
            conexion.Close();
            return dt;
        }

        MySqlConnection conexion = Conexion.GetConexion();

        public DataTable ArchivoID()
        {
            DataTable dt = new DataTable();
            conexion.Open();            
            MySqlCommand cmd = new MySqlCommand("select * from cronograma where cod_cro = @codi",conexion);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@codi", Codi);
            MySqlDataReader lector = cmd.ExecuteReader();            
            dt.Load(lector);
            lector.Close();
            conexion.Close();
            return dt;
        }

        public List<Crono_Encap> Filtrado()
        {
            var dt = ArchivoID();
            var Info = new List<Crono_Encap>();
            foreach (DataRow item in dt.Rows)
            {
                Info.Add(new Crono_Encap
                {
                    Codi = item[0].ToString(),
                    Soci = item[1].ToString(),
                    NomS = item[2].ToString(),
                    Fech = item[3].ToString(),
                    Mont = item[4].ToString(),
                    Cuot = item[5].ToString(),
                    Amor = item[6].ToString(),
                    Inte = item[7].ToString(),
                    Tota = item[8].ToString(),
                    Sald = item[9].ToString(),
                    Obse = item[10].ToString(),
                    Mult = item[11].ToString(),
                    Docs = (byte[])item[12],
                    Exts = item[13].ToString(),
                    Nodo = item[14].ToString()
                });
            }
            return Info;
        }
    }
}