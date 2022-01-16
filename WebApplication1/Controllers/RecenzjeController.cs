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

        public HttpResponseMessage Get() {

            string query = @"SELECT * FROM dbo.Recenzje";

            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SBDApp"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }


        public string Post([FromBody] Recenzje recenzja)
        {
            try
            {
                string query = @"insert into dbo.Recenzje( Przepis_id_przepisu, uzytkownik_nazwa_uzytkownika
                                , ocena , komentarz) 
                                Values("+ recenzja.Przepis_id_przepisu + @",'" + recenzja.Uzytkownik_Nazwa_Uzytkownika + @"'," + recenzja.Ocena;

                if (recenzja.Komentarz == null)
                {
                    query += @", NULL)";
                }
                else
                {
                    query += @", '" + recenzja.Komentarz + @"')";
                }


                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SBDApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Dodano recencje";

            }
            catch (Exception)
            {
                return "Nie dodano recenzji";
            }

        }

        //Wszystkie recenzje dla przepisu o {id}
        public HttpResponseMessage Get(int id)
        {
            try
            {
                string query = @"SELECT * FROM dbo.Recenzje WHERE przepis_id_przepisu = " + id;

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SBDApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return Request.CreateResponse(HttpStatusCode.OK, table);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

    }
}
