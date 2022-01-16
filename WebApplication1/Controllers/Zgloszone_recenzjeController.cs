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
    public class Zgloszone_recenzjeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT * FROM dbo.Zgloszone_recenzje";

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


        //api/zgloszone_recenzje/{Recenzje_id_recenzji}
        public HttpResponseMessage Get(int id)
        {
            string query = @"SELECT * FROM dbo.Zgloszone_recenzje WHERE Recenzje_id_recenzji = " + id + @"";

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

        public string Post([FromBody] Zgloszone_recenzje zgloszone_Recenzje)
        {
            try
            {
                string query = @"insert into dbo.zgloszone_Recenzje(Recenzje_id_recenzji, Opis ) 
                                Values( "
                                + zgloszone_Recenzje.Recenzje_id_recenzji + @", ";

                if (zgloszone_Recenzje.Opis != null)
                {
                    query += "'" + zgloszone_Recenzje.Opis + @"' ";
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

        public string Put([FromBody] Zgloszone_recenzje zgloszone_Recenzje)
        {
            try
            {
                string query = @"UPDATE dbo.zgloszone_Przepisy SET status_zgloszenia = '" + zgloszone_Recenzje.Status_zgloszenia + @"'"
                + @"WHERE id_zgloszenia = " + zgloszone_Recenzje.Id_zgloszenia + @"";


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
