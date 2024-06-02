using Microsoft.Data.SqlClient;
using Models;

namespace Repository
{
    public class SQLRepository
    {
        string strConn = "Data Source=127.0.0.1; Initial Catalog=Radar; User Id=sa; Password=SqlServer2019!; TrustServerCertificate=true;";
        SqlConnection conn;
        public SQLRepository()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public List<Infracao> GetAll()
        {
            List<Infracao> infracoes = new List<Infracao>();
         
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT concessionaria, ano_do_pnv_snv, tipo_de_radar, rodovia, uf, km_m, municipio, tipo_pista, sentido, situacao, data_da_inativacao, latitude, longitude, velocidade_leve " +
                       "FROM RadarInfo", conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        Infracao infra = new Infracao()
                        {
                            Concessionaria = reader.GetString(0),
                            AnoPnvSnv = reader.GetString(1),
                            TipoRadar = reader.GetString(2),
                            Rodovia = reader.GetString(3),
                            UF = reader.GetString(4),
                            Km = reader.GetString(5),
                            Municipio = reader.GetString(6),
                            TipoPista = reader.GetString(7),
                            Sentido = reader.GetString(8),
                            Situacao = reader.GetString(9),
                            DataInativacao = reader.GetString(10).Split(new[] { ", " }, StringSplitOptions.None),
                            Latitude = reader.GetString(11),
                            Longitude = reader.GetString(12),
                            Velocidade = reader.GetString(13)
                        };


                        infracoes.Add(infra);
                    }

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return infracoes;
        }

    }
}