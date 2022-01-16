using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class Zgloszone_przepisyController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT * FROM dbo.Zgloszone_przepisy";

            System.Data.DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SBDApp"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        //api/zgloszone_Przepisy/{przepis_id_przepisu}
        public HttpResponseMessage Get(int id)
        {
            string query = @"SELECT * FROM dbo.Zgloszone_przepisy WHERE przepis_id_przepisu = " + id + @"";

            System.Data.DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SBDApp"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }


        public string Post([FromBody] Zgloszone_przepisy zgloszone_Przepisy)
        {
            try
            {
                string query = @"insert into dbo.Zgloszone_przepisy(przepis_id_przepisu, Opis ) 
                                Values( "
                                + zgloszone_Przepisy.Przepis_id_przepisu + @", ";

                if (zgloszone_Przepisy.Opis != null)
                {
                    query += "'" + zgloszone_Przepisy.Opis + @"' ";
                }
                else
                {
                    query += @"NULL ";
                }

                query += @")";


                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SBDApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Dodano recenzje";

            }
            catch (Exception)
            {

                return "Nie dodano recenzji";
            }

        }

         public string Put([FromBody] Zgloszone_przepisy zgloszone_Przepisy)
        {
            try
            {
                string query = @"UPDATE dbo.zgloszone_Przepisy SET status_zgloszenia = '" + zgloszone_Przepisy.Status_zgloszenia + @"'"
                + @"WHERE id_zgloszenia = " + zgloszone_Przepisy.Id_zgloszenia + @"";


                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SBDApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Zmieniono widoczność recenzji";

            }
            catch (Exception)
            {

                return "Nie zmieniono widoczności recenzji";
            }

        }
    }
}
