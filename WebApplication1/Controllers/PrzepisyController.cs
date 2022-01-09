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
    public class PrzepisyController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT * FROM dbo.Przepisy";

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

        public string Post([FromBody] Przepisy przepis)
        {
            try
            {
                string query = @"insert into dbo.Przepisy(Nazwa, Uzytkownik_nazwa_uzytkownika, Sciezka_do_obrazu) 
                                Values( '" + przepis.Nazwa + @"', '" + przepis.Uzytkownik_nazwa_uzytkownika;

                if (przepis.Sciezka_do_obrazu == null)
                {
                   query += @"', NULL)";
                }
                else
                {
                    query += @"', '" + przepis.Sciezka_do_obrazu + @"')";
                }


                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SBDApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Dodano przepis";

            }
            catch (Exception)
            {
                return "Nie dodano przepisu";
            }

        }
    }
}
