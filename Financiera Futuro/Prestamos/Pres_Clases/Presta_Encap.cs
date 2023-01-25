using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace Financiera_Futuro
{
    class Presta_Encap
    {
        string codig, socio, datso, fecap, nrota, aport, preot, cuota,amort, intge, cuoex, total, exten, ndocs;
        byte[] docum;

        public string Codig { get => codig; set => codig = value; }
        public string Socio { get => socio; set => socio = value; }
        public string Datso { get => datso; set => datso = value; }
        public string Fecap { get => fecap; set => fecap = value; }
        public string Nrota { get => nrota; set => nrota = value; }
        public string Aport { get => aport; set => aport = value; }
        public string Preot { get => preot; set => preot = value; }
        public string Amort { get => amort; set => amort = value; }
        public string Intge { get => intge; set => intge = value; }
        public string Cuoex { get => cuoex; set => cuoex = value; }
        public byte[] Docum { get => docum; set => docum = value; }
        public string Exten { get => exten; set => exten = value; }
        public string Ndocs { get => ndocs; set => ndocs = value; }
        public string Total { get => total; set => total = value; }
        public string Cuota { get => cuota; set => cuota = value; }

        public int Agregar(Presta_Encap an)
        {
            MySqlConnection conexion = Conexion.GetConexion();
            conexion.Open();
            string sql = "INSERT INTO prestamo (cod_soc, d_soc, fec_apor, nro_talon, aporte, pres_otorg, nro_cuotas, amort, int_gener, tot_pag, cuot_extra, docs, ext, n_docs)VALUES (@socio, @nombr, @fecha ,@numro, @aport, @preot, @cuota, @amort, @intge, @total, @extra, @docus, @exten, @nodoc)";
            MySqlCommand comando = new MySqlCommand(sql, conexion);
            //comando.Parameters.AddWithValue("@codig", an.Codig);
            comando.Parameters.AddWithValue("@socio", an.Socio);
            comando.Parameters.AddWithValue("@nombr", an.Datso);
            comando.Parameters.AddWithValue("@fecha", an.Fecap);
            comando.Parameters.AddWithValue("@numro", an.Nrota);
            comando.Parameters.AddWithValue("@aport", an.Aport);
            comando.Parameters.AddWithValue("@preot", an.Preot);
            comando.Parameters.AddWithValue("@cuota", an.Cuota);
            comando.Parameters.AddWithValue("@amort", an.Amort);
            comando.Parameters.AddWithValue("@intge", an.Intge);
            comando.Parameters.AddWithValue("@total", an.Total);
            comando.Parameters.AddWithValue("@extra", an.Cuoex);
            comando.Parameters.AddWithValue("@docus", an.Docum);
            comando.Parameters.AddWithValue("@exten", an.Exten);
            comando.Parameters.AddWithValue("@nodoc", an.Ndocs);
            int resultado = comando.ExecuteNonQuery();
            return resultado;
        }

        public DataTable Buscar_Aporte(string ingr)
        {
            MySqlConnection conexion = Conexion.GetConexion();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "select * from prestamo where cod_soc like '%" + ingr + "%'";
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
            MySqlCommand cmd = new MySqlCommand("select cod_pre, cod_soc, d_soc, fec_apor, nro_talon, aporte, pres_otorg, nro_cuotas, amort, int_gener, tot_pag, cuot_extra, n_docs from prestamo", conexion);
            MySqlDataReader res = cmd.ExecuteReader();

            if (res.HasRows) dt.Load(res);
            res.Close();
            conexion.Close();
            return dt;
        }
        public DataTable BuscarDatos(string dat)
        {
            MySqlConnection conexion = Conexion.GetConexion();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "select cod_pre, cod_soc, d_soc, fec_apor, nro_talon, aporte, pres_otorg, nro_cuotas, amort, int_gener, tot_pag, cuot_extra, n_docs from prestamo where d_soc like '%" + dat + "%'";
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        MySqlConnection conexion = Conexion.GetConexion();

        public DataTable ArchivoID()
        {
            DataTable dt = new DataTable();
            conexion.Open();
            MySqlCommand cmd = new MySqlCommand("select * from prestamo where cod_pre = @cod", conexion);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@cod", Codig);
            MySqlDataReader lector = cmd.ExecuteReader();
            dt.Load(lector);
            lector.Close();
            conexion.Close();
            return dt;
        }

        public List<Presta_Encap> Filtrado()
        {
            var dt = ArchivoID();
            var Info = new List<Presta_Encap>();
            foreach (DataRow item in dt.Rows)
            {
                Info.Add(new Presta_Encap
                {
                    Codig = item[0].ToString(),
                    Socio = item[1].ToString(),
                    Datso = item[2].ToString(),
                    Fecap = item[3].ToString(),
                    Nrota = item[4].ToString(),
                    Aport = item[5].ToString(),
                    Preot = item[6].ToString(),
                    Cuota = item[7].ToString(),
                    Amort = item[8].ToString(),
                    Intge = item[9].ToString(),
                    Total = item[10].ToString(),
                    Cuoex = item[11].ToString(),
                    Docum = (byte[])item[12],
                    Exten = item[13].ToString(),
                    Ndocs = item[14].ToString(),
                });
            }
            return Info;
        }

        public DataTable Buscar(string ingr)
        {
            MySqlConnection conexion = Conexion.GetConexion();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = "select D.cod_soc as Codigo, D.nom_soc as Nombre, a_pat as 'Ap. Paterno', a_mat as 'Ap. Materno', " +
                "dni as DNI, tip_soc as 'Tipo de Socio', P.pres_otorg as 'Monto Prestamo', amort as Amortizacion ,int_gener as 'Interes Generado'," +
                " tot_pag as 'Total a Pagar', C.saldo as Saldo from dat_personales as D inner join prestamo as P inner join " +
                "cronograma as C on C.cod_cro = C.cod_cro ON D.cod_soc = P.cod_soc where D.nom_soc like '%" + ingr + "%'";
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
    }
}