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
    public class Kategorie_przepisowController : ApiController
    {

        public HttpResponseMessage Get()
        {
            string query = @"SELECT * FROM dbo.Kategorie_przepisow";

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

        // api/Kategorie_przepisow/{kategoria_nazwa}
        public HttpResponseMessage Get(string id)
        {
            string query = @"SELECT * FROM dbo.Kategorie_przepisow WHERE kategoria_nazwa = '" + id +@"'";

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

        public string Post([FromBody] Kategorie_przepisow kategorie_Przepisow)
        {
            try
            {
                string query = @"insert into dbo.kategorie_Przepisow(przepis_id, kategoria_id ) 
                                Values( "
                                + kategorie_Przepisow.Przepis_id + @", "
                                + kategorie_Przepisow.Kategoria_id + @") ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SBDApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Dodano przepis do danej kategorii";

            }
            catch (Exception)
            {

                return "Nie dodano przepis do danej kategorii";
            }

        }
    }
}
