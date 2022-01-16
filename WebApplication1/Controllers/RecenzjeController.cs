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
    public class RecenzjeController : ApiController
    {


        public HttpResponseMessage Get()
        {
            string query = @"SELECT * FROM dbo.Recenzje";

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

        // api/Recenzje/{id_przepisu}
        public HttpResponseMessage Get(int id)
        {
            string query = @"SELECT * FROM dbo.Recenzje WHERE Przepis_id_przepisu = " + id;

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

        public string Post([FromBody] Recenzje recenzje)
        {
            try
            {
                string query = @"insert into dbo.Recenzje(przepis_id_przepisu, Uzytkownik_nazwa_uzytkownika, ocena , komentarz ) 
                                Values( "
                                + recenzje.Przepis_id_przepisu + @", '"
                                + recenzje.Uzytkownik_nazwa_uzytkownika + @"', "
                                + recenzje.Ocena + @", ";

                if (recenzje.Komentarz != null)
                {
                    query += @"'" + recenzje.Komentarz + @"' ";
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

        
        public string Put([FromBody] Recenzje recenzje)
        {
            try
            {
                string query = @"UPDATE dbo.Recenzje SET widocznosc = ";
                if (recenzje.Widzocnosc == 1 )
                {

                    query += @"1";
                }
                else {
                    query += @"0";
                }
                query += @" WHERE id_recenzji = " + recenzje.Id_recenzji + @"";


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
