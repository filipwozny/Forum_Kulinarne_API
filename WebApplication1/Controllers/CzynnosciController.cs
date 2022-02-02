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
    public class CzynnosciController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT * FROM dbo.Czynnosci";

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

        //api/Czynnosci/{id}
        public HttpResponseMessage Get(int id)
        {
            string query = @"SELECT * FROM dbo.Czynnosci WHERE id_przepisu = " + id;

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

        public string Post([FromBody] Czynnosci czynnosci)
        {
            try
            {
                string query = @"insert into dbo.Czynnosci(id_przepisu, kolejnosc_w_przepisie, opis) 
                                Values( " + czynnosci.Id_przepisu + @", " + czynnosci.Kolejnosc_w_przepisie + @",'" + czynnosci.Opis + @"')";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SBDApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Dodano czynność";

            }
            catch (Exception)
            {
                return "Nie dodano czynności";
            }

        }


        public string Delete(int id)
        {
            try
            {
                string query = @"DELETE FROM dbo.czynnosci WHERE id_przepisu = " + id;

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["SBDApp"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Usunięto czynnosci";
            }
            catch (Exception)
            {

                return "Nie znaleziono czynnosci";
            }

        }

    }
}
